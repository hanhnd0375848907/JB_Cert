﻿using Common;
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
    public partial class ManagingYourAccountForm : Form
    {
        IAccountService accountService;
        public ManagingYourAccountForm()
        {
            InitializeComponent();
            accountService = new AccountService();
        }

        private void ManagingYourAccountForm_Load(object sender, EventArgs e)
        {
            try
            {
                int accountId = CurrentUser.Id;
                AccountModel accountModel = accountService.GetSingleAccountById(accountId);
                UsernameTextBox.Text = accountModel.Username;
                EmailTextBox.Text = accountModel.Email;
                PhoneNumberTextBox.Text = accountModel.PhoneNumber;
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }

        }

        private void IsChangePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CurrentPasswordTextBox.Enabled = IsChangePasswordCheckBox.Checked;
            NewPasswordTextBox.Enabled = IsChangePasswordCheckBox.Checked;
            ReNewPasswordTextBox.Enabled = IsChangePasswordCheckBox.Checked;
            label4.Enabled = IsChangePasswordCheckBox.Checked;
            label5.Enabled = IsChangePasswordCheckBox.Checked;
            label6.Enabled = IsChangePasswordCheckBox.Checked;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                AccountModel accountModel = accountService.GetSingleAccountById(CurrentUser.Id);
                accountModel.Id = CurrentUser.Id;
                accountModel.Username = UsernameTextBox.Text;
                accountModel.Email = string.IsNullOrEmpty(EmailTextBox.Text) ? "" : EmailTextBox.Text;
                accountModel.PhoneNumber = string.IsNullOrEmpty(PhoneNumberTextBox.Text) ? "" : PhoneNumberTextBox.Text;
                accountModel.IsActive = false;


                int result = accountService.UpdateAccountInformation(accountModel);
                if (IsChangePasswordCheckBox.Checked)
                {
                    string currentPassword = string.IsNullOrEmpty(CurrentPasswordTextBox.Text) ? "" : CurrentPasswordTextBox.Text;
                    string newPassowrd = string.IsNullOrEmpty(NewPasswordTextBox.Text) ? "" : NewPasswordTextBox.Text;
                    string reNewPassword = string.IsNullOrEmpty(ReNewPasswordTextBox.Text) ? "" : ReNewPasswordTextBox.Text;
                    if (BCrypt.Net.BCrypt.Verify(currentPassword, accountModel.Password))
                    {
                        if (newPassowrd != reNewPassword)
                        {
                            //MessageBox.Show("Nhập lại mật khẩu mới không khớp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            NotificationForm notificationForm = new NotificationForm("Nhập lại mật khẩu mới không khớp", "Cảnh báo", MessageBoxIcon.Error);
                            notificationForm.ShowDialog();
                        }

                        result += accountService.UpdatePassword(accountModel.Id, BCrypt.Net.BCrypt.HashPassword(newPassowrd));

                    }
                    else
                    {
                        //MessageBox.Show("Mật khẩu hiện tại không đúng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NotificationForm notificationForm = new NotificationForm("Mật khẩu hiện tại không đúng", "Cảnh báo", MessageBoxIcon.Error);
                        notificationForm.ShowDialog();
                    }
                }

                if (result > 0)
                {
                    //MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật thông tin thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Cập nhật thông tin không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật thông tin không thành công", "Cảnh báo", MessageBoxIcon.Error);
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