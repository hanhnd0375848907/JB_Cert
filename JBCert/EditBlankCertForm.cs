using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class EditBlankCertForm : Form
    {
        int _certId;
        string imageLocation;
        string extension;
        string saveFileName;
        ManagingBlankCertService managingBlankCertService;
        BlankCertModel currentBlankCertModel;

        public delegate void UpdateBlankCert();
        public static event UpdateBlankCert OnBlankCertUpdated;

        public EditBlankCertForm(int certId)
        {
            InitializeComponent();
            _certId = certId;
            managingBlankCertService = new ManagingBlankCertService();
        }

        private void EditBlankCertForm_Load(object sender, EventArgs e)
        {
            try
            {
                currentBlankCertModel = managingBlankCertService.GetSingleById(_certId);

                // Load Blank cert type
                BlankCertTypeComboBox.DataSource = managingBlankCertService.GetAllBlankCertType();
                BlankCertTypeComboBox.DisplayMember = "Name";
                BlankCertTypeComboBox.ValueMember = "Id";
                BlankCertTypeComboBox.SelectedValue = currentBlankCertModel.BlankCertTypeId;

                SerialCertTextBox.Text = currentBlankCertModel.Serial;

                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                using (FileStream fs = new FileStream(Path.Combine(@"C:\JbCert_Resource\Images\", currentBlankCertModel.Image), FileMode.Open))
                {
                    BlankCertImagePictureBox.Image = Image.FromStream(fs);
                }

                if (!currentBlankCertModel.IsAvailable)
                {
                    ReasonReturnRichTextBox.Visible = true;
                    ReasonReturnRichTextBox.BackColor = Color.FromArgb(235, 250, 236);
                    FailBlankCertCheckbox.Checked = true;
                }
                else
                {
                    FailBlankCertCheckbox.Checked = false;
                    ReasonReturnRichTextBox.Visible = false;
                }

                ReturnBlankCertCheckbox.Checked = currentBlankCertModel.IsReturned;
                ReasonReturnRichTextBox.Text = currentBlankCertModel.ReasonReturn;
            }
            catch(FileNotFoundException ex)
            {
                NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh phôi", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void FailBlankCertCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (FailBlankCertCheckbox.Checked)
            {
                ReasonReturnRichTextBox.Visible = true;
                ReasonReturnRichTextBox.BackColor = Color.FromArgb(235, 250, 236);
            }
            else
            {
                ReasonReturnRichTextBox.Visible = false;
            }
        }

        private void ReturnBlankCertCheckbox_CheckedChanged(object sender, EventArgs e)
        {

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
                    NotificationForm notificationForm = new NotificationForm("Chọn loại phôi!", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                if (!string.IsNullOrEmpty(imageLocation))
                {
                    saveFileName = SerialCertTextBox.Text;
                    File.Delete(Path.Combine(@"C:\JbCert_Resource\Images\", currentBlankCertModel.Image));
                    currentBlankCertModel.Image = saveFileName + extension;
                }

                currentBlankCertModel.Serial = SerialCertTextBox.Text;
                currentBlankCertModel.UpdatedAt = DateTime.Now;
                currentBlankCertModel.IsAvailable = (!FailBlankCertCheckbox.Checked & !ReturnBlankCertCheckbox.Checked);
                currentBlankCertModel.IsReturned = ReturnBlankCertCheckbox.Checked;
                currentBlankCertModel.ReasonReturn = ReasonReturnRichTextBox.Text;
                currentBlankCertModel.BlankCertTypeId = int.Parse(BlankCertTypeComboBox.SelectedValue.ToString());

                int result = managingBlankCertService.Update(currentBlankCertModel);
                if (result > 0)
                {
                    OnBlankCertUpdated();
                    if (!string.IsNullOrEmpty(imageLocation))
                    {
                        File.Copy(imageLocation, Path.Combine(@"C:\JbCert_Resource\Images\", saveFileName + extension));
                    }
                    //MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("Cập nhật không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                //MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
