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
    public partial class ManagingSchoolForm : Form
    {
        IManagingSchoolService managingSchoolService;
        public ManagingSchoolForm()
        {
            InitializeComponent();
            managingSchoolService = new ManagingSchoolService();
            AddSchoolForm.OnSchoolAdded += AddSchoolForm_OnSchoolAdded;
            EditSchoolForm.OnSchoolUpdated += EditSchoolForm_OnSchoolUpdated;
        }

        private void EditSchoolForm_OnSchoolUpdated()
        {
            LoadSchool();
        }

        private void AddSchoolForm_OnSchoolAdded()
        {
            LoadSchool();
        }

        private void LoadSchool()
        {
            int i = 1;
            List<SchoolModel> schoolModels = managingSchoolService.GetAllSchool();
            SchoolDataGridView.Rows.Clear();
            foreach (var schoolModel in schoolModels)
            {
                SchoolDataGridView.Rows.Add
                (
                    schoolModel.Id,
                    false,
                    i++,
                    schoolModel.SchoolName,
                    schoolModel.Representative,
                    schoolModel.Province,
                    schoolModel.VillageName,
                    schoolModel.TownName,
                    schoolModel.Address,
                    schoolModel.PhoneNumber,
                    schoolModel.Fax,
                    schoolModel.BlankCertTypeName,
                    schoolModel.Note
                );
            }
        }

        private void ManagingSchoolForm_Load(object sender, EventArgs e)
        {
            //Point headerCellLocation = SchoolDataGridView.GetCellDisplayRectangle(0, -1, true).Location;
            ////Place the Header CheckBox in the Location of the Header Cell.
            //headerCheckBox.Location = new Point(headerCellLocation.X + 25, headerCellLocation.Y + 2);
            //headerCheckBox.BackColor = Color.White;
            //headerCheckBox.Size = new Size(18, 18);
            //headerCheckBox.Click += HeaderCheckBox_Click; ;
            //SchoolDataGridView.Controls.Add(headerCheckBox);

            // load town
            List<TownModel> townModels = managingSchoolService.GetAllTown();
            townModels.Add(new TownModel()
            {
                Id = -1,
                TownName = "Tất cả"
            });
            TownComboBox.DataSource = townModels.OrderBy(x => x.Id).ToList();
            TownComboBox.DisplayMember = "TownName";
            TownComboBox.ValueMember = "Id";
            TownComboBox.SelectedIndex = 0;
            
            // load village
            List<VillageModel> villageModels = managingSchoolService.GetAllVillage();
            villageModels.Add(new VillageModel()
            {
                Id = -1,
                VillageName = "Tất cả"
            });
            VillageComboBox.DataSource = villageModels.OrderBy(x => x.Id).ToList();
            VillageComboBox.DisplayMember = "VillageName";
            VillageComboBox.ValueMember = "Id";
            VillageComboBox.SelectedIndex = 0;


            LoadSchool();
        }

        //private void HeaderCheckBox_Click(object sender, EventArgs e)
        //{
        //    if (headerCheckBox.Checked)
        //    {
        //        foreach (DataGridViewRow row in SchoolDataGridView.Rows)
        //        {
        //            DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
        //            currentCheckBox.Value = true;
        //        }
        //    }
        //    else
        //    {
        //        foreach (DataGridViewRow row in SchoolDataGridView.Rows)
        //        {
        //            DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
        //            currentCheckBox.Value = false;
        //        }
        //    }

        //    SchoolDataGridView.EndEdit();

        //}

        private void AddSchoolButton_Click(object sender, EventArgs e)
        {
            AddSchoolForm addSchoolForm = new AddSchoolForm();
            addSchoolForm.ShowDialog();
        }

        private void SchoolDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == SchoolDataGridView.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                int schoolId = int.Parse(SchoolDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                EditSchoolForm editBlankCertForm = new EditSchoolForm(schoolId);
                editBlankCertForm.ShowDialog();
            }
            else if (e.ColumnIndex == SchoolDataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int schoolId = int.Parse(SchoolDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                        int result = managingSchoolService.DeleteSchool(schoolId);
                        if (result > 0)
                        {
                            //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                            notificationForm.ShowDialog();
                            LoadSchool();
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
            try
            {
                string schoolName = "";
                int townId = -1;
                int villageId = -1;
                string phoneNumber = "";

                if (!string.IsNullOrEmpty(SchoolNameTextBox.Text))
                {
                    schoolName = SchoolNameTextBox.Text;
                }

                if (!string.IsNullOrEmpty(PhoneNumberTextBox.Text))
                {
                    phoneNumber = PhoneNumberTextBox.Text;
                }

                townId = int.Parse(TownComboBox.SelectedValue.ToString());
                villageId = int.Parse(VillageComboBox.SelectedValue.ToString());

                List<SchoolModel> schoolModels = managingSchoolService.SearchSchool(schoolName, townId, villageId, phoneNumber);
                SchoolDataGridView.Rows.Clear();
                int i = 1;
                foreach (var schoolModel in schoolModels)
                {
                    SchoolDataGridView.Rows.Add
                    (
                        schoolModel.Id,
                        false,
                        i++,
                        schoolModel.SchoolName,
                        schoolModel.Representative,
                        schoolModel.Province,
                        schoolModel.VillageName,
                        schoolModel.TownName,
                        schoolModel.Address,
                        schoolModel.PhoneNumber,
                        schoolModel.Fax,
                        schoolModel.BlankCertTypeName,
                        schoolModel.Note
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

        private void TownComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int townId = int.Parse(TownComboBox.SelectedValue.ToString());
                List<VillageModel> villageModels = managingSchoolService.GetAllVillageByTownId(townId);
                villageModels.Add(new VillageModel()
                {
                    Id = -1,
                    VillageName = "Tất cả"
                });
                VillageComboBox.DataSource = villageModels.OrderBy(x => x.Id).ToList();
                VillageComboBox.DisplayMember = "VillageName";
                VillageComboBox.ValueMember = "Id";
                VillageComboBox.SelectedIndex = 0;
            }
            catch
            {
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> schoolIds = (from DataGridViewRow r in SchoolDataGridView.Rows
                                       where Convert.ToBoolean(r.Cells[1].Value) == true
                                       select Convert.ToInt32(r.Cells[0].Value)).ToList();
                if (schoolIds.Count == 1)
                {
                    int schoolId = schoolIds.FirstOrDefault();
                    EditSchoolForm editBlankCertForm = new EditSchoolForm(schoolId);
                    editBlankCertForm.ShowDialog();
                }
                else if (schoolIds.Count == 0)
                {
                    //MessageBox.Show("Bạn chưa chọn trường nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Bạn chưa chọn trường nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Chỉ chọn 1 trường để sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chỉ chọn 1 trường để sửa", "Cảnh báo", MessageBoxIcon.Warning);
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
                List<int> schoolIds = (from DataGridViewRow r in SchoolDataGridView.Rows
                                       where Convert.ToBoolean(r.Cells[1].Value) == true
                                       select Convert.ToInt32(r.Cells[0].Value)).ToList();

                if (schoolIds.Count == 0)
                {
                    //MessageBox.Show("Bạn chưa chọn trường nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Bạn chưa chọn trường nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (dialogResult == DialogResult.Yes)
                    //{
                    //    try
                    //    {
                    //        int result = managingSchoolService.DeleteManySchool(schoolIds);
                    //        if (result > 0)
                    //        {
                    //            //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                    //            notificationForm.ShowDialog();
                    //            LoadSchool();
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
                            int result = managingSchoolService.DeleteManySchool(schoolIds);
                            if (result > 0)
                            {
                                //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                                notificationForm.ShowDialog();
                                LoadSchool();
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
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void SchoolDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0 && e.ColumnIndex == SchoolDataGridView.Columns["RowCheckBox"].Index)
            //    {
            //        DataGridViewCheckBoxCell rowCheckBox = (DataGridViewCheckBoxCell)SchoolDataGridView.Rows[e.RowIndex].Cells["RowCheckBox"];
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

        private void SchoolDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (SchoolDataGridView.IsCurrentCellDirty)
            {
                SchoolDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in SchoolDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = true;
            }
        }

        private void DeSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in SchoolDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
