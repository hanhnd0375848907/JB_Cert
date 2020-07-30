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
    public partial class ManagingVillageForm : Form
    {
        IManagingAdministrativeBoundariesService managingAdministrativeBoundariesService;
        public ManagingVillageForm()
        {
            InitializeComponent();
            managingAdministrativeBoundariesService = new ManagingAdministrativeBoundariesService();
            AddVillageForm.OnVillageAdded += AddVillageForm_OnVillageAdded;
            EditVillageForm.OnVillageUpdated += EditVillageForm_OnVillageUpdated;
        }

        private void EditVillageForm_OnVillageUpdated()
        {
            LoadSearchedVillage();
        }

        private void AddVillageForm_OnVillageAdded()
        {
            LoadSearchedVillage();
        }

        private void ManagingVillageForm_Load(object sender, EventArgs e)
        {
            // load towncombobox
            List<TownModel> townModels = managingAdministrativeBoundariesService.GetAllTown();
            townModels.Add(new TownModel()
            {
                Id = -1,
                TownName = "Tất cả"
            });

            TownComboBox.DataSource = townModels.OrderBy(x => x.Id).ToList();
            TownComboBox.DisplayMember = "TownName";
            TownComboBox.ValueMember = "Id";
            TownComboBox.SelectedIndex = 0;

            // load villages
            LoadSearchedVillage();

        }

        private void LoadSearchedVillage()
        {
            if (TownComboBox.SelectedValue == null)
            {
                NotificationForm notificationForm = new NotificationForm("Chọn huyện", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            string villageName = string.IsNullOrEmpty(VillageNameTextBox.Text) ? "" : VillageNameTextBox.Text;
            int townId = int.Parse(TownComboBox.SelectedValue.ToString());

            List<VillageModel> villageModels = managingAdministrativeBoundariesService.GetManyVillageByVillageNameAndTownId(villageName, townId);
            List<VillageModel> canDeleteVillageModels = managingAdministrativeBoundariesService.GetAllCanDeleteVillage();
            VillageDataGridView.Rows.Clear();
            int i = 1;
            foreach (VillageModel villageModel in villageModels)
            {
                VillageDataGridView.Rows.Add
                (
                    villageModel.Id,
                    false,
                    i++,
                    villageModel.VillageName,
                    villageModel.TownName,
                    villageModel.Address,
                    villageModel.PhoneNumber,
                    villageModel.Fax
                );
                if (!canDeleteVillageModels.Any(x => x.Id == villageModel.Id))
                {
                    DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)VillageDataGridView.Rows[i - 2].Cells[1];
                    checkBoxCell.Value = false;
                    checkBoxCell.FlatStyle = FlatStyle.Flat;
                    checkBoxCell.Style.ForeColor = Color.DarkGray;
                    checkBoxCell.ReadOnly = true;
                }
            }
        }

        private void SelectAllCheckBox_Click(object sender, EventArgs e)
        {
            if (SelectAllCheckBox.Checked)
            {
                foreach (DataGridViewRow row in VillageDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                    if(currentCheckBox.ReadOnly == false)
                    {
                        currentCheckBox.Value = true;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in VillageDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                    currentCheckBox.Value = false;
                }
            }
        }

        private void VillageDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == VillageDataGridView.Columns["RowCheckBox"].Index)
                {
                    DataGridViewCheckBoxCell rowCheckBox = (DataGridViewCheckBoxCell)VillageDataGridView.Rows[e.RowIndex].Cells["RowCheckBox"];
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

        private void VillageDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (VillageDataGridView.IsCurrentCellDirty)
            {
                VillageDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {

                List<int> villageIds = new List<int>();
                villageIds.Add(Convert.ToInt32(VillageDataGridView.Rows[VillageDataGridView.SelectedCells[0].RowIndex].Cells[0].Value));
                if (villageIds.Count == 1)
                {
                    int villageId = villageIds.FirstOrDefault();
                    EditVillageForm editVillageForm = new EditVillageForm(villageId);
                    editVillageForm.ShowDialog();
                }
                else if (villageIds.Count == 0)
                {
                    //MessageBox.Show("Bạn chưa chọn trường nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Bạn chưa chọn xã nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Chỉ chọn 1 trường để sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chỉ chọn 1 xã để sửa", "Cảnh báo", MessageBoxIcon.Warning);
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
            try
            {
                ConfirmForm confirmForm = new ConfirmForm("Bạn có chắc chắn xóa?");
                confirmForm.ShowDialog();
                if (confirmForm.Result == DialogResult.Yes)
                {
                    List<int> villageIds = (from DataGridViewRow r in VillageDataGridView.Rows
                                            where Convert.ToBoolean(r.Cells[1].Value) == true
                                            select Convert.ToInt32(r.Cells[0].Value)).ToList();

                    if (villageIds.Count == 0)
                    {
                        //MessageBox.Show("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NotificationForm notificationForm = new NotificationForm("Chưa chọn xã nào", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                        return;
                    }

                    int result = managingAdministrativeBoundariesService.DeleteManyVillage(villageIds);
                    if (villageIds.Count > 0)
                    {
                        //MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotificationForm notificationForm = new NotificationForm("Xóa xã thành công", "Thông báo", MessageBoxIcon.Information);
                        notificationForm.ShowDialog();
                    }
                    else
                    {
                        //MessageBox.Show("Xóa tài khoản không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NotificationForm notificationForm = new NotificationForm("Xóa xã không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                    }
                }

                LoadSearchedVillage();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddVillageForm addVillageForm = new AddVillageForm();
            addVillageForm.ShowDialog();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadSearchedVillage();
        }
    }
}
