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
    public partial class EditDoEaTForm : Form
    {
        DepartmentOfEducationAndTrainingService departmentOfEducationAndTrainingService;
        public delegate void UpdateInfor();
        public static event UpdateInfor OnInforUpdated; 
        public EditDoEaTForm()
        {
            InitializeComponent();
            departmentOfEducationAndTrainingService = new DepartmentOfEducationAndTrainingService();
            OnInforUpdated += EditDoEaTForm_OnInforUpdated;
        }

        private void EditDoEaTForm_OnInforUpdated()
        {
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditDoEaTForm_Load(object sender, EventArgs e)
        {
            DepartmentOfEducationAndTrainingModel departmentOfEducationAndTrainingModel = departmentOfEducationAndTrainingService.GetInfor();
            NameTextBox.Text = departmentOfEducationAndTrainingModel.Name;
            PhoneNumberTextBox.Text = departmentOfEducationAndTrainingModel.PhoneNumber;
            ProvinceTextBox.Text = departmentOfEducationAndTrainingModel.Province;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    //MessageBox.Show("Điền tên sở giáo dục", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền tên sở giáo dục", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(PhoneNumberTextBox.Text))
                {
                    //MessageBox.Show("Điền số điện thoại sở giáo dục", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền số điện thoại sở giáo dục", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(ProvinceTextBox.Text))
                {
                    //MessageBox.Show("Điền tỉnh sở giáo dục", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền tỉnh sở giáo dục", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                DepartmentOfEducationAndTrainingModel departmentOfEducationAndTrainingModel = new DepartmentOfEducationAndTrainingModel();
                departmentOfEducationAndTrainingModel.Name = NameTextBox.Text;
                departmentOfEducationAndTrainingModel.PhoneNumber = PhoneNumberTextBox.Text;
                departmentOfEducationAndTrainingModel.Province = ProvinceTextBox.Text;

                int result = departmentOfEducationAndTrainingService.UpdateInfor(departmentOfEducationAndTrainingModel);
                if(result == 1)
                {
                    //MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    OnInforUpdated();
                }
                else
                {
                    //MessageBox.Show("Cập nhật không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                this.Close();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }
    }
}
