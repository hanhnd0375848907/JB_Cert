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
    public partial class EditTownForm : Form
    {
        int _townId;
        IManagingAdministrativeBoundariesService managingAdministrativeBoundariesService;
        public delegate void UpdateTown();
        public static event UpdateTown OnTownUpdated;
        public EditTownForm(int townId)
        {
            InitializeComponent();
            _townId = townId;
            managingAdministrativeBoundariesService = new ManagingAdministrativeBoundariesService();
        }

        private void EditTownForm_Load(object sender, EventArgs e)
        {
            try
            {
                TownModel townModel = managingAdministrativeBoundariesService.GetSingleTownByTownId(_townId);
                TownNameTextBox.Text = townModel.TownName;
                AddressTextBox.Text = townModel.Address;
                PhoneNumberTextBox.Text = townModel.PhoneNumber;
                FaxTextBox.Text = townModel.Fax;
                NoteRichTextBox.Text = townModel.Note;
            }
            catch(Exception ex)
            {

            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
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
            townModel.Id = _townId;
            townModel.TownName = TownNameTextBox.Text;
            townModel.Address = AddressTextBox.Text;
            townModel.PhoneNumber = string.IsNullOrEmpty(PhoneNumberTextBox.Text) ? "" : PhoneNumberTextBox.Text;
            townModel.Fax = string.IsNullOrEmpty(FaxTextBox.Text) ? "" : FaxTextBox.Text;
            townModel.Note = string.IsNullOrEmpty(NoteRichTextBox.Text) ? "" : NoteRichTextBox.Text;
            townModel.IsDeleted = false;
            try
            {
                int result = managingAdministrativeBoundariesService.UpdateTown(townModel);
                if (result > 0)
                {
                    OnTownUpdated();
                    NotificationForm notificationForm = new NotificationForm("Cập nhật huyện thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    NotificationForm notificationForm = new NotificationForm("Cập nhật huyện không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
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
