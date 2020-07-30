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
    public partial class AddVillageForm : Form
    {
        IManagingAdministrativeBoundariesService managingAdministrativeBoundariesService;

        public delegate void AddVillage();
        public static event AddVillage OnVillageAdded;
        public AddVillageForm()
        {
            InitializeComponent();
            managingAdministrativeBoundariesService = new ManagingAdministrativeBoundariesService();
            OnVillageAdded += AddVillageForm_OnVillageAdded;
        }

        private void AddVillageForm_OnVillageAdded()
        {
        }

        private void AddVillageForm_Load(object sender, EventArgs e)
        {
            // load town combobox
            List<TownModel> townModels = managingAdministrativeBoundariesService.GetAllTown();

            TownComboBox.DataSource = townModels.ToList();
            TownComboBox.DisplayMember = "TownName";
            TownComboBox.ValueMember = "Id";
            TownComboBox.SelectedIndex = 0;

        }

        private void AddButton_Click(object sender, EventArgs e)
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
            villageModel.VillageName = VillageNameTextBox.Text;
            villageModel.Address = AddressTextBox.Text;
            villageModel.TownId = int.Parse(TownComboBox.SelectedValue.ToString());
            villageModel.PhoneNumber = string.IsNullOrEmpty(PhoneNumberTextBox.Text) ? "" : PhoneNumberTextBox.Text;
            villageModel.Fax = string.IsNullOrEmpty(FaxTextBox.Text) ? "" : FaxTextBox.Text;
            villageModel.Note = string.IsNullOrEmpty(NoteRichTextBox.Text) ? "" : NoteRichTextBox.Text;
            villageModel.IsDeleted = false;
            try
            {
                int result = managingAdministrativeBoundariesService.AddVillage(villageModel);
                if (result > 0)
                {
                    OnVillageAdded();
                    NotificationForm notificationForm = new NotificationForm("Thêm xã thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    NotificationForm notificationForm = new NotificationForm("Thêm xã không thành công", "Cảnh báo", MessageBoxIcon.Warning);
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
