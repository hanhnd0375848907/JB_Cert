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
    public partial class AddSchoolForm : Form
    {
        IManagingSchoolService managingSchoolService;
        IManagingBlankCertTypeService managingBlankCertTypeService;

        public delegate void AddSchool();
        public static event AddSchool OnSchoolAdded;
        public AddSchoolForm()
        {
            InitializeComponent();
            managingSchoolService = new ManagingSchoolService();
            managingBlankCertTypeService = new ManagingBlankCertTypeService();
            OnSchoolAdded += AddSchoolForm_OnSchoolAdded;
        }

        private void AddSchoolForm_OnSchoolAdded()
        {
        }

        private void AddSchoolForm_Load(object sender, EventArgs e)
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

            // load province
            ProvinceTextBox.Text = managingSchoolService.GetInforOfDoEaT().Province;

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddSchoolButton_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    int.Parse(PhoneNumberTextBox.Text);
                }
                catch(FormatException ex)
                {
                    //MessageBox.Show("Số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Số điện thoại chỉ bao gồm số", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(SchoolNameTextBox.Text))
                {
                    //MessageBox.Show("Điền tên trường", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền tên trường", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }

                if (string.IsNullOrEmpty(AddressTextBox.Text))
                {
                    //MessageBox.Show("Điền địa chỉ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền địa chỉ", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }

                if (string.IsNullOrEmpty(PhoneNumberTextBox.Text))
                {
                    //MessageBox.Show("Điền số điện thoại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền số điện thoại", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }

                if (string.IsNullOrEmpty(Representative.Text))
                {
                    //MessageBox.Show("Điền người đại diện", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền người đại diện", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }

                SchoolModel schoolModel = new SchoolModel();
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

                int result = managingSchoolService.AddSchool(schoolModel);
                if (result > 0)
                {
                    //MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Thêm thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    OnSchoolAdded();
                }
                else
                {
                    //MessageBox.Show("Thêm không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Thêm không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TownComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TownComboBox.DataSource != null)
            {
                TownComboBox.DisplayMember = "TownName";
                TownComboBox.ValueMember = "Id";
                VillageComboBox.DataSource = managingSchoolService.GetAllVillageByTownId(int.Parse(TownComboBox.SelectedValue.ToString()));
                VillageComboBox.DisplayMember = "VillageName";
                VillageComboBox.ValueMember = "Id";
            }
        }

        private void PhoneNumberTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                int result = int.Parse(PhoneNumberTextBox.Text);
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Chỉ được điền số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Chỉ được điền số", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
        }
    }
}
