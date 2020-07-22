using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class ManagingStudentForm : Form
    {
        IManagingStudentService managingStudentService;
        IManagingSchoolService managingSchoolService;
        public ManagingStudentForm()
        {
            InitializeComponent();
            managingStudentService = new ManagingStudentService();
            AddStudentForm.OnStudentAdded += AddStudentForm_OnStudentAdded;
            managingSchoolService = new ManagingSchoolService();
        }

        private void AddStudentForm_OnStudentAdded()
        {
            LoadStudentList();
        }

        private void ManagingStudentForm_Load(object sender, EventArgs e)
        {
            //Point headerCellLocation = StudentDataGridView.GetCellDisplayRectangle(0, -1, true).Location;
            ////Place the Header CheckBox in the Location of the Header Cell.
            //headerCheckBox.Location = new Point(headerCellLocation.X + 25, headerCellLocation.Y + 10);
            //headerCheckBox.BackColor = Color.White;
            //headerCheckBox.Size = new Size(18, 18);
            //headerCheckBox.Click += HeaderCheckBox_Click; ; ;
            //StudentDataGridView.Controls.Add(headerCheckBox);

            // load school 
            List<SchoolModel> schoolModels = managingSchoolService.GetAllSchool();
            schoolModels.Add(new SchoolModel()
            {
                Id = -1,
                SchoolName = "Tất cả"
            });

            SchoolComboBox.DataSource = schoolModels.OrderBy(x => x.Id).ToList();
            SchoolComboBox.DisplayMember = "SchoolName";
            SchoolComboBox.ValueMember = "Id";

            LoadStudentList();
        }

        //private void HeaderCheckBox_Click(object sender, EventArgs e)
        //{
        //    if (headerCheckBox.Checked)
        //    {
        //        foreach (DataGridViewRow row in StudentDataGridView.Rows)
        //        {
        //            DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
        //            currentCheckBox.Value = true;
        //        }
        //    }
        //    else
        //    {
        //        foreach (DataGridViewRow row in StudentDataGridView.Rows)
        //        {
        //            DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
        //            currentCheckBox.Value = false;
        //        }
        //    }

        //    StudentDataGridView.EndEdit();
        //}

        private void LoadStudentList()
        {
            List<StudentModel> studentModels = managingStudentService.GetAllStudent();
            StudentDataGridView.Rows.Clear();
            int i = 1;
            foreach (var studentModel in studentModels)
            {
                StudentDataGridView.Rows.Add
                (
                    studentModel.Id,
                    false,
                    i++,
                    studentModel.FullName,
                    studentModel.SchoolName,
                    studentModel.RankingName,
                    studentModel.EthnicName,
                    studentModel.Dob.ToString("dd/MM/yyyy"),
                    studentModel.BornedAddress,
                    studentModel.HouseHold,
                    studentModel.Score,
                    studentModel.GraduatingYear,
                    studentModel.Gender,
                    studentModel.IdentityNumber,
                    studentModel.Address
                );
            }
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.ShowDialog();
        }

        private void StudentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == StudentDataGridView.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                int studentId = int.Parse(StudentDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                EditStudentForm editBlankCertForm = new EditStudentForm(studentId);
                editBlankCertForm.ShowDialog();
            }
            else if (e.ColumnIndex == StudentDataGridView.Columns["Avatar"].Index && e.RowIndex >= 0)
            {
                try
                {
                    int studentId = int.Parse(StudentDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                    string imageName = managingStudentService.GetStudentImage(studentId);
                    if (string.IsNullOrEmpty(imageName))
                    {
                        //MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                        return;
                    }

                    string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    ShowingImageForm showingImageForm = new ShowingImageForm(Path.Combine(@"C:\JbCert_Resource\StudentImages", imageName));
                    showingImageForm.ShowDialog();
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                    notificationForm.ShowDialog();
                }
            }
            else if (e.ColumnIndex == StudentDataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int studentId = int.Parse(StudentDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                        int result = managingStudentService.DeleteStudent(studentId);
                        if (result > 0)
                        {
                            //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                            notificationForm.ShowDialog();
                            LoadStudentList();
                        }
                        else
                        {
                            //MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string fullname = "";
            int schoolId = -1;
            string identityNumber = "";
            int graduatingYear = -1;
            if (!string.IsNullOrEmpty(FullNameTextBox.Text))
            {
                fullname = FullNameTextBox.Text;
            }

            if (!string.IsNullOrEmpty(IdentityNumberTextBox.Text))
            {
                identityNumber = IdentityNumberTextBox.Text;
            }

            if (!string.IsNullOrEmpty(GreaduatingYearTextBox.Text))
            {
                try
                {
                    graduatingYear = int.Parse(GreaduatingYearTextBox.Text);
                }
                catch
                {
                    //MessageBox.Show("Điền số vào năm tốt nghiệp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NotificationForm notificationForm = new NotificationForm("Điền số vào năm tốt nghiệp", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }
            }

            schoolId = int.Parse(SchoolComboBox.SelectedValue.ToString());
            

            List<StudentModel> studentModels = managingStudentService.SearchStudent(fullname, schoolId, identityNumber, graduatingYear);
            StudentDataGridView.Rows.Clear();
            int i = 1;
            foreach (var studentModel in studentModels)
            {
                StudentDataGridView.Rows.Add
                (
                    studentModel.Id,
                    false,
                    i++,
                    studentModel.FullName,
                    studentModel.SchoolName,
                    studentModel.RankingName,
                    studentModel.EthnicName,
                    studentModel.Dob.ToString("dd/MM/yyyy"),
                    studentModel.BornedAddress,
                    studentModel.HouseHold,
                    studentModel.Score,
                    studentModel.GraduatingYear,
                    studentModel.Gender,
                    studentModel.IdentityNumber,
                    studentModel.Address
                );
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> studentIds = (from DataGridViewRow r in StudentDataGridView.Rows
                                        where Convert.ToBoolean(r.Cells[1].Value) == true
                                        select Convert.ToInt32(r.Cells[0].Value)).ToList();
                if (studentIds.Count == 1)
                {
                    int studentId = studentIds.FirstOrDefault();
                    EditStudentForm editBlankCertForm = new EditStudentForm(studentId);
                    editBlankCertForm.ShowDialog();
                }
                else if (studentIds.Count == 0)
                {
                    //MessageBox.Show("Bạn chưa chọn học sinh nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Bạn chưa chọn học sinh nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Chỉ chọn 1 học sinh để chỉnh sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chỉ chọn 1 học sinh để chỉnh sửa", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            List<int> studentIds = (from DataGridViewRow r in StudentDataGridView.Rows
                                    where Convert.ToBoolean(r.Cells[1].Value) == true
                                    select Convert.ToInt32(r.Cells[0].Value)).ToList();
            //DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    try
            //    {
            //        int result = managingStudentService.DeleteManyStudent(studentIds);
            //        if (result > 0)
            //        {
            //            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
            //            notificationForm.ShowDialog();
            //            LoadStudentList();
            //        }
            //        else
            //        {
            //            //MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            NotificationForm notificationForm = new NotificationForm("Xóa không thành công", "Cảnh báo", MessageBoxIcon.Warning);
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
            ConfirmForm confirmForm = new ConfirmForm("Đồng ý xóa ?");
            confirmForm.ShowDialog();
            if (confirmForm.Result == DialogResult.Yes)
            {
                try
                {
                    int result = managingStudentService.DeleteManyStudent(studentIds);
                    if (result > 0)
                    {
                        //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                        notificationForm.ShowDialog();
                        LoadStudentList();
                    }
                    else
                    {
                        //MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void StudentDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0 && e.ColumnIndex == StudentDataGridView.Columns["RowCheckBox"].Index)
            //    {
            //        DataGridViewCheckBoxCell rowCheckBox = (DataGridViewCheckBoxCell)StudentDataGridView.Rows[e.RowIndex].Cells["RowCheckBox"];
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

        private void StudentDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (StudentDataGridView.IsCurrentCellDirty)
            {
                StudentDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in StudentDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = true;
            }
        }

        private void DeSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in StudentDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = false;
            }
        }
    }
}
