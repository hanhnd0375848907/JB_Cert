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
    public partial class AddBlankCertTypeForm : Form
    {
        IManagingBlankCertTypeService managingBlankCertTypeService;
        public delegate void AddBlankCertType();
        public static event AddBlankCertType OnBlankCertTypeAdded;
        public AddBlankCertTypeForm()
        {
            InitializeComponent();
            managingBlankCertTypeService = new ManagingBlankCertTypeService();
        }

        private void CancelBlankCertTypeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBlankCertTypeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(BlankCertTypeTextBox.Text))
                {
                    //MessageBox.Show("Điền tên kiểu phôi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền tên kiểu phôi!", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }
                BlankCertTypeModel blankCertTypeModel = new BlankCertTypeModel();
                blankCertTypeModel.Name = BlankCertTypeTextBox.Text;
                blankCertTypeModel.Note = NoteRichTextBox.Text;
                int result = managingBlankCertTypeService.AddBlankCertType(blankCertTypeModel);
                if (result > 0)
                {
                    OnBlankCertTypeAdded();
                    //MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Thêm thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("Thêm không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NotificationForm notificationForm = new NotificationForm("Thêm không thành công", "Lỗi", MessageBoxIcon.Error);
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

        private void AddBlankCertTypeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
