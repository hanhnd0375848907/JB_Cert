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
    public partial class AddStudentForm : Form
    {
        string imageLocation, saveFileName, extension;
        IManagingStudentService managingStudentService;
        IManagingSchoolService managingSchoolService;

        public delegate void AddStudent();
        public static event AddStudent OnStudentAdded;

        public AddStudentForm()
        {
            InitializeComponent();
            managingStudentService = new ManagingStudentService();
            managingSchoolService = new ManagingSchoolService();

            OnStudentAdded += AddStudentForm_OnStudentAdded;
        }

        private void AddStudentForm_OnStudentAdded()
        {

        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            // load school
            SchoolComboBox.DataSource = managingSchoolService.GetAllSchool();
            SchoolComboBox.DisplayMember = "SchoolName";
            SchoolComboBox.ValueMember = "Id";

            // load ranking
            RankingComboBox.DataSource = managingStudentService.GetAllRanking();
            RankingComboBox.DisplayMember = "RankingName";
            RankingComboBox.ValueMember = "Id";

            // load major
            List<MajorModel> majorModels = managingStudentService.GetAllMajor();
            majorModels.Add(new MajorModel()
            {
                Id = -1,
                MajorName = "Không có ngành đào tạo",
                IsDeleted = false,
                Note = ""
            });
            MajorComboBox.DataSource = majorModels.OrderBy(x => x.Id).ToList();
            MajorComboBox.DisplayMember = "MajorName";
            MajorComboBox.ValueMember = "Id";
            MajorComboBox.SelectedIndex = 0;

            // load learning mode
            LearningModeComboBox.DataSource = managingStudentService.GetAllLearningMode();
            LearningModeComboBox.DisplayMember = "LearningModeName";
            LearningModeComboBox.ValueMember = "Id";

            // load ethnic
            EthnicComboBox.DataSource = managingStudentService.GetAllEthnic();
            EthnicComboBox.DisplayMember = "EthnicName";
            EthnicComboBox.ValueMember = "Id";

            // load gender
            GenderComboBox.Items.Add("Nam");
            GenderComboBox.Items.Add("Nữ");
            GenderComboBox.SelectedIndex = 0;

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    float.Parse(ScoreTextBox.Text);
                }
                catch(FormatException ex)
                {
                    //MessageBox.Show("Điểm chỉ bao gồm số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Điểm chỉ bao gồm số", "Thông báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    ScoreTextBox.Focus();
                    return;
                }

                try
                {
                    int graduatingYear = int.Parse(GraduatingYearTextBox.Text);
                    int currentYear = DateTime.Now.Year;
                    if (graduatingYear < 1000 || graduatingYear > currentYear)
                    {
                        NotificationForm notificationForm = new NotificationForm("Năm tốt nghiệp nằm ngoài phạm vi cho phep", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                        GraduatingYearTextBox.Focus();
                        return;
                    }
                }
                catch (FormatException ex)
                {
                    //MessageBox.Show("Năm tốt nghiệp chỉ bao gồm số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Năm tốt nghiệp chỉ bao gồm số", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    GraduatingYearTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(FullnameTextBox.Text))
                {
                    //MessageBox.Show("Nhập tên học sinh / sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Nhập tên học sinh / sinh viên", "Thông báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(AddressTextBox.Text))
                {
                    //MessageBox.Show("Nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Nhập địa chỉ", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(BornedAddressTextBox.Text))
                {
                    //MessageBox.Show("Nhập nơi sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Nhập nơi sinh", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }


                if (string.IsNullOrEmpty(HouseHoldTextBox.Text))
                {
                    //MessageBox.Show("Nhập hộ khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Nhập hộ khẩu", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(IdentityTextBox.Text))
                {
                    //MessageBox.Show("Nhập chứng minh thư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Nhập chứng minh thư", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(imageLocation))
                {
                    //MessageBox.Show("Thêm ảnh học sinh / sinh viên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Thêm ảnh học sinh", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
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

                if (SchoolComboBox.SelectedValue == null)
                {
                    NotificationForm notificationForm = new NotificationForm("Chọn trường học", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
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


                saveFileName = FullnameTextBox.Text + "_" + IdentityTextBox.Text;

                StudentModel studentModel = new StudentModel();
                studentModel.FullName = FullnameTextBox.Text;
                studentModel.Address = AddressTextBox.Text;
                studentModel.HouseHold = HouseHoldTextBox.Text;
                studentModel.IdentityNumber = IdentityTextBox.Text;
                studentModel.Note = NoteRichTextBox.Text;
                studentModel.Gender = GenderComboBox.SelectedItem.ToString();
                studentModel.SchoolId = int.Parse(SchoolComboBox.SelectedValue.ToString());
                studentModel.EthnicId = int.Parse(EthnicComboBox.SelectedValue.ToString());
                studentModel.GraduatingYear = int.Parse(GraduatingYearTextBox.Text);
                studentModel.LearningModeId = int.Parse(LearningModeComboBox.SelectedValue.ToString());
                studentModel.MajorId = int.Parse(MajorComboBox.SelectedValue.ToString());
                studentModel.RankingId = int.Parse(RankingComboBox.SelectedValue.ToString());
                studentModel.Dob = dob;
                studentModel.Score = float.Parse(ScoreTextBox.Text);
                studentModel.BornedAddress = BornedAddressTextBox.Text;
                studentModel.BlankCertTypeId = managingSchoolService.GetSingleSchoolById(int.Parse(SchoolComboBox.SelectedValue.ToString())).BlankCertTypeId;
                studentModel.Image = saveFileName + extension;

                // add avatar image to StudentImages folder
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                int result = managingStudentService.AddStudent(studentModel);
                if (result > 0)
                {
                    File.Copy(imageLocation, Path.Combine(@"C:\JbCert_Resource\StudentImages", saveFileName + extension));
                    //MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Thêm thành công", "Cảnh báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    OnStudentAdded();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AvatarButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofDlg = new OpenFileDialog();
                ofDlg.Filter = "JPG|*.jpg|GIF|*.gif|PNG|*.png|BMP|*.bmp";
                if (DialogResult.OK == ofDlg.ShowDialog())
                {
                    imageLocation = ofDlg.FileName;
                    extension = Path.GetExtension(imageLocation);
                    AvatarPictureBox.Enabled = true;
                    AvatarPictureBox.Image = null;
                    using (FileStream fs = new FileStream(imageLocation, FileMode.Open))
                    {
                        AvatarPictureBox.Image = Image.FromStream(fs);
                    }
                    //AvatarPictureBox.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
