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
    public partial class AddExamForm : Form
    {
        IManagingSchoolService managingSchoolService;
        public delegate void AddExam();
        public static event AddExam OnExamAdded;
        public AddExamForm()
        {
            InitializeComponent();
            managingSchoolService = new ManagingSchoolService();
            OnExamAdded += AddExamForm_OnExamAdded;
        }

        private void AddExamForm_OnExamAdded()
        {
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ExamNameTextBox.Text))
                {
                    //MessageBox.Show("Điền tên kỳ thi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền tên kỳ thi", "Cảnh báo",MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }
                SchoolModel schoolModel = managingSchoolService.GetSingleSchoolById(int.Parse(SchoolNameComboBox.SelectedValue.ToString()));
                ExamModel examModel = new ExamModel();
                examModel.ExamName = ExamNameTextBox.Text;
                examModel.SchoolId = int.Parse(SchoolNameComboBox.SelectedValue.ToString());
                examModel.ExamDate = ExamDateDateTimePicker.Value;
                examModel.IsDeleted = false;
                examModel.BlankCertTypeId = schoolModel.BlankCertTypeId;
                int result = managingSchoolService.AddExam(examModel);
                if(result == 1)
                {
                    //MessageBox.Show("Thêm mới kỳ thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Thêm mới kỳ thi thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    OnExamAdded();
                }
                else
                {
                    //MessageBox.Show("Thêm mới kỳ thi không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Thêm mới kỳ thi không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddExamForm_Load(object sender, EventArgs e)
        {
            // load school
            SchoolNameComboBox.DataSource = managingSchoolService.GetAllSchool();
            SchoolNameComboBox.DisplayMember = "SchoolName";
            SchoolNameComboBox.ValueMember = "Id";
        }
    }
}
