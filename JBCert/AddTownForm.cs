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
    public partial class AddTownForm : Form
    {
        IManagingAdministrativeBoundariesService managingAdministrativeBoundariesService;

        public delegate void AddTown();
        public static event AddTown OnTownAdded;
        public AddTownForm()
        {
            InitializeComponent();
            managingAdministrativeBoundariesService = new ManagingAdministrativeBoundariesService();
            OnTownAdded += AddTownForm_OnTownAdded;
        }

        private void AddTownForm_OnTownAdded()
        {
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TownNameTextBox.Text))
            {
                NotificationForm notificationForm = new NotificationForm("Điền tên huyện", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            if (string.IsNullOrEmpty(AddressTextBox.Text))
            {
                NotificationForm notificationForm = new NotificationForm("Điền địa chỉ huyện", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            TownModel townModel = new TownModel();
            townModel.TownName = TownNameTextBox.Text;
            townModel.Address = AddressTextBox.Text;
            townModel.PhoneNumber = string.IsNullOrEmpty(PhoneNumberTextBox.Text) ? "" : PhoneNumberTextBox.Text; 
            townModel.Fax = string.IsNullOrEmpty(FaxTextBox.Text) ? "" : FaxTextBox.Text;
            townModel.Note = string.IsNullOrEmpty(NoteRichTextBox.Text) ? "" : NoteRichTextBox.Text;
            townModel.IsDeleted = false;
            try
            {
                int result = managingAdministrativeBoundariesService.AddTown(townModel);
                if (result > 0)
                {
                    OnTownAdded();
                    NotificationForm notificationForm = new NotificationForm("Thêm huyện thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    NotificationForm notificationForm = new NotificationForm("Thêm huyện không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void AddTownForm_Load(object sender, EventArgs e)
        {

        }
    }
}
