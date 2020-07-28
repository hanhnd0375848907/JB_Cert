using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{

    public partial class ManagingBlankCertForm : Form
    {
        IManagingBlankCertService managingBlankCertService;
        IManagingBlankCertTypeService managingBlankCertTypeService;

        public ManagingBlankCertForm()
        {
            InitializeComponent();
            AddBlankCertForm.OnBlankCertAdded += AddBlankCertForm_OnBlankCertAdded;
            EditBlankCertForm.OnBlankCertUpdated += EditBlankCertForm_OnBlankCertUpdated;
            managingBlankCertService = new ManagingBlankCertService();
            managingBlankCertTypeService = new ManagingBlankCertTypeService();
        }

        private void EditBlankCertForm_OnBlankCertUpdated()
        {
            LoadListBlankCert();
        }

        private void AddBlankCertForm_OnBlankCertAdded()
        {
            LoadListBlankCert();
        }

        private void LoadListBlankCert()
        {
            try
            {
                List<BlankCertModel> blankCertModels = managingBlankCertService.GetAllBlankCert();
                int i = 1;
                BlankCertDataGridView.Rows.Clear();
                foreach (var blankCertModel in blankCertModels)
                {
                    BlankCertDataGridView.Rows.Add
                    (
                        blankCertModel.Id,
                        false,
                        i++,
                        blankCertModel.Serial,
                        blankCertModel.IsAvailable == true ? "Khả dụng" : "Không thể sử dụng",
                        blankCertModel.IsReturned == true ? "Đã thu hồi" : "Không thu hồi",
                        blankCertModel.CreatedAt,
                        blankCertModel.BlankCertTypeName,
                        blankCertModel.UpdatedAt.ToString("dd/MM/yyyy")
                    );
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
        }

        private void ManagingBlankCertForm_Load(object sender, EventArgs e)
        {

            LoadListBlankCert();

            // load blank cert type
            List<BlankCertTypeModel> blankCertTypeModels = managingBlankCertTypeService.GetAllBlankCertType();
            blankCertTypeModels.Add(new BlankCertTypeModel()
            {
                Id = -1,
                Name = "Tất cả"
            });
            BlankCertTypeComboBox.DataSource = blankCertTypeModels.OrderBy(x => x.Id).ToList();
            BlankCertTypeComboBox.DisplayMember = "Name";
            BlankCertTypeComboBox.ValueMember = "Id";

            // load status
            StatusComboBox.Items.Add("Tất cả");     // 0
            StatusComboBox.Items.Add("Khả dụng");   // 1
            StatusComboBox.Items.Add("Thu hồi");    // 2
            StatusComboBox.Items.Add("Đã dùng");    // 3
            StatusComboBox.SelectedIndex = 0;
        }

        private void AddBlankCertButton_Click(object sender, EventArgs e)
        {
            AddBlankCertForm addBlankCertForm = new AddBlankCertForm();
            addBlankCertForm.ShowDialog();
        }

        private void BlankCertDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == BlankCertDataGridView.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                int certId = int.Parse(BlankCertDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                EditBlankCertForm editBlankCertForm = new EditBlankCertForm(certId);
                editBlankCertForm.ShowDialog();
            }
            else if (e.ColumnIndex == BlankCertDataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int certId = int.Parse(BlankCertDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                        int result = managingBlankCertService.Delete(certId);
                        if (result > 0)
                        {
                            //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                            notificationForm.ShowDialog();
                            LoadListBlankCert();
                        }
                        else
                        {
                            //MessageBox.Show("Xóa không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void SeachButton_Click(object sender, EventArgs e)
        {
            string serial = "";
            int blankCertTypeId = -1;
            int status = 0;
            try
            {
                if (!string.IsNullOrEmpty(SerialTextBox.Text))
                {
                    serial = SerialTextBox.Text;
                }

                if(BlankCertTypeComboBox.SelectedValue == null)
                {
                    NotificationForm notificationForm = new NotificationForm("Loại bằng không tồn tại", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (StatusComboBox.SelectedItem == null)
                {
                    NotificationForm notificationForm = new NotificationForm("Trạng thái không tồn tại", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                blankCertTypeId = int.Parse(BlankCertTypeComboBox.SelectedValue.ToString());
                status = StatusComboBox.SelectedIndex;

                List<BlankCertModel> blankCertModels = managingBlankCertService.SearchBlankCert(serial, blankCertTypeId, status);
                int i = 1;
                BlankCertDataGridView.Rows.Clear();
                foreach (var blankCertModel in blankCertModels)
                {
                    BlankCertDataGridView.Rows.Add
                    (
                        blankCertModel.Id,
                        false,
                        i++,
                        blankCertModel.Serial,
                        blankCertModel.IsAvailable == true ? "Khả dụng" : "Không thể sử dụng",
                        blankCertModel.IsReturned == true ? "Đã thu hồi" : "Không thu hồi",
                        blankCertModel.CreatedAt,
                        blankCertModel.BlankCertTypeName,
                        blankCertModel.UpdatedAt.ToString("dd/MM/yyyy")
                    );
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                //List<int> blankCertIds = (from DataGridViewRow r in BlankCertDataGridView.Rows
                //                          where Convert.ToBoolean(r.Cells[1].Value) == true
                //                          select Convert.ToInt32(r.Cells[0].Value)).ToList();
                List<int> blankCertIds = new List<int>();
                blankCertIds.Add(Convert.ToInt32(BlankCertDataGridView.Rows[BlankCertDataGridView.SelectedCells[0].RowIndex].Cells[0].Value));
                if (blankCertIds.Count == 1)
                {
                    int blankCertId = blankCertIds.FirstOrDefault();
                    EditBlankCertForm editBlankCertForm = new EditBlankCertForm(blankCertId);
                    editBlankCertForm.ShowDialog();
                }
                else if (blankCertIds.Count == 0)
                {
                    //MessageBox.Show("Bạn chưa chọn phôi nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Bạn chưa chọn phôi nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Chỉ được chọn 1 phôi để sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chỉ được chọn 1 phôi để sửa", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> blankCertIds = (from DataGridViewRow r in BlankCertDataGridView.Rows
                                          where Convert.ToBoolean(r.Cells[1].Value) == true
                                          select Convert.ToInt32(r.Cells[0].Value)).ToList();
                if (blankCertIds.Count == 0)
                {
                    //MessageBox.Show("Bạn chưa chọn phôi nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Bạn chưa chọn phôi nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                ConfirmForm confirmForm = new ConfirmForm("Đồng ý xóa ?");
                confirmForm.ShowDialog();
                if (confirmForm.Result == DialogResult.Yes)
                {
                    try
                    {
                        int result = managingBlankCertService.DeleteManyBlankCert(blankCertIds);
                        if (result > 0)
                        {
                            //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                            notificationForm.ShowDialog();
                            LoadListBlankCert();
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
                        NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                    }
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }

        }

        private void BlankCertDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (BlankCertDataGridView.IsCurrentCellDirty)
            {
                BlankCertDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void BlankCertDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == BlankCertDataGridView.Columns["RowCheckBox"].Index)
                {
                    DataGridViewCheckBoxCell rowCheckBox = (DataGridViewCheckBoxCell)BlankCertDataGridView.Rows[e.RowIndex].Cells["RowCheckBox"];
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

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BlankCertDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = true;
            }
        }

        private void DeSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in BlankCertDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = false;
            }
        }

        private void SelectAllCheckBox_Click(object sender, EventArgs e)
        {
            if (SelectAllCheckBox.Checked)
            {
                foreach (DataGridViewRow row in BlankCertDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                    currentCheckBox.Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in BlankCertDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                    currentCheckBox.Value = false;
                }
            }
        }
    }
}
