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
    public partial class ShowingImageForm : Form
    {
        string _path;
        public ShowingImageForm(string path)
        {
            InitializeComponent();
            _path = path;
        }

        private void ShowingImageForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.Open))
                {
                    ImagePictureBox.Image = Image.FromStream(fs);
                }
            }
            catch(FileNotFoundException FileNotFoundEx)
            {
                NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh, vui lòng cập nhật lại ảnh", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void ImagePictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
