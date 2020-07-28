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
    public partial class EditAccountRoleForm : Form
    {
        List<int> _accountIds;
        IAccountService accountService;

        public delegate void UpdateAccountRole();
        public static event UpdateAccountRole OnAccountRoleUpdated;
        public EditAccountRoleForm(List<int> accountIds)
        {
            InitializeComponent();
            _accountIds = accountIds;
            accountService = new AccountService();
            OnAccountRoleUpdated += EditAccountRoleForm_OnAccountRoleUpdated;
        }

        private void EditAccountRoleForm_OnAccountRoleUpdated()
        {
        }

        private void EditAccountRoleForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<RoleModel> roleModels = accountService.GetAllRole();
                if (_accountIds.Count == 1)
                {
                    List<RoleModel> rolesOfCurrentAccount = accountService.GetAllRoleByAccountId(_accountIds.FirstOrDefault());
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
                else
                {
                    RoleCheckedListBox.Items.Clear();
                    foreach (RoleModel roleModel in roleModels)
                    {
                        RoleCheckedListBox.Items.Add
                        (
                            roleModel,
                            false
                        );
                    }
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

        private void SaveButton_Click(object sender, EventArgs e)
        {

            try
            {
                List<int> roleIds = (from RoleModel r in RoleCheckedListBox.CheckedItems
                                     select r.Id).ToList();

                int result = accountService.UpdateAccountRole(_accountIds, roleIds);
                if(result > 0)
                {
                    //MessageBox.Show("Cập nhật quyền tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật quyền tài khoản thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    OnAccountRoleUpdated();
                }
                else
                {
                    //MessageBox.Show("Cập nhật quyền tài khoản không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật quyền tài khoản không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                var a = ex.Message;
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }
    }
}
