using Common;
using JBCert.Mail;
using MimeKit;
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
    public partial class ResetPasswordForm : Form
    {
        IAccountService accountService;
        public ResetPasswordForm()
        {
            InitializeComponent();
            accountService = new AccountService();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetPasswordButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (!NetWorkWrapper.HasInternetConnection())
                {
                    //MessageBox.Show("Yêu cầu kết nối mạng để lấy mật khẩu qua email", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Yêu cầu kết nối mạng để lấy mật khẩu qua email", "Cảnh báo", MessageBoxIcon.Error);
                    notificationForm.ShowDialog();
                    return;
                }
                if (string.IsNullOrEmpty(UsernameTextBox.Text))
                {
                    //MessageBox.Show("Điền tên đăng nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền tên đăng nhập", "Cảnh báo", MessageBoxIcon.Error);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    //MessageBox.Show("Điền email", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền email", "Cảnh báo", MessageBoxIcon.Error);
                    notificationForm.ShowDialog();
                    return;
                }

                AccountModel accountModel = accountService.GetSingleAccountByUsername(UsernameTextBox.Text);
                if (accountModel == null || accountModel.Email != EmailTextBox.Text)
                {
                    //MessageBox.Show("Tên đăng nhập hoặc email không đúng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Tên đăng nhập hoặc email không đúng", "Cảnh báo", MessageBoxIcon.Error);
                    notificationForm.ShowDialog();
                    return;
                }
                else
                {
                    string password = PasswordWraper.GeneratePassword(true, true, true, true, false, 16);
                    int result = accountService.UpdatePassword(accountModel.Id, BCrypt.Net.BCrypt.HashPassword(password));
                    if (result > 0)
                    {
                        BodyBuilder bodyBuilder = new BodyBuilder();
                        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        //string path = Directory.GetCurrentDirectory(); // bản gửi 

                        StreamReader str = new StreamReader(Path.Combine(path, "Mail/SendPasswordEmailTemplate.html"));
                        string MailText = str.ReadToEnd();
                        MailText = MailText.Replace("{{Title}}", "Thông tin tài khoản");
                        MailText = MailText.Replace("{{Username}}", accountModel.Username);
                        MailText = MailText.Replace("{{Password}}", password);
                        bodyBuilder.HtmlBody = MailText;

                        MimeMessage mimeMessage = new MimeMessage();
                        mimeMessage.Body = bodyBuilder.ToMessageBody();
                        MailWrapper.SendMail("", EmailTextBox.Text, "Cấp lại mật khẩu", mimeMessage);

                        //MessageBox.Show("Cấp lại mật khẩu thành công, đăng nhập email để lấy mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotificationForm notificationForm = new NotificationForm("Cấp lại mật khẩu thành công, đăng nhập email để lấy mật khẩu", "Thông báo", MessageBoxIcon.Information);
                        notificationForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        //MessageBox.Show("Cấp lại mật khẩu không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NotificationForm notificationForm = new NotificationForm("Cấp lại mật khẩu không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
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
    }
}
