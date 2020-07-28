using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class NotificationForm : Form
    {
        string _content = "";
        string _title = "";
        MessageBoxIcon _messageBoxIcon;
        Button yesButton;
        public NotificationForm(string content, string title, MessageBoxIcon messageBoxIcon)
        {
            InitializeComponent();
            _content = content;
            _messageBoxIcon = messageBoxIcon;
            _title = title;
            yesButton = new Button();

        }

        private void YesButton_Click(object sender, EventArgs e)
        {         
            this.Close();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            switch (_messageBoxIcon)
            {
                case MessageBoxIcon.Error:
                    LoadIcon(false, false, true);
                    break;
                case MessageBoxIcon.Information:
                    LoadIcon(true, false, false);
                    break;
                case MessageBoxIcon.Warning:
                    LoadIcon(false, true, false);
                    break;
            }
            ContentNotificationLabel.Text = _content;
            yesButton.Width = 100;
            yesButton.Height = 35;
            yesButton.Text = "Đồng ý";
            yesButton.Font = new Font("Arial", 11, FontStyle.Regular);
            yesButton.Left = ContentNotificationLabel.Right - yesButton.Width + 20;
            yesButton.Top = ContentNotificationLabel.Top + ContentNotificationLabel.Height + 50;
            yesButton.Margin = new Padding(3, 3, 3, 20);
            yesButton.Click += YesButton_Click1;
            this.Controls.Add(yesButton);

            this.Text = _title;
        }

        private void YesButton_Click1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadIcon(bool information, bool warning, bool error)
        {
            ErrorPictureBox.Visible = error;
            InformationPictureBox.Visible = information;
            WarningPictureBox.Visible = warning;
        }
    }
}
