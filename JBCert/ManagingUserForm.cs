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
    public partial class ManagingUserForm : Form
    {
        IAccountService accountService;
        public ManagingUserForm()
        {
            InitializeComponent();
            accountService = new AccountService();
            EditAccountInformationForm.OnAccountInformationUpdated += EditAccountInformationForm_OnAccountInformationUpdated;
            EditAccountRoleForm.OnAccountRoleUpdated += EditAccountRoleForm_OnAccountRoleUpdated;
        }

        private void EditAccountRoleForm_OnAccountRoleUpdated()
        {
            LoadAccountList();
        }

        private void EditAccountInformationForm_OnAccountInformationUpdated()
        {
            LoadAccountList();
        }

        private void ManagingUserForm_Load(object sender, EventArgs e)
        {
            //Point headerCellLocation = AccountDataGridView.GetCellDisplayRectangle(0, -1, true).Location;
            ////Place the Header CheckBox in the Location of the Header Cell.
            //headerCheckBox.Location = new Point(headerCellLocation.X + 25, headerCellLocation.Y + 2);
            //headerCheckBox.BackColor = Color.White;
            //headerCheckBox.Size = new Size(18, 18);
            //headerCheckBox.Click += HeaderCheckBox_Click;
            //AccountDataGridView.Controls.Add(headerCheckBox);

            // load isactive combobox
            IsActiveComboBox.Items.Add("Tất cả");
            IsActiveComboBox.Items.Add("Đang hoạt động");
            IsActiveComboBox.Items.Add("Đang khóa");
            IsActiveComboBox.SelectedIndex = 0;

            LoadAccountList();
        }

        //private void HeaderCheckBox_Click(object sender, EventArgs e)
        //{
        //    if (headerCheckBox.Checked)
        //    {
        //        foreach (DataGridViewRow row in AccountDataGridView.Rows)
        //        {
        //            DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
        //            currentCheckBox.Value = true;
        //        }
        //    }
        //    else
        //    {
        //        foreach (DataGridViewRow row in AccountDataGridView.Rows)
        //        {
        //            DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
        //            currentCheckBox.Value = false;
        //        }
        //    }

        //    AccountDataGridView.EndEdit();
        //}

        private void LoadAccountList()
        {
            try
            {
                List<AccountModel> accountModels = accountService.GetAllAccount();
                AccountDataGridView.Rows.Clear();
                int i = 1;
                foreach(var accountModel in accountModels)
                {
                    if (accountModel.Username == "Admin")
                    {
                        continue;
                    }
                    string roles = "";
                    if (accountModel.RoleModels != null)
                    {
                        foreach (var roleModel in accountModel.RoleModels)
                        {
                            if (roleModel.Id == accountModel.RoleModels.LastOrDefault().Id)
                            {
                                roles += roleModel.RoleDescription;
                            }
                            else
                            {
                                roles += roleModel.RoleDescription + Environment.NewLine;
                            }
                        }
                    }
                    AccountDataGridView.Rows.Add
                    (
                        accountModel.Id,
                        false,
                        i++,
                        accountModel.Username,
                        accountModel.Email,
                        accountModel.PhoneNumber,
                        roles,
                        accountModel.IsActive == true ? "Đang kích hoạt" : "Đang khóa"
                    ) ;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void AccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void AccountDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0 && e.ColumnIndex == AccountDataGridView.Columns["RowCheckBox"].Index)
            //    {
            //        DataGridViewCheckBoxCell rowCheckBox = (DataGridViewCheckBoxCell)AccountDataGridView.Rows[e.RowIndex].Cells["RowCheckBox"];
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

        private void AccountDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (AccountDataGridView.IsCurrentCellDirty)
            {
                AccountDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void UpdateInformationButton_Click(object sender, EventArgs e)
        {
            List<int> accountIds = (from DataGridViewRow r in AccountDataGridView.Rows
                                    where Convert.ToBoolean(r.Cells[1].Value) == true
                                    select Convert.ToInt32(r.Cells[0].Value)).ToList();
            if (accountIds.Count == 1)
            {
                EditAccountInformationForm editAccountInformationForm = new EditAccountInformationForm(accountIds.FirstOrDefault());
                editAccountInformationForm.ShowDialog();
            }
            else if (accountIds.Count == 0)
            {
                //MessageBox.Show("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
            else
            {
                //MessageBox.Show("Chỉ được chọn 1 tài khoản", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Chỉ được chọn 1 tài khoản", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
        }

        private void RoleButton_Click(object sender, EventArgs e)
        {
            List<int> accountIds = (from DataGridViewRow r in AccountDataGridView.Rows
                                    where Convert.ToBoolean(r.Cells[1].Value) == true
                                    select Convert.ToInt32(r.Cells[0].Value)).ToList();
            if (accountIds.Count == 0)
            {
                //MessageBox.Show("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }
            EditAccountRoleForm editAccountRoleForm = new EditAccountRoleForm(accountIds);
            editAccountRoleForm.ShowDialog();
        }

        private void LockButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> accountIds = (from DataGridViewRow r in AccountDataGridView.Rows
                                        where Convert.ToBoolean(r.Cells[1].Value) == true
                                        select Convert.ToInt32(r.Cells[0].Value)).ToList();

                if (accountIds.Count == 0)
                {
                    //MessageBox.Show("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                int result = accountService.LockManyAccount(accountIds);
                ConfirmForm confirmForm = new ConfirmForm("Đồng ý xóa ?");
                confirmForm.ShowDialog();
                if (confirmForm.Result == DialogResult.Yes)
                {
                    try
                    {
                        if (accountIds.Count > 0)
                        {
                            //MessageBox.Show("Khóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NotificationForm notificationForm = new NotificationForm("Khóa tài khoản thành công", "Thông báo", MessageBoxIcon.Information);
                            notificationForm.ShowDialog();
                        }
                        else
                        {
                            //MessageBox.Show("Khóa tài khoản không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            NotificationForm notificationForm = new NotificationForm("Khóa tài khoản không thành công", "Thông báo", MessageBoxIcon.Warning);
                            notificationForm.ShowDialog();
                        }
                    }
                    catch(Exception ex)
                    {
                        NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                    }
                }
               

                LoadAccountList();
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
            try
            {
                List<int> accountIds = (from DataGridViewRow r in AccountDataGridView.Rows
                                        where Convert.ToBoolean(r.Cells[1].Value) == true
                                        select Convert.ToInt32(r.Cells[0].Value)).ToList();

                if (accountIds.Count == 0)
                {
                    //MessageBox.Show("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                int result = accountService.DeleteManyAccount(accountIds);
                if (accountIds.Count > 0)
                {
                    //MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Xóa tài khoản thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Xóa tài khoản không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Xóa tài khoản không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }

                LoadAccountList();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void LoadSearchedAccountList()
        {
            try
            {
                string username = "";
                string email = "";
                string phoneNumber = "";
                int isActive = -1;

                if (!string.IsNullOrEmpty(UsernameTextBox.Text))
                {
                    username = UsernameTextBox.Text;
                }

                if (!string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    email = EmailTextBox.Text;
                }

                if (!string.IsNullOrEmpty(PhoneNumberTextBox.Text))
                {
                    phoneNumber = PhoneNumberTextBox.Text;
                }

                switch (IsActiveComboBox.SelectedIndex)
                {
                    case 0:
                        isActive = -1;
                        break;
                    case 1:
                        isActive = 1;
                        break;
                    case 2:
                        isActive = 0;
                        break;
                }

                List<AccountModel> accountModels = accountService.SearchAccount(username, email, phoneNumber, isActive);
                AccountDataGridView.Rows.Clear();
                int i = 1;
                foreach (var accountModel in accountModels)
                {
                    if (accountModel.Username == "Admin")
                    {
                        continue;
                    }
                    string roles = "";
                    foreach (var roleModel in accountModel.RoleModels)
                    {
                        if(roleModel.Id == accountModel.RoleModels.LastOrDefault().Id)
                        {
                            roles += roleModel.RoleDescription;
                        }
                        else
                        {
                            roles += roleModel.RoleDescription + Environment.NewLine;
                        }
                    }
                    AccountDataGridView.Rows.Add
                    (
                        accountModel.Id,
                        false,
                        i++,
                        accountModel.Username,
                        accountModel.Email,
                        accountModel.PhoneNumber,
                        roles,
                        accountModel.IsActive == true ? "Đang kích hoạt" : "Đang khóa"
                    );
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadSearchedAccountList();
        }

        private void ActiveButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> accountIds = (from DataGridViewRow r in AccountDataGridView.Rows
                                        where Convert.ToBoolean(r.Cells[1].Value) == true
                                        select Convert.ToInt32(r.Cells[0].Value)).ToList();

                if (accountIds.Count == 0)
                {
                    //MessageBox.Show("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chưa chọn tài khoản nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                int result = accountService.ActiveManyAccount(accountIds);
                if (accountIds.Count > 0)
                {
                    //MessageBox.Show("Kích hoạt tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Kích hoạt tài khoản thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Kích hoạt tài khoản không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Kích hoạt tài khoản không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }

                LoadAccountList();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            CreateAccountForm createAccountForm = new CreateAccountForm();
            createAccountForm.ShowDialog();
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in AccountDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = true;
            }
        }

        private void DeSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in AccountDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = false;
            }
        }
    }
}
