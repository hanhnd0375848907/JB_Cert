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
    public partial class EditSchoolForm : Form
    {
        private int _schoolId;
        IManagingSchoolService managingSchoolService;
        IManagingBlankCertTypeService managingBlankCertTypeService;

        public delegate void UpdateSchool();
        public static event UpdateSchool OnSchoolUpdated;
        public EditSchoolForm(int schoolId)
        {
            InitializeComponent();
            _schoolId = schoolId;
            managingSchoolService = new ManagingSchoolService();
            managingBlankCertTypeService = new ManagingBlankCertTypeService();
            OnSchoolUpdated += EditSchoolForm_OnSchoolUpdated;
        }

        private void EditSchoolForm_OnSchoolUpdated()
        {
        }

        private void EditSchoolForm_Load(object sender, EventArgs e)
        {
            // load town combobox
            TownComboBox.DataSource = managingSchoolService.GetAllTown();
            TownComboBox.DisplayMember = "TownName";
            TownComboBox.ValueMember = "Id";

            // load village combobox
            VillageComboBox.DataSource = managingSchoolService.GetAllVillageByTownId(int.Parse(TownComboBox.SelectedValue.ToString()));
            VillageComboBox.DisplayMember = "VillageName";
            VillageComboBox.ValueMember = "Id";

            // load blankCerttype
            BlankCertTypeComboBox.DataSource = managingBlankCertTypeService.GetAllBlankCertType();
            BlankCertTypeComboBox.DisplayMember = "Name";
            BlankCertTypeComboBox.ValueMember = "Id";

            SchoolModel schoolModel = managingSchoolService.GetSingleSchoolById(_schoolId);

            SchoolNameTextBox.Text = schoolModel.SchoolName;
            AddressTextBox.Text = schoolModel.Address;
            PhoneNumberTextBox.Text = schoolModel.PhoneNumber;
            FaxTextBox.Text = schoolModel.Fax;
            Representative.Text = schoolModel.Representative;
            ProvinceTextBox.Text = schoolModel.Province;
            NoteRichTextBox.Text = schoolModel.Note;
            TownComboBox.SelectedValue = schoolModel.TownId;
            VillageComboBox.SelectedValue = schoolModel.VillageId;
            BlankCertTypeComboBox.SelectedValue = schoolModel.BlankCertTypeId;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SchoolNameTextBox.Text))
                {
                    //MessageBox.Show("Điền tên trường", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền tên trường", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(AddressTextBox.Text))
                {
                    //MessageBox.Show("Điền địa chỉ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền địa chỉ", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(PhoneNumberTextBox.Text))
                {
                    //MessageBox.Show("Điền số điện thoại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền số điện thoại", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(Representative.Text))
                {
                    //MessageBox.Show("Điền người đại diện", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền người đại diện", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (BlankCertTypeComboBox.SelectedValue == null)
                {
                    NotificationForm notificationForm = new NotificationForm("Chọn loại bằng", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (BlankCertTypeComboBox.SelectedValue == null)
                {
                    NotificationForm notificationForm = new NotificationForm("Chọn loại", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (TownComboBox.SelectedValue == null)
                {
                    NotificationForm notificationForm = new NotificationForm("Chọn huyện", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (VillageComboBox.SelectedValue == null)
                {
                    NotificationForm notificationForm = new NotificationForm("Chọn xã", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                SchoolModel schoolModel = new SchoolModel();
                schoolModel.Id = _schoolId;
                schoolModel.SchoolName = SchoolNameTextBox.Text;
                schoolModel.Address = AddressTextBox.Text;
                schoolModel.PhoneNumber = PhoneNumberTextBox.Text;
                schoolModel.Representative = Representative.Text;
                schoolModel.Province = ProvinceTextBox.Text;
                schoolModel.BlankCertTypeId = int.Parse(BlankCertTypeComboBox.SelectedValue.ToString());
                schoolModel.VillageId = int.Parse(VillageComboBox.SelectedValue.ToString());
                schoolModel.Note = NoteRichTextBox.Text;
                schoolModel.Fax = FaxTextBox.Text;
                schoolModel.IsDeleted = false;

                int result = managingSchoolService.UpdateSchool(schoolModel);
                if (result > 0)
                {
                    //MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Lưu thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    OnSchoolUpdated();
                }
                else
                {
                    //MessageBox.Show("Lưu không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Lưu không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void TownComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TownComboBox.DataSource != null)
            {
                TownComboBox.DisplayMember = "TownName";
                TownComboBox.ValueMember = "Id";
                VillageComboBox.DataSource = managingSchoolService.GetAllVillageByTownId(int.Parse(TownComboBox.SelectedValue.ToString()));
                VillageComboBox.DisplayMember = "VillageName";
                VillageComboBox.ValueMember = "Id";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
