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
    public partial class AddCertForm : Form
    {
        IManagingSchoolService managingSchoolService;
        IManagingStudentService managingStudentService;
        public List<StudentModel> chosenStudents;
        int _blankCertTypeId;

        public AddCertForm(int blankCertTypeId)
        {
            InitializeComponent();
            managingSchoolService = new ManagingSchoolService();
            chosenStudents = new List<StudentModel>();
            managingStudentService = new ManagingStudentService();
            _blankCertTypeId = blankCertTypeId;
        }

        private void AddCertForm_Load(object sender, EventArgs e)
        {
            // School
            List<SchoolModel> schoolModels = managingSchoolService.GetAllSchoolByBlankCertTypeId(_blankCertTypeId);
            schoolModels.Add(new SchoolModel()
            {
                Id = -1,
                SchoolName = "Tất cả"
            });
            SchoolComboBox.DataSource = schoolModels.OrderBy(x => x.Id).ToList();
            SchoolComboBox.DisplayMember = "SchoolName";
            SchoolComboBox.ValueMember = "Id";

            List<SchoolModel> chosenSchoolModels = managingSchoolService.GetAllSchoolByBlankCertTypeId(_blankCertTypeId);
            chosenSchoolModels.Add(new SchoolModel()
            {
                Id = -1,
                SchoolName = "Tất cả"
            });
            ChosenSchoolComboBox.DataSource = chosenSchoolModels.OrderBy(x => x.Id).ToList();
            ChosenSchoolComboBox.DisplayMember = "SchoolName";
            ChosenSchoolComboBox.ValueMember = "Id";


        }

        private void LoadStudent()
        {
            try
            {
                if (string.IsNullOrEmpty(StudentNameTextBox.Text))
                {
                    StudentNameTextBox.Text = "";
                }
                List<StudentModel> studentModels = managingStudentService.SearchStudentForAddingCert(StudentNameTextBox.Text, int.Parse(SchoolComboBox.SelectedValue.ToString()));
                StudentDataGridView.Rows.Clear();
                if (studentModels == null || studentModels.Count == 0)
                {
                    //MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationForm notificationForm = new NotificationForm("Không tìm thấy dữ liệu", "Thông báo", MessageBoxIcon.Information);
                    notificationForm.ShowDialog();
                    return;
                }
                int i = 1;
                foreach (var studentModel in studentModels)
                {
                    StudentDataGridView.Rows.Add
                    (
                        studentModel.Id,
                        i++,
                        studentModel.FullName,
                        studentModel.IdentityNumber,
                        studentModel.RankingName
                    );
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChosenStudents()
        {
            try
            {
                ChosenStudentDataGridView.Rows.Clear();
                if (string.IsNullOrEmpty(ChosenStudentNameTextBox.Text))
                {
                    ChosenStudentNameTextBox.Text = "";
                }
                List<StudentModel> searchedChosenStudents = new List<StudentModel>();
                int schoolId = int.Parse(ChosenSchoolComboBox.SelectedValue.ToString());

                searchedChosenStudents = chosenStudents.Where(x => x.FullName.Contains(ChosenStudentNameTextBox.Text)
                                                                    && ( (schoolId == -1) || (x.SchoolId == schoolId) ) )
                                                                    .ToList();
                int i = 1;
                foreach (var chosenStudent in searchedChosenStudents)
                {

                    ChosenStudentDataGridView.Rows.Add
                    (
                        chosenStudent.Id,
                        i++,
                        chosenStudent.FullName,
                        chosenStudent.IdentityNumber,
                        chosenStudent.RankingName
                    ); ;

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }


        private void StudentSearchButton_Click(object sender, EventArgs e)
        {
            if (SchoolComboBox.SelectedValue == null)
            {
                NotificationForm notificationForm = new NotificationForm("Giá trị trường học không tồn tại", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }

            LoadStudent();
        }



        private void ChosenStudentSearchButton_Click(object sender, EventArgs e)
        {
            if (ChosenSchoolComboBox.SelectedValue == null)
            {
                NotificationForm notificationForm = new NotificationForm("Giá trị trường học không tồn tại", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }
            LoadChosenStudents();
        }

        private void ChangeDataChosenStudents(int studentId, bool isAdd)
        {
            if (chosenStudents.Any(x => x.Id == studentId) && isAdd)
            {
                MessageBox.Show("Đã chọn học sinh này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Đã chọn học sinh này", "Thông báo", MessageBoxIcon.Information);
                notificationForm.ShowDialog();
                return;
            }
            else
            {
                if (isAdd)
                {
                    // add
                    StudentModel studentModel = managingStudentService.GetSingleStudentById(studentId);
                    RankingModel defaultRankingStudent = managingStudentService.GetAllRanking().FirstOrDefault();
                    studentModel.RankingId = defaultRankingStudent.Id;
                    studentModel.RankingName = defaultRankingStudent.RankingName;
                    chosenStudents.Add(studentModel);
                }
                else
                {
                    // remove
                    chosenStudents.Remove(chosenStudents.Where(x => x.Id == studentId).FirstOrDefault());
                }
                LoadChosenStudents();
            }
        }

        private void StudentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == StudentDataGridView.Columns["Select"].Index && e.RowIndex >= 0)
            {
                int studentId = int.Parse(StudentDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                ChangeDataChosenStudents(studentId, true);
            }
            else if (e.ColumnIndex == StudentDataGridView.Columns["ShowImage"].Index && e.RowIndex >= 0)
            {
                int studentId = int.Parse(StudentDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                string imageName = managingStudentService.GetStudentImage(studentId);
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
            else if (e.ColumnIndex == StudentDataGridView.Columns["Detail"].Index && e.RowIndex >= 0)
            {
                int studentId = int.Parse(StudentDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DetailStudentForm detailStudentForm = new DetailStudentForm(studentId);
                detailStudentForm.ShowDialog();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            StudentNameTextBox.Text = "";
            SchoolComboBox.SelectedIndex = 0;
            LoadStudent();
        }

        private void ChosenResetButton_Click(object sender, EventArgs e)
        {
            ChosenSchoolComboBox.SelectedIndex = 0;
            ChosenStudentNameTextBox.Text = "";
            LoadChosenStudents();
        }

        private void ChosenStudentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ChosenStudentDataGridView.Columns["ChosenRemove"].Index && e.RowIndex >= 0)
            {
                int studentId = int.Parse(ChosenStudentDataGridView.Rows[e.RowIndex].Cells["ChosenId"].Value.ToString());
                ChangeDataChosenStudents(studentId, false);
            }
            else if (e.ColumnIndex == StudentDataGridView.Columns["ShowImage"].Index && e.RowIndex >= 0)
            {
                int studentId = int.Parse(ChosenStudentDataGridView.Rows[e.RowIndex].Cells["ChosenId"].Value.ToString());
                string imageName = managingStudentService.GetStudentImage(studentId);
                if (string.IsNullOrEmpty(imageName))
                {
                    //MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh", "Lỗi", MessageBoxIcon.Error);
                    notificationForm.ShowDialog();
                    return;
                }
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                ShowingImageForm showingImageForm = new ShowingImageForm(Path.Combine(@"C:\JbCert_Resource\StudentImages", imageName));
                showingImageForm.ShowDialog();

            }
            else if (e.ColumnIndex == StudentDataGridView.Columns["Detail"].Index && e.RowIndex >= 0)
            {
                int studentId = int.Parse(ChosenStudentDataGridView.Rows[e.RowIndex].Cells["ChosenId"].Value.ToString());
                DetailStudentForm detailStudentForm = new DetailStudentForm(studentId);
                detailStudentForm.ShowDialog();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (chosenStudents.Count == 0)
            {
                MessageBox.Show("Chọn tối thiểu 1 sinh viên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationForm notificationForm = new NotificationForm("Chọn tối thiểu 1 sinh viên", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
                return;
            }
            SelectBlankCertForm selectBlankCertForm = new SelectBlankCertForm(this, _blankCertTypeId);
            selectBlankCertForm.ShowDialog();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
