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
    public partial class DetailStudentForm : Form
    {
        IManagingStudentService managingStudentService;
        int _studentId;
        public DetailStudentForm(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
            managingStudentService = new ManagingStudentService();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailStudentForm_Load(object sender, EventArgs e)
        {
            try
            {
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
                SchoolTextBox.Text = studentModel.SchoolName;
                MajorTextBox.Text = studentModel.MajorName;
                EthnicTextBox.Text = studentModel.EthnicName;
                GenderTextBox.Text = studentModel.Gender;
                LearningModeTextBox.Text = studentModel.LearningModeName;
                RankingTextBox.Text = studentModel.RankingName;

                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                using (FileStream fs = new FileStream(Path.Combine(@"C:\JbCert_Resource\StudentImages\", studentModel.Image), FileMode.Open))
                {
                    AvatarPictureBox.Image = Image.FromStream(fs);
                }

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
