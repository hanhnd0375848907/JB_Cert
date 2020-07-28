using Common;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class LoginForm : Form
    {
        IAccountService accountService;
        public LoginForm()
        {
            
                        InitializeComponent();
            accountService = new AccountService();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // pass: jbcert2020
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                MessageBox.Show("Điền tên đăng nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                MessageBox.Show("Điền mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            AccountModel accountModel = accountService.GetSingleAccountByUsername(username);
            if (accountModel != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, accountModel.Password))
                {
                    if (SavePasswordCheckBox.Checked)
                    {
                        Properties.Settings.Default.Username = UsernameTextBox.Text;
                        Properties.Settings.Default.Password = PasswordTextBox.Text;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Username = string.Empty;
                        Properties.Settings.Default.Password = string.Empty;
                        Properties.Settings.Default.Save();
                    }

                    CurrentUser.Id = accountModel.Id;
                    CurrentUser.Username = accountModel.Username;
                    HomeForm homeForm = new HomeForm(accountModel);
                    homeForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Mật khẩu sai", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập không đúng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

           
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(@"C:\JbCert_Resource\StudentImages");
            System.IO.Directory.CreateDirectory(@"C:\JbCert_Resource\Images");
            this.BackColor = Color.FromArgb(230, 235, 252);

            if (Properties.Settings.Default.Username != string.Empty)
            {
                UsernameTextBox.Text = Properties.Settings.Default.Username;
                PasswordTextBox.Text = Properties.Settings.Default.Password;
                SavePasswordCheckBox.Checked = true;
            }
            else
            {
                UsernameTextBox.Text = string.Empty;;
                PasswordTextBox.Text = string.Empty; ;
                SavePasswordCheckBox.Checked = false;
            }
        }

        private void ForgetPasswordLabel_MouseHover(object sender, EventArgs e)
        {
            ForgetPasswordLabel.ForeColor = Color.FromArgb(28, 42, 201);
        }

        private void ForgetPasswordLabel_MouseLeave(object sender, EventArgs e)
        {
            ForgetPasswordLabel.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void ForgetPasswordLabel_Click(object sender, EventArgs e)
        {
            ResetPasswordForm resetPasswordForm = new ResetPasswordForm();
            resetPasswordForm.ShowDialog();
        }

        private void SavePasswordCheckBox_Click(object sender, EventArgs e)
        {
            
        }
    }
}
