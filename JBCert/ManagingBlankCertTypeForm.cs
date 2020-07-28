using Common;
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
    public partial class ManagingBlankCertTypeForm : Form
    {
        IManagingBlankCertTypeService managingBlankCertTypeService;
        public ManagingBlankCertTypeForm()
        {
            InitializeComponent();
            AddBlankCertTypeForm.OnBlankCertTypeAdded += AddBlankCertTypeForm_OnBlankCertTypeAdded;
            EditBlankCertTypeForm.OnBlankCertTypeUpdated += EditBlankCertTypeForm_OnBlankCertTypeUpdated;
            managingBlankCertTypeService = new ManagingBlankCertTypeService();
        }

        private void EditBlankCertTypeForm_OnBlankCertTypeUpdated()
        {
            LoadBlankCertTypeList();
        }

        private void AddBlankCertTypeForm_OnBlankCertTypeAdded()
        {
            LoadBlankCertTypeList();
        }

        private void ManagingBlankCertTypeForm_Load(object sender, EventArgs e)
        {
            LoadBlankCertTypeList();
        }


        private void LoadBlankCertTypeList()
        {
            List<BlankCertTypeModel> blankCertTypeModels = managingBlankCertTypeService.GetAllBlankCertType();
            BlankCertTypeDataGridView.Rows.Clear();
            int i = 1;
            foreach (var blankCertTypeModel in blankCertTypeModels)
            {
                BlankCertTypeDataGridView.Rows.Add
                (
                    blankCertTypeModel.Id,
                    false,
                    i++,
                    blankCertTypeModel.Name,
                    blankCertTypeModel.Note
                );
            }
        }

        private void BlankCertTypeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == BlankCertTypeDataGridView.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                int blankCertTypeId = int.Parse(BlankCertTypeDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                EditBlankCertTypeForm editBlankCertTypeForm = new EditBlankCertTypeForm(blankCertTypeId);
                editBlankCertTypeForm.ShowDialog();
            }
            else if (e.ColumnIndex == BlankCertTypeDataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int blankCertTypeId = int.Parse(BlankCertTypeDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                        int result = managingBlankCertTypeService.DeleteBlankCertType(blankCertTypeId);
                        if (result > 0)
                        {
                            //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                            notificationForm.ShowDialog();
                            LoadBlankCertTypeList();
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
                else if (dialogResult == DialogResult.No)
                {
                    //no delete
                }
            }
        }

        private void AddBlankCertTypeButton_Click(object sender, EventArgs e)
        {
            AddBlankCertTypeForm addBlankCertTypeForm = new AddBlankCertTypeForm();
            addBlankCertTypeForm.ShowDialog();
        }

        private void BlankCertTypeDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == BlankCertTypeDataGridView.Columns["RowCheckBox"].Index)
                {
                    DataGridViewCheckBoxCell rowCheckBox = (DataGridViewCheckBoxCell)BlankCertTypeDataGridView.Rows[e.RowIndex].Cells["RowCheckBox"];
                    if (Convert.ToBoolean(rowCheckBox.Value) == false)
                    {
                        SelectAllCheckBox.Checked = false;
                    }
                }
            }
            catch
            {

            }
        }

        private void BlankCertTypeDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (BlankCertTypeDataGridView.IsCurrentCellDirty)
            {
                BlankCertTypeDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            List<int> blankCertTypeIds = (from DataGridViewRow r in BlankCertTypeDataGridView.Rows
                                         where Convert.ToBoolean(r.Cells[1].Value) == true
                                         select Convert.ToInt32(r.Cells[0].Value)).ToList();
            try
            {
                if (blankCertTypeIds.Count == 1)
                {
                    int blankCertTypeId = blankCertTypeIds.FirstOrDefault();
                    EditBlankCertTypeForm editBlankCertTypeForm = new EditBlankCertTypeForm(blankCertTypeId);
                    editBlankCertTypeForm.ShowDialog();
                }
                else if (blankCertTypeIds.Count == 0)
                {
                    //MessageBox.Show("Bạn chưa chọn loại phôi nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Bạn chưa chọn loại phôi nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Chỉ chọn 1 loại phôi để sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Bạn chưa chọn loại phôi nào", "Cảnh báo", MessageBoxIcon.Warning);
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
            List<int> blankCertTypeIds = (from DataGridViewRow r in BlankCertTypeDataGridView.Rows
                                          where Convert.ToBoolean(r.Cells[1].Value) == true
                                          select Convert.ToInt32(r.Cells[0].Value)).ToList();
            DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            ConfirmForm confirmForm = new ConfirmForm("Đồng ý xóa ?");
            confirmForm.ShowDialog();
            if (confirmForm.Result == DialogResult.Yes)
            {
                try
                {
                    int result = managingBlankCertTypeService.DeleteManyBlankCertType(blankCertTypeIds);
                    if (result > 0)
                    {
                        //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                        notificationForm.ShowDialog();
                        LoadBlankCertTypeList();
                    }
                    else
                    {
                        //MessageBox.Show("Xóa không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Cảnh báo", MessageBoxIcon.Warning);
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

        private void SelectAllCheckBox_Click(object sender, EventArgs e)
        {
            if (SelectAllCheckBox.Checked)
            {
                foreach (DataGridViewRow row in BlankCertTypeDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                    currentCheckBox.Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in BlankCertTypeDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                    currentCheckBox.Value = false;
                }
            }
        }
    }
}
