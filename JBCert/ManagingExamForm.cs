using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class ManagingExamForm : Form
    {
        IManagingSchoolService managingSchoolService;
        public ManagingExamForm()
        {
            InitializeComponent();
            managingSchoolService = new ManagingSchoolService();
            AddExamForm.OnExamAdded += AddExamForm_OnExamAdded;
            EditExamForm.OnExamUpdated += EditExamForm_OnExamUpdated;
        }

        private void EditExamForm_OnExamUpdated()
        {
            LoadExamList();
        }

        private void AddExamForm_OnExamAdded()
        {
            LoadExamList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddExamForm addExamForm = new AddExamForm();
            addExamForm.ShowDialog();
        }


        private void LoadExamList()
        {
            List<ExamModel> examModels = managingSchoolService.GetAllExam();
            ExamDataGridView.Rows.Clear();
            int i = 1;
            foreach (var examModel in examModels)
            {
                ExamDataGridView.Rows.Add
                (
                    examModel.Id,
                    false,
                    i++,
                    examModel.ExamName,
                    examModel.SchoolName,
                    examModel.ExamDate.ToString("dd/MM/yyyy"),
                    examModel.BlankCertTypeName
                );
            }
        }

        private void ManagingExamForm_Load(object sender, EventArgs e)
        {
            //Point headerCellLocation = ExamDataGridView.GetCellDisplayRectangle(0, -1, true).Location;
            ////Place the Header CheckBox in the Location of the Header Cell.
            //headerCheckBox.Location = new Point(headerCellLocation.X + 25, headerCellLocation.Y + 2);
            //headerCheckBox.BackColor = Color.White;
            //headerCheckBox.Size = new Size(18, 18);
            //headerCheckBox.Click += HeaderCheckBox_Click; ;
            //ExamDataGridView.Controls.Add(headerCheckBox);

            LoadExamList();
        }

        //private void HeaderCheckBox_Click(object sender, EventArgs e)
        //{
        //    if (headerCheckBox.Checked)
        //    {
        //        foreach (DataGridViewRow row in ExamDataGridView.Rows)
        //        {
        //            DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
        //            currentCheckBox.Value = true;
        //        }
        //    }
        //    else
        //    {
        //        foreach (DataGridViewRow row in ExamDataGridView.Rows)
        //        {
        //            DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
        //            currentCheckBox.Value = false;
        //        }
        //    }

        //    ExamDataGridView.EndEdit();
        //}

        private void ExamDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ExamDataGridView.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                int examId = int.Parse(ExamDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                EditExamForm editExamForm = new EditExamForm(examId);
                editExamForm.ShowDialog();
            }
            else if (e.ColumnIndex == ExamDataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int examId = int.Parse(ExamDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                        int result = managingSchoolService.DeleteExam(examId);
                        if (result > 0)
                        {
                            //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                            notificationForm.ShowDialog();
                            LoadExamList();
                        }
                        else
                        {
                            //MessageBox.Show("Xóa không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            NotificationForm notificationForm = new NotificationForm("Xóa không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                            notificationForm.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                        notificationForm.ShowDialog();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //no delete
                }
            }
        }

        private void ExamDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0 && e.ColumnIndex == ExamDataGridView.Columns["RowCheckBox"].Index)
            //    {
            //        DataGridViewCheckBoxCell rowCheckBox = (DataGridViewCheckBoxCell)ExamDataGridView.Rows[e.RowIndex].Cells["RowCheckBox"];
            //        if (Convert.ToBoolean(rowCheckBox.Value) == false)
            //        {
            //            headerCheckBox.Checked = false;
            //        }
            //    }
            //}
            //catch
            //{

            //}
        }

        private void ExamDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ExamDataGridView.IsCurrentCellDirty)
            {
                ExamDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> examIds = (from DataGridViewRow r in ExamDataGridView.Rows
                                     where Convert.ToBoolean(r.Cells[1].Value) == true
                                     select Convert.ToInt32(r.Cells[0].Value)).ToList();
                if (examIds.Count == 1)
                {
                    int examId = examIds.FirstOrDefault();
                    EditExamForm editExamForm = new EditExamForm(examId);
                    editExamForm.ShowDialog();
                }
                else if (examIds.Count == 0)
                {
                    //MessageBox.Show("Bạn chưa chọn kỳ thi nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Bạn chưa chọn kỳ thi nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Chỉ chọn 1 kỳ thi để sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chỉ chọn 1 kỳ thi để sửa", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            List<int> examIds = (from DataGridViewRow r in ExamDataGridView.Rows
                                 where Convert.ToBoolean(r.Cells[1].Value) == true
                                 select Convert.ToInt32(r.Cells[0].Value)).ToList();
            ConfirmForm confirmForm = new ConfirmForm("Đồng ý xóa ?");
            confirmForm.ShowDialog();
            if (confirmForm.Result == DialogResult.Yes)
            {
                try
                {
                    int result = managingSchoolService.DeleteManyExam(examIds);
                    if (result > 0)
                    {
                        //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                        notificationForm.ShowDialog();
                        LoadExamList();
                    }
                    else
                    {
                        //MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NotificationForm notificationForm = new NotificationForm("Xóa không thành công", "Cảnh báo", MessageBoxIcon.Error);
                        notificationForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                    notificationForm.ShowDialog();
                }
            }
            //DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    try
            //    {
            //        int result = managingSchoolService.DeleteManyExam(examIds);
            //        if (result > 0)
            //        {
            //            //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
            //            notificationForm.ShowDialog();
            //            LoadExamList();
            //        }
            //        else
            //        {
            //            //MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            NotificationForm notificationForm = new NotificationForm("Xóa không thành công", "Cảnh báo", MessageBoxIcon.Error);
            //            notificationForm.ShowDialog();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
            //        notificationForm.ShowDialog();
            //    }
            //}
            //else if (dialogResult == DialogResult.No)
            //{
            //    //no delete
            //}
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ExamDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentcheckbox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentcheckbox.Value = true;
            }
        }

        private void DeSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ExamDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = false;
            }
        }
    }
}
