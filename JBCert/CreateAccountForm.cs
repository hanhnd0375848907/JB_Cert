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
    public partial class CreateAccountForm : Form
    {
        IAccountService accountService;
        public CreateAccountForm()
        {
            InitializeComponent();
            accountService = new AccountService();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string username = "";
            string email = "";
            string phoneNumber = "";
            if (string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                //MessageBox.Show("Điền tên đăng nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Điền tên đăng nhập", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                //MessageBox.Show("Điền email để nhận mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Điền email để nhận mật khẩu", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            username = UsernameTextBox.Text;
            email = string.IsNullOrEmpty(EmailTextBox.Text) ? "" : EmailTextBox.Text;
            phoneNumber = string.IsNullOrEmpty(PhoneNumberTextBox.Text) ? "" : PhoneNumberTextBox.Text;

            try
            {
                if (accountService.GetSingleAccountByUsername(username) != null)
                {
                    //MessageBox.Show("Tên đăng nhập tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Tên đăng nhập tồn tại", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }
                else if (!NetWorkWrapper.HasInternetConnection())
                {
                    //MessageBox.Show("Yêu cầu kết nối mạng để gửi tài khoản qua mail", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Yêu cầu kết nối mạng để gửi tài khoản qua mail", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                List<int> roleIds = (from RoleModel r in RoleCheckedListBox.CheckedItems
                                     select r.Id).ToList();
                string password = PasswordWraper.GeneratePassword(true, true, true, true, false, 16);
                AccountModel accountModel = new AccountModel();
                accountModel.Username = username;
                accountModel.Email = email;
                accountModel.Password = BCrypt.Net.BCrypt.HashPassword(password);
                accountModel.PhoneNumber = phoneNumber;
                

                int result = accountService.CreateAccount(accountModel, roleIds);
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
                    MailWrapper.SendMail("", email, "Cấp tài khoản", mimeMessage);

                    //MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Tạo tài khoản thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Tạo tài khoản không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Tạo tài khoản không thành công", "Cảnh báo", MessageBoxIcon.Warning);
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

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            // load role
            List<RoleModel> roleModels = accountService.GetAllRole();
            RoleCheckedListBox.Items.Clear();
            foreach(RoleModel roleModel in roleModels)
            {
                RoleCheckedListBox.Items.Add(roleModel, false);
            }
        }
    }
}
