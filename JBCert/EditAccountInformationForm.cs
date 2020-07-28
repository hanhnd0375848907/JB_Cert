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
    public partial class EditAccountInformationForm : Form
    {
        int _accountId;
        IAccountService accountService;

        public delegate void UpdateAccountInformation();
        public static event UpdateAccountInformation OnAccountInformationUpdated;
        public EditAccountInformationForm(int accountId)
        {
            InitializeComponent();
            _accountId = accountId;
            accountService = new AccountService();
            OnAccountInformationUpdated += EditAccountInformationForm_OnAccountInformationUpdated;
        }

        private void EditAccountInformationForm_OnAccountInformationUpdated()
        {
        }

        private void EditAccountInformationForm_Load(object sender, EventArgs e)
        {
            AccountModel accountModel = accountService.GetSingleAccountById(_accountId);
            UsernameTextBox.Text = accountModel.Username;
            EmailTextBox.Text = accountModel.Email;
            PhoneNumberTextBox.Text = accountModel.PhoneNumber;
            IsActiveCheckBox.Checked = !accountModel.IsActive;

            // load roles of account
            List<RoleModel> roleModels = accountService.GetAllRole();
            List<RoleModel> rolesOfCurrentAccount = accountService.GetAllRoleByAccountId(_accountId);
            RoleCheckedListBox.Items.Clear();
            foreach (RoleModel roleModel in roleModels)
            {
                RoleCheckedListBox.Items.Add
                (
                    roleModel,
                    rolesOfCurrentAccount.Any(x => x.Id == roleModel.Id)
                );
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(PhoneNumberTextBox.Text);
            }
            catch (FormatException ex)
            {
                //MessageBox.Show("Số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Số điện thoại", "Thông báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            if (string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                //MessageBox.Show("Điền tên đăng nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Điền tên đăng nhập", "Thông báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }
            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                //MessageBox.Show("Điền Email", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Điền Email", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }
            if (string.IsNullOrEmpty(PhoneNumberTextBox.Text))
            {
                //MessageBox.Show("Điền số điện thoại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);\
                NotificationForm notificationForm = new NotificationForm("Điền số điện thoại", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }


            AccountModel accountModel = new AccountModel();
            accountModel.Id = _accountId;
            accountModel.Username = UsernameTextBox.Text;
            accountModel.Email = EmailTextBox.Text;
            accountModel.PhoneNumber = PhoneNumberTextBox.Text;
            accountModel.IsActive = !IsActiveCheckBox.Checked;
            try
            {
                int result = accountService.UpdateAccountInformation(accountModel);

                List<int> roleIds = (from RoleModel r in RoleCheckedListBox.CheckedItems
                                     select r.Id).ToList();

                 result += accountService.UpdateAccountRole(new List<int>() { _accountId }, roleIds);

                if (result >= 1)
                {
                    //MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    OnAccountInformationUpdated();
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("Cập nhật không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật không thành công", "Cảnh báo", MessageBoxIcon.Warning);
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
