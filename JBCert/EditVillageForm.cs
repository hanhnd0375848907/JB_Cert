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
    public partial class EditVillageForm : Form
    {
        int _villageId;
        IManagingAdministrativeBoundariesService managingAdministrativeBoundariesService;

        public delegate void UpdateVillage();
        public static event UpdateVillage OnVillageUpdated;
        public EditVillageForm(int villageId)
        {
            InitializeComponent();
            _villageId = villageId;
            managingAdministrativeBoundariesService = new ManagingAdministrativeBoundariesService();
            OnVillageUpdated += EditVillageForm_OnVillageUpdated;
        }

        private void EditVillageForm_OnVillageUpdated()
        {
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(VillageNameTextBox.Text))
            {
                NotificationForm notificationForm = new NotificationForm("Điền tên xã", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            if (string.IsNullOrEmpty(AddressTextBox.Text))
            {
                NotificationForm notificationForm = new NotificationForm("Điền địa chỉ huyện", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            if (TownComboBox.SelectedValue == null)
            {
                NotificationForm notificationForm = new NotificationForm("Chọn huyện", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            VillageModel villageModel = new VillageModel();
            villageModel.Id = _villageId;
            villageModel.VillageName = VillageNameTextBox.Text;
            villageModel.Address = AddressTextBox.Text;
            villageModel.TownId = int.Parse(TownComboBox.SelectedValue.ToString());
            villageModel.PhoneNumber = string.IsNullOrEmpty(PhoneNumberTextBox.Text) ? "" : PhoneNumberTextBox.Text;
            villageModel.Fax = string.IsNullOrEmpty(FaxTextBox.Text) ? "" : FaxTextBox.Text;
            villageModel.Note = string.IsNullOrEmpty(NoteRichTextBox.Text) ? "" : NoteRichTextBox.Text;
            villageModel.IsDeleted = false;
            try
            {
                int result = managingAdministrativeBoundariesService.UpdateVillage(villageModel);
                if (result > 0)
                {
                    OnVillageUpdated();
                    NotificationForm notificationForm = new NotificationForm("Cập nhật xã thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    NotificationForm notificationForm = new NotificationForm("Cập nhật xã không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void EditVillageForm_Load(object sender, EventArgs e)
        {
            // load towncombobox
            List<TownModel> townModels = managingAdministrativeBoundariesService.GetAllTown();

            TownComboBox.DataSource = townModels.ToList();
            TownComboBox.DisplayMember = "TownName";
            TownComboBox.ValueMember = "Id";
            TownComboBox.SelectedIndex = 0;

            // load village

            VillageModel villageModel = managingAdministrativeBoundariesService.GetSingleVillageById(_villageId);
            VillageNameTextBox.Text = villageModel.VillageName;
            AddressTextBox.Text = villageModel.Address;
            PhoneNumberTextBox.Text = villageModel.PhoneNumber;
            FaxTextBox.Text = villageModel.Fax;
            NoteRichTextBox.Text = villageModel.Note;
            TownComboBox.SelectedValue = villageModel.TownId;
        }
    }
}
