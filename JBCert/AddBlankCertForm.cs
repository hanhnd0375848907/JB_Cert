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
    public partial class AddBlankCertForm : Form
    {
        string saveFileName = "";
        string imageLocation = "";
        string extension = "";
        ManagingBlankCertService managingBlankCertService;
        public delegate void AddBlankCert();
        public static event AddBlankCert OnBlankCertAdded;
        public AddBlankCertForm()
        {
            InitializeComponent();
            managingBlankCertService = new ManagingBlankCertService();
            OnBlankCertAdded += AddBlankCertForm_OnBlankCertAdded;
        }

        private void AddBlankCertForm_OnBlankCertAdded()
        {
        }

        private void ChooseCertImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofDlg = new OpenFileDialog();
                ofDlg.Filter = "JPG|*.jpg|GIF|*.gif|PNG|*.png|BMP|*.bmp";
                if (DialogResult.OK == ofDlg.ShowDialog())
                {
                    imageLocation = ofDlg.FileName;
                    extension = Path.GetExtension(imageLocation);
                    ChooseCertImageButton.Enabled = true;
                    BlankCertImagePictureBox.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void AddBlankCertButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SerialCertTextBox.Text))
                {
                    //MessageBox.Show("Điền số hiệu văn bằng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền số hiệu văn bằng!", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (BlankCertTypeComboBox.SelectedValue == null)
                {
                    //MessageBox.Show("Chọn ảnh phôi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chọn loại phôi", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(imageLocation))
                {
                    //MessageBox.Show("Chọn ảnh phôi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chọn ảnh phôi!", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }
                saveFileName = SerialCertTextBox.Text;
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;


                int result = managingBlankCertService.Add(SerialCertTextBox.Text, "", saveFileName + extension, int.Parse(BlankCertTypeComboBox.SelectedValue.ToString()));
                if (result > 0)
                {

                    OnBlankCertAdded();
                    File.Copy(imageLocation, Path.Combine(@"C:\JbCert_Resource\Images", saveFileName + extension));
                    //MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Thêm thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("Thêm không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Thêm không thành công", "Cảnh báo", MessageBoxIcon.Information);
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

        private void AddBlankCertForm_Load(object sender, EventArgs e)
        {
            // Load Blank cert type
            BlankCertTypeComboBox.DataSource = managingBlankCertService.GetAllBlankCertType();
            BlankCertTypeComboBox.DisplayMember = "Name";
            BlankCertTypeComboBox.ValueMember = "Id";
        }

        private void BlankCertTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
