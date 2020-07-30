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
    public partial class ManagingTownForm : Form
    {
        IManagingAdministrativeBoundariesService managingAdministrativeBoundariesService;
       
        public ManagingTownForm()
        {
            InitializeComponent();
            managingAdministrativeBoundariesService = new ManagingAdministrativeBoundariesService();

            AddTownForm.OnTownAdded += AddTownForm_OnTownAdded;
            EditTownForm.OnTownUpdated += EditTownForm_OnTownUpdated;
        }

        private void EditTownForm_OnTownUpdated()
        {
            LoadSearchedTown();
        }

        private void AddTownForm_OnTownAdded()
        {
            LoadSearchedTown();
        }

        private void ManagingTownForm_Load(object sender, EventArgs e)
        {
            LoadSearchedTown();
        }

        private void LoadSearchedTown()
        {
            string townName = string.IsNullOrEmpty(TownNameTextBox.Text) == true ? "" : TownNameTextBox.Text;
            List<TownModel> townModels = managingAdministrativeBoundariesService.GetManyTownByName(townName);
            List<TotalVillageInTownModel> totalVillageInTownModels = managingAdministrativeBoundariesService.GetTotalVillageByTownName(townName);
            List<TownModel> canNotDeleteTownModels = managingAdministrativeBoundariesService.GetAllCanNotDeleteTown();

            TownDataGridView.Rows.Clear();
            int i = 1;
            foreach (TownModel townModel in townModels)
            {
                int numberVillageInTown = 0;
                if (totalVillageInTownModels.Any(x => x.Id == townModel.Id))
                {
                    numberVillageInTown = totalVillageInTownModels.Where(x => x.Id == townModel.Id).FirstOrDefault().NumberOfVillage;
                }
                TownDataGridView.Rows.Add
                (
                    townModel.Id,
                    false,
                    i++,
                    townModel.TownName,
                    townModel.Address,
                    numberVillageInTown,
                    townModel.PhoneNumber,
                    townModel.Fax
                );
                if (canNotDeleteTownModels.Any(x => x.Id == townModel.Id))
                {
                    DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)TownDataGridView.Rows[i - 2].Cells[1];
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
                foreach (DataGridViewRow row in TownDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                    if (currentCheckBox.ReadOnly == false)
                    {
                        currentCheckBox.Value = true;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in TownDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                    currentCheckBox.Value = false;
                }
            }
        }

        private void TownDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == TownDataGridView.Columns["RowCheckBox"].Index)
                {
                    DataGridViewCheckBoxCell rowCheckBox = (DataGridViewCheckBoxCell)TownDataGridView.Rows[e.RowIndex].Cells["RowCheckBox"];
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

        private void TownDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (TownDataGridView.IsCurrentCellDirty)
            {
                TownDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadSearchedTown();
        }

        private void AddBlankCertButton_Click(object sender, EventArgs e)
        {
            AddTownForm addTownForm = new AddTownForm();
            addTownForm.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {

                List<int> townIds = new List<int>();
                townIds.Add(Convert.ToInt32(TownDataGridView.Rows[TownDataGridView.SelectedCells[0].RowIndex].Cells[0].Value));
                if (townIds.Count == 1)
                {
                    int townId = townIds.FirstOrDefault();
                    EditTownForm editTownForm = new EditTownForm(townId);
                    editTownForm.ShowDialog();
                }
                else if (townIds.Count == 0)
                {
                    //MessageBox.Show("Bạn chưa chọn trường nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Bạn chưa chọn huyện nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Chỉ chọn 1 trường để sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chỉ chọn 1 huyện để sửa", "Cảnh báo", MessageBoxIcon.Warning);
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
                List<int> townIds = (from DataGridViewRow r in TownDataGridView.Rows
                                        where Convert.ToBoolean(r.Cells[1].Value) == true
                                        select Convert.ToInt32(r.Cells[0].Value)).ToList();
                ConfirmForm confirmForm = new ConfirmForm("Bạn có chắc chắn xóa?");
                confirmForm.ShowDialog();
                if (confirmForm.Result == DialogResult.Yes)
                {
                    if (townIds.Count == 0)
                    {
                        //MessageBox.Show("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NotificationForm notificationForm = new NotificationForm("Chưa chọn huyện nào", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                        return;
                    }

                    int result = managingAdministrativeBoundariesService.DeleteManyTown(townIds);
                    if (townIds.Count > 0)
                    {
                        //MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotificationForm notificationForm = new NotificationForm("Xóa huyện thành công", "Thông báo", MessageBoxIcon.Information);
                        notificationForm.ShowDialog();
                    }
                    else
                    {
                        //MessageBox.Show("Xóa tài khoản không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NotificationForm notificationForm = new NotificationForm("Xóa huyện không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                    }
                }

                LoadSearchedTown();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }
    }
}
