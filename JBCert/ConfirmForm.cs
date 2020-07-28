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
    public partial class ConfirmForm : Form
    {
        Button yesButton, noButton;
        public DialogResult Result = DialogResult.No;
        string _content;

        public ConfirmForm(string content)
        {
            InitializeComponent();
            yesButton = new Button();
            noButton = new Button();
            _content = content;
        }

        private void ConfirmForm_Load(object sender, EventArgs e)
        {
            this.CancelButton = noButton;
            this.AcceptButton = yesButton;

            ContentConfirmLabel.Text = _content;
            yesButton.Width = 100;
            yesButton.Height = 35;
            yesButton.Text = "Đồng ý";
            yesButton.Font = new Font("Arial", 11, FontStyle.Regular);
            yesButton.Left = ContentConfirmLabel.Left + ContentConfirmLabel.Width/2 + 10;
            yesButton.Top = ContentConfirmLabel.Top + ContentConfirmLabel.Height + 50;
            yesButton.Margin = new Padding(3, 3, 3, 20);
            yesButton.Click += YesButton_Click;
            this.Controls.Add(yesButton);

            noButton.Width = 100;
            noButton.Height = 35;
            noButton.Text = "Hủy";
            noButton.Font = new Font("Arial", 11, FontStyle.Regular);
            noButton.Left = ContentConfirmLabel.Left + ContentConfirmLabel.Width/2 - 10 - noButton.Width;
            noButton.Top = ContentConfirmLabel.Top + ContentConfirmLabel.Height + 50;
            noButton.Margin = new Padding(3, 3, 3, 20);
            noButton.Click += NoButton_Click; ;
            this.Controls.Add(noButton);
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.No;
            this.Close();
        }

        public void YesButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Yes;
            this.Close();
        }
    }
}
