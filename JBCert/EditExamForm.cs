using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class EditExamForm : Form
    {
        int _examId;
        IManagingSchoolService managingSchoolService;
        public delegate void UpdateExam();
        public static event UpdateExam OnExamUpdated;

        public EditExamForm(int examId)
        {
            InitializeComponent();
            _examId = examId;
            managingSchoolService = new ManagingSchoolService();
        }

        private void EditExamForm_Load(object sender, EventArgs e)
        {
            try
            {
                // load school
                SchoolNameComboBox.DataSource = managingSchoolService.GetAllSchool();
                SchoolNameComboBox.DisplayMember = "SchoolName";
                SchoolNameComboBox.ValueMember = "Id";

                // load exam
                ExamModel examModel = managingSchoolService.GetSingleExamById(_examId);
                ExamNameTextBox.Text = examModel.ExamName;
                SchoolNameComboBox.SelectedValue = examModel.SchoolId;
                ExamDateTextBox.Text = examModel.ExamDate.ToString("dd/MM/yyyy");
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ExamNameTextBox.Text))
                {
                    //MessageBox.Show("Điền tên kỳ thi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điền tên kỳ thi", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (SchoolNameComboBox.SelectedValue == null)
                {
                    //MessageBox.Show("Điền tên kỳ thi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chọn trường học", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }

                DateTime examDate;
                if (string.IsNullOrEmpty(ExamDateTextBox.Text))
                {

                    NotificationForm notificationForm = new NotificationForm("Điền ngày thi", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }
                else
                {

                    bool chValidity = DateTime.TryParseExact(
                     ExamDateTextBox.Text,
                     "dd/MM/yyyy",
                     CultureInfo.InvariantCulture,
                     DateTimeStyles.None, out examDate);
                    if (!chValidity)
                    {
                        NotificationForm notificationForm = new NotificationForm("Điền ngày thi theo dạng dd/MM/yyyy ví dụ 12/07/2020", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                        return;
                    }
                }

                SchoolModel schoolModel = managingSchoolService.GetSingleSchoolById(int.Parse(SchoolNameComboBox.SelectedValue.ToString()));
                ExamModel examModel = new ExamModel();
                examModel.Id = _examId;
                examModel.ExamName = ExamNameTextBox.Text;
                examModel.SchoolId = int.Parse(SchoolNameComboBox.SelectedValue.ToString());
                examModel.ExamDate = examDate;
                examModel.IsDeleted = false;
                examModel.BlankCertTypeId = schoolModel.BlankCertTypeId;
                int result = managingSchoolService.UpdateExam(examModel);
                if (result == 1)
                {
                    //MessageBox.Show("Cập nhật kỳ thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật kỳ thi thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    OnExamUpdated();
                }
                else
                {
                    //MessageBox.Show("Cập nhật kỳ thi không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Cập nhật kỳ thi không thành công", "Cảnh báo", MessageBoxIcon.Warning);
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
    }
}
