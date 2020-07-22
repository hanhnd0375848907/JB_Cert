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
    public partial class EditBlankCertTypeForm : Form
    {
        private IManagingBlankCertTypeService managingBlankCertTypeService;
        private int _blankCertTypeId;

        public delegate void UpdateBlanKCertType();
        public static event UpdateBlanKCertType OnBlankCertTypeUpdated;

        public EditBlankCertTypeForm(int blankCertTypeId)
        {
            InitializeComponent();
            managingBlankCertTypeService = new ManagingBlankCertTypeService();
            _blankCertTypeId = blankCertTypeId;
        }

        private void EditBlankCertTypeForm_Load(object sender, EventArgs e)
        {
            BlankCertTypeModel blankCertTypeModel = managingBlankCertTypeService.GetSingleBlankCertTypeById(_blankCertTypeId);
            BlankCertTypeTextBox.Text = blankCertTypeModel.Name;
            NoteRichTextBox.Text = blankCertTypeModel.Note;
        }

        private void CancelBlankCertTypeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BlankCertTypeTextBox.Text))
            {
                MessageBox.Show("Điền tên kiểu phôi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Điền tên kiểu phôi", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            try
            {
                BlankCertTypeModel blankCertTypeModel = new BlankCertTypeModel();
                blankCertTypeModel.Id = _blankCertTypeId;
                blankCertTypeModel.Name = BlankCertTypeTextBox.Text;
                blankCertTypeModel.Note = NoteRichTextBox.Text;

                int result = managingBlankCertTypeService.UpdateBlanCertType(blankCertTypeModel);
                if (result > 0)
                {
                    OnBlankCertTypeUpdated();
                    //MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog(); 
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("Thêm không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }
    }
}
