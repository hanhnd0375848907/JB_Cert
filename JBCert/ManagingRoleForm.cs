using Common;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class ManagingRoleForm : Form
    {
        IAccountService accountService;
        public ManagingRoleForm()
        {
            InitializeComponent();
            accountService = new AccountService();
        }

        private void ManagingRoleForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(230, 235, 252);

            // load all role
            LoadRoleList();

            // load all permission
            LoadPermissionList();
        }

        private void LoadRoleList()
        {
            try
            {
                List<RoleModel> roleModels = accountService.GetAllRole();
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
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void LoadPermissionList()
        {
            try
            {
                List<ClaimModel> ClaimModels = accountService.GetAllPermission();
                PermissionCheckedListBox.Items.Clear();
                foreach (ClaimModel claimModel in ClaimModels)
                {
                    PermissionCheckedListBox.Items.Add
                    (
                        claimModel,
                        false
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RoleNameTextBox.Text))
            {
                //MessageBox.Show("Điền tên quyền", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Điền tên vai trò", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            RoleModel roleModel = new RoleModel();
            roleModel.RoleDescription = RoleNameTextBox.Text;
            roleModel.RoleName = Regex.Replace(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextHelper.ConvertToUnsign(RoleNameTextBox.Text)), @"\s+", "");
            roleModel.ClaimModels = new List<ClaimModel>();

            foreach (ClaimModel itemChecked in PermissionCheckedListBox.CheckedItems)
            {
                roleModel.ClaimModels.Add(itemChecked);
            }

            try
            {
                int result = accountService.AddRole(roleModel);
                if (result > 0)
                {
                    //MessageBox.Show("Thêm quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Thêm vai trò thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Thêm quyền không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Thêm vai trò không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                LoadRoleList();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> roleIds = (from RoleModel r in RoleCheckedListBox.CheckedItems
                                     select r.Id).ToList();
                List<int> claimIds = (from ClaimModel c in PermissionCheckedListBox.CheckedItems
                                                select c.Id).ToList();
                if (roleIds.Count > 0)
                {
                    int result = accountService.UpdateManyRole(roleIds, claimIds);
                    if (result > 0)
                    {
                        //MessageBox.Show("Cập nhật quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotificationForm notificationForm = new NotificationForm("Cập nhật vai trò thành công", "Thông báo", MessageBoxIcon.Information);
                        notificationForm.ShowDialog();
                    }
                    else
                    {
                        //MessageBox.Show("Cập nhật quyền không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NotificationForm notificationForm = new NotificationForm("Cập nhật vai trò không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                    }
                    LoadRoleList();
                    LoadPermissionList();
                }
                else
                {
                    //MessageBox.Show("Chưa chọn quyền nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chưa chọn vai trò nào", "Cảnh báo", MessageBoxIcon.Warning);
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
                List<int> roleIds = (from RoleModel r in RoleCheckedListBox.CheckedItems
                                     select r.Id).ToList();
                if (roleIds.Count == 0)
                {
                    NotificationForm notification = new NotificationForm("Vui lòng chọn 1 hoặc nhiều vai trò để xóa", "Cảnh báo", MessageBoxIcon.Warning);
                    notification.ShowDialog();
                    return;
                }
                ConfirmForm confirmForm = new ConfirmForm("Xóa vai trò có thể ảnh hưởng đến quyền truy cập các tài khoản ,Bạn có đồng ý xóa");
                confirmForm.ShowDialog();
                if (confirmForm.Result == DialogResult.Yes)
                {
                    if (roleIds.Count > 0)
                    {
                        int result = accountService.DeleteManyRole(roleIds);
                        if (result > 0)
                        {
                            //MessageBox.Show("Xóa quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NotificationForm notificationForm = new NotificationForm("Xóa vai trò thành công", "Thông báo", MessageBoxIcon.Information);
                            notificationForm.ShowDialog();
                        }
                        else
                        {
                            //MessageBox.Show("Xóa quyền không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            NotificationForm notificationForm = new NotificationForm("Xóa vai trò không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                            notificationForm.ShowDialog();
                        }
                        LoadRoleList();
                    }
                    else
                    {
                        //MessageBox.Show("Chưa chọn quyền nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NotificationForm notificationForm = new NotificationForm("Chưa chọn vai trò nào", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
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

        private void RoleCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //this.BeginInvoke(new Action(() =>
            //{
            //    try
            //    {
            //        List<int> roleIds = (from RoleModel r in RoleCheckedListBox.CheckedItems
            //                             select r.Id).ToList();
            //        if (roleIds.Count == 1)
            //        {
            //            List<ClaimModel> claimsOfCheckedRole = accountService.GetAllClaimByRoleId(roleIds.FirstOrDefault());
            //            List<ClaimModel> claimModels = accountService.GetAllPermission();
            //            PermissionCheckedListBox.Items.Clear();
            //            foreach (ClaimModel claimModel in claimModels)
            //            {
            //                PermissionCheckedListBox.Items.Add
            //                (
            //                    claimModel,
            //                    claimsOfCheckedRole.Any(x => x.Id == claimModel.Id)
            //                );
            //            }
            //        }
            //        else
            //        {
            //            LoadPermissionList();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
            //        notificationForm.ShowDialog();
            //    }
            //}));

        }

        private void RoleCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoleModel roleModel = (RoleModel)RoleCheckedListBox.SelectedItem;
            if (roleModel != null)
            {
                List<ClaimModel> claimsOfCheckedRole = accountService.GetAllClaimByRoleId(roleModel.Id);
                List<ClaimModel> claimModels = accountService.GetAllPermission();
                PermissionCheckedListBox.Items.Clear();
                foreach (ClaimModel claimModel in claimModels)
                {
                    PermissionCheckedListBox.Items.Add
                    (
                        claimModel,
                        claimsOfCheckedRole.Any(x => x.Id == claimModel.Id)
                    );
                }
            }
        }
    }
}
