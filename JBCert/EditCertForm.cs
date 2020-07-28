using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class EditCertForm : Form
    {
        private int _certId;
        private StudentModel studentModel;
        private CertModel certModel;
        IManagingCertService managingCertService;
        IManagingStudentService managingStudentService;
        IManagingSchoolService managingSchoolService;
        IManagingBlankCertService managingBlankCertService;
        public EditCertForm(int certId)
        {
            InitializeComponent();
            _certId = certId;
            managingCertService = new ManagingCertService();
            managingStudentService = new ManagingStudentService();
            managingSchoolService = new ManagingSchoolService();
            managingBlankCertService = new ManagingBlankCertService();
        }

        private void EditCertForm_Load(object sender, EventArgs e)
        {
            try
            {
                // load school
                SchoolComboBox.DataSource = managingSchoolService.GetAllSchool();
                SchoolComboBox.DisplayMember = "SchoolName";
                SchoolComboBox.ValueMember = "Id";

                // load ethnic
                EthnicComboBox.DataSource = managingStudentService.GetAllEthnic();
                EthnicComboBox.DisplayMember = "EthnicName";
                EthnicComboBox.ValueMember = "Id";

                // load ranking
                RankingComboBox.DataSource = managingStudentService.GetAllRanking();
                RankingComboBox.DisplayMember = "RankingName";
                RankingComboBox.ValueMember = "Id";

                // load gender
                GenderComboBox.Items.Add("Nam");
                GenderComboBox.Items.Add("Nữ");

                // load major
                List<MajorModel> majorModels = managingStudentService.GetAllMajor();
                majorModels.Add(new MajorModel()
                {
                    Id = -1,
                    MajorName = "Không có chuyên ngành"
                });
                MajorComboBox.DataSource = majorModels;
                MajorComboBox.DisplayMember = "MajorName";
                MajorComboBox.ValueMember = "Id";

                // load learning Mode
                LearningModeComboBox.DataSource = managingStudentService.GetAllLearningMode();
                LearningModeComboBox.DisplayMember = "LearningModeName";
                LearningModeComboBox.ValueMember = "Id";


                certModel = managingCertService.GetSingleCertById(_certId);
                studentModel = managingStudentService.GetSingleStudentById(certModel.StudentId);

                FullnameTextBox.Text = studentModel.FullName;
                SchoolComboBox.SelectedValue = studentModel.SchoolId;
                BornedAddressTextBox.Text = studentModel.BornedAddress;
                AddressTextBox.Text = studentModel.Address;
                DobTextBox.Text = studentModel.Dob.ToString("dd/MM/yyyy");
                HouseHoldTextBox.Text = studentModel.HouseHold;
                ScoreTextBox.Text = studentModel.Score.ToString();
                GraduatingYearTextBox.Text = studentModel.GraduatingYear.ToString();
                RankingComboBox.SelectedValue = studentModel.RankingId;
                MajorComboBox.SelectedValue = studentModel.MajorId;
                LearningModeComboBox.SelectedValue = studentModel.LearningModeId;
                EthnicComboBox.SelectedValue = studentModel.EthnicId;
                GenderComboBox.SelectedItem = studentModel.Gender;

                SerialTextBox.Text = certModel.Serial;
                ReferenceNumberTextBox.Text = certModel.ReferenceNumber;

                // load student image
                string imageName = managingStudentService.GetStudentImage(certModel.StudentId);
                if (string.IsNullOrEmpty(imageName))
                {
                    //MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh", "Lỗi", MessageBoxIcon.Error);
                    notificationForm.ShowDialog();
                    return;
                }
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                using (FileStream fs = new FileStream(Path.Combine(@"C:\JbCert_Resource\StudentImages\", imageName), FileMode.Open))
                {
                    StudentImagePictureBox.Image = Image.FromStream(fs);
                }

                // load blankcert image
                imageName = managingBlankCertService.GetBlankCertImage(certModel.BlankCertId);
                if (string.IsNullOrEmpty(imageName))
                {
                    //MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh", "Lỗi", MessageBoxIcon.Error);
                    notificationForm.ShowDialog();
                    return;
                }
                path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                using (FileStream fs = new FileStream(Path.Combine(@"C:\JbCert_Resource\Images\", imageName), FileMode.Open))
                {
                    BlankCertImagePictureBox.Image = Image.FromStream(fs);
                }
            }
            catch (FileNotFoundException FileNotFoundEx)
            {
                NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh, vui lòng cập nhật lại ảnh", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
            catch (Exception ex)
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

        private void ViewStudentImageButton_Click(object sender, EventArgs e)
        {
            string imageName = managingStudentService.GetStudentImage(certModel.StudentId);
            if (string.IsNullOrEmpty(imageName))
            {
                //MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh", "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
                return;
            }
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            ShowingImageForm showingImageForm = new ShowingImageForm(Path.Combine(@"C:\JbCert_Resource\StudentImages\", imageName));
            showingImageForm.ShowDialog();
        }

        private void ViewBlankCertImageButton_Click(object sender, EventArgs e)
        {
            string imageName = managingBlankCertService.GetBlankCertImage(certModel.BlankCertId);
            if (string.IsNullOrEmpty(imageName))
            {
                //MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh", "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
                return;
            }
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            ShowingImageForm showingImageForm = new ShowingImageForm(Path.Combine(@"C:\JbCert_Resource\Images\", imageName));
            showingImageForm.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(ScoreTextBox.Text);
            }
            catch (FormatException ex)
            {
                //MessageBox.Show("Điểm chỉ bao gồm số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Điểm chỉ bao gồm số", "Thông báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                ScoreTextBox.Focus();
                return;
            }

            DateTime dob;
            if (string.IsNullOrEmpty(DobTextBox.Text))
            {

                NotificationForm notificationForm = new NotificationForm("Điền ngày tháng năm sinh của học sinh", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }
            else
            {

                bool chValidity = DateTime.TryParseExact(
                 DobTextBox.Text,
                 "dd/MM/yyyy",
                 CultureInfo.InvariantCulture,
                 DateTimeStyles.None, out dob);
                if (!chValidity)
                {
                    NotificationForm notificationForm = new NotificationForm("Điền ngày tháng theo dạng dd/MM/yyyy ví dụ 12/07/2020", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }
            }

            try
            {
                int.Parse(GraduatingYearTextBox.Text);
            }
            catch (FormatException ex)
            {
                //MessageBox.Show("Năm tốt nghiệp chỉ bao gồm số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Năm tốt nghiệp chỉ bao gồm số", "Thông báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                GraduatingYearTextBox.Focus();
                return;
            }

            if (LearningModeComboBox.SelectedValue == null)
            {
                NotificationForm notificationForm = new NotificationForm("Chọn hình thức đào tạo", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            if (MajorComboBox.SelectedValue == null)
            {
                NotificationForm notificationForm = new NotificationForm("Chọn Chuyên ngành", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            if (RankingComboBox.SelectedValue == null)
            {
                NotificationForm notificationForm = new NotificationForm("Chọn xếp loại", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            if (GenderComboBox.SelectedItem == null)
            {
                NotificationForm notificationForm = new NotificationForm("Chọn giới tính", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            if (EthnicComboBox.SelectedValue == null)
            {
                NotificationForm notificationForm = new NotificationForm("Chọn dân tộc", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }
        }
    }
}
