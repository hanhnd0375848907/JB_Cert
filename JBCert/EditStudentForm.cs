using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class EditStudentForm : Form
    {
        private int _studentId;
        string imageLocation, saveFileName, extension;
        IManagingStudentService managingStudentService;
        IManagingSchoolService managingSchoolService;
        string oldAvatar;

        public delegate void UpdateStudent();
        public static event UpdateStudent OnStudentUpdated;
        public EditStudentForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
            managingSchoolService = new ManagingSchoolService();
            managingStudentService = new ManagingStudentService();
            OnStudentUpdated += EditStudentForm_OnStudentUpdated;
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
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FullnameTextBox.Text))
                {
                    //MessageBox.Show("Nhập tên học sinh", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Nhập tên học sinh", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(AddressTextBox.Text))
                {
                    //MessageBox.Show("Nhập địa chỉ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Nhập địa chỉ", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(BornedAddressTextBox.Text))
                {
                    //MessageBox.Show("Nhập nơi sinh", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Nhập nơi sinh", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }


                if (string.IsNullOrEmpty(HouseHoldTextBox.Text))
                {
                    //MessageBox.Show("Nhập hộ khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Nhập hộ khẩu", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }

                if (string.IsNullOrEmpty(IdentityTextBox.Text))
                {
                    //MessageBox.Show("Nhập chứng minh thư", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Nhập chứng minh thư", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog(); 
                    return;
                }

                
                saveFileName = FullnameTextBox.Text + "_" + IdentityTextBox.Text;

                StudentModel studentModel = new StudentModel();
                studentModel.Id = _studentId;
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
                studentModel.BlankCertTypeId = managingSchoolService.GetSingleSchoolById(int.Parse(SchoolComboBox.SelectedValue.ToString())).BlankCertTypeId;
                studentModel.Dob = DobDateTimePicker.Value;
                studentModel.Score = int.Parse(ScoreTextBox.Text);
                studentModel.BornedAddress = BornedAddressTextBox.Text;
                if (string.IsNullOrEmpty(imageLocation))
                {
                    studentModel.Image = oldAvatar;
                }
                else
                {
                    studentModel.Image = saveFileName + extension;
                }
                // add avatar image to StudentImages folder
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                int result = managingStudentService.UpdateStudent(studentModel);
                if (result > 0)
                {
                    if (!string.IsNullOrEmpty(imageLocation))
                    {
                        File.Delete(Path.Combine(@"C:\JbCert_Resource\StudentImages", oldAvatar));
                        File.Copy(imageLocation, Path.Combine(@"C:\JbCert_Resource\StudentImages", saveFileName + extension));
                    }
                    //MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Lưu thành công", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    OnStudentUpdated();
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("Lưu không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Lưu không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
        }

        private void EditStudentForm_OnStudentUpdated()
        {
        }

        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            try
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


                // load current student
                StudentModel studentModel = managingStudentService.GetSingleStudentById(_studentId);
                FullnameTextBox.Text = studentModel.FullName;
                AddressTextBox.Text = studentModel.Address;
                BornedAddressTextBox.Text = studentModel.BornedAddress;
                HouseHoldTextBox.Text = studentModel.HouseHold;
                IdentityTextBox.Text = studentModel.IdentityNumber;
                ScoreTextBox.Text = studentModel.Score.ToString();
                GraduatingYearTextBox.Text = studentModel.GraduatingYear.ToString();
                DobDateTimePicker.Value = studentModel.Dob;
                NoteRichTextBox.Text = studentModel.Note;
                SchoolComboBox.SelectedValue = studentModel.SchoolId;
                MajorComboBox.SelectedValue = studentModel.MajorId;
                GenderComboBox.SelectedItem = studentModel.Gender;
                LearningModeComboBox.SelectedValue = studentModel.LearningModeId;
                RankingComboBox.SelectedValue = studentModel.RankingId;
                oldAvatar = studentModel.Image;

                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                using (FileStream fs = new FileStream(Path.Combine(@"C:\JbCert_Resource\StudentImages", studentModel.Image), FileMode.Open))
                {
                    AvatarPictureBox.Image = Image.FromStream(fs);
                }

            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
        }
    }
}
