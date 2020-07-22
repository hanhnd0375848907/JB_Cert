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
    public partial class PrintRootCertForm : Form
    {
        IManagingCertService managingCertService;
        IManagingBlankCertService managingBlankCertService;
        IManagingStudentService managingStudentService;
        IManagingSchoolService managingSchoolService;
        List<int> chosenCertIdList;
        public PrintRootCertForm()
        {
            InitializeComponent();
            managingCertService = new ManagingCertService();
            managingStudentService = new ManagingStudentService();
            managingBlankCertService = new ManagingBlankCertService();
            chosenCertIdList = new List<int>();
            managingSchoolService = new ManagingSchoolService();
        }

        private void PrintRootCertForm_Load(object sender, EventArgs e)
        {
            // load school
            List<SchoolModel> schoolModels = managingSchoolService.GetAllSchool();
            schoolModels.Add(new SchoolModel()
            {
                Id = -1,
                SchoolName = "Tất cả"
            });
            SchoolComboBox.DataSource = schoolModels.OrderBy(x => x.Id).ToList();
            SchoolComboBox.DisplayMember = "SchoolName";
            SchoolComboBox.ValueMember = "Id";

            // load ischeckedcombobox
            IsCheckedComboBox.Items.Add("Tất cả");
            IsCheckedComboBox.Items.Add("Đang chọn");
            IsCheckedComboBox.Items.Add("Chưa chọn");
            IsCheckedComboBox.SelectedIndex = 0;
            // load cert
            LoadCertList();
        }

        private void LoadCertList()
        {
            List<CertModel> certModels = managingCertService.GetAllNotPrintedCert();
            CertDataGridView.Rows.Clear();
            List<CertModel> resultList = null;
            if (IsCheckedComboBox.SelectedIndex == 0) // All
            {
                resultList = certModels;
            }
            else if (IsCheckedComboBox.SelectedIndex == 1) // checked
            {
                resultList = certModels.Where(x => chosenCertIdList.Any(y => y == x.Id)).ToList() ;
            }
            else if (IsCheckedComboBox.SelectedIndex == 2) // not checked
            {
                resultList = certModels.Where(x => !chosenCertIdList.Any(y => y == x.Id)).ToList();
            }

            int i = 1;
            foreach (var certModel in resultList)
            {
                
                CertDataGridView.Rows.Add
                (
                    chosenCertIdList.Any(x => x == certModel.Id),
                    certModel.Id,
                    i++,
                    certModel.StudentName,
                    certModel.SchoolName,
                    certModel.Serial,
                    certModel.ReferenceNumber
                );
            }
        }

        private void CertDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == CertDataGridView.Columns["ViewStudentImage"].Index && e.RowIndex >= 0)
            {
                int certId = int.Parse(CertDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                CertModel certModel = managingCertService.GetSingleCertById(certId);
                string imageName = managingStudentService.GetStudentImage(certModel.StudentId);
                if (string.IsNullOrEmpty(imageName))
                {
                    MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                ShowingImageForm showingImageForm = new ShowingImageForm(Path.Combine(@"C:\JbCert_Resource\StudentImages\", imageName));
                showingImageForm.ShowDialog();
            }
            else if (e.ColumnIndex == CertDataGridView.Columns["ViewBlankCertImage"].Index && e.RowIndex >= 0)
            {
                int certId = int.Parse(CertDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                CertModel certModel = managingCertService.GetSingleCertById(certId);
                string imageName = managingBlankCertService.GetBlankCertImage(certModel.BlankCertId);
                if (string.IsNullOrEmpty(imageName))
                {
                    MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                ShowingImageForm showingImageForm = new ShowingImageForm(Path.Combine(@"C:\JbCert_Resource\Images\", imageName));
                showingImageForm.ShowDialog();

            }
            else if (e.ColumnIndex == CertDataGridView.Columns["Detail"].Index && e.RowIndex >= 0)
            {
                int certId = int.Parse(CertDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());

            }
        }

        private void OpenPrintOptionFormButton_Click(object sender, EventArgs e)
        {
            if (chosenCertIdList.Count == 0)
            {
                MessageBox.Show("Chọn ít nhất 1 bằng để in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PrintOptionForm printOptionForm = new PrintOptionForm(chosenCertIdList);
            printOptionForm.ShowDialog();
        }

        private void CertDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == CertDataGridView.Columns["Select"].Index)
            {
                int certId = int.Parse(CertDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DataGridViewCheckBoxCell selectCheckBoxCell = (DataGridViewCheckBoxCell)CertDataGridView.Rows[e.RowIndex].Cells["select"];
                bool isChecked = (bool)selectCheckBoxCell.Value;
                if (isChecked)
                {
                    chosenCertIdList.Add(certId);
                }
                else
                {
                    chosenCertIdList.Remove(certId);
                }
            }
        }

        private void CertDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (CertDataGridView.IsCurrentCellDirty)
            {
                CertDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchCertListBySchool();
        }

        private void SearchCertListBySchool()
        {
            try
            {
                int schoolId = int.Parse(SchoolComboBox.SelectedValue.ToString());
                if (schoolId == -1)
                {
                    LoadCertList();
                }
                else
                {
                    List<CertModel> certModels = managingCertService.GetAllNotPrintedCertBySchool(schoolId);
                    List<CertModel> resultList = null;
                    if (IsCheckedComboBox.SelectedIndex == 0) // All
                    {
                        resultList = certModels;
                    }
                    else if (IsCheckedComboBox.SelectedIndex == 1) // checked
                    {
                        resultList = certModels.Where(x => chosenCertIdList.Any(y => y == x.Id)).ToList();
                    }
                    else if (IsCheckedComboBox.SelectedIndex == 2) // not checked
                    {
                        resultList = certModels.Where(x => !chosenCertIdList.Any(y => y == x.Id)).ToList();
                    }

                    CertDataGridView.Rows.Clear();
                    int i = 1;
                    foreach (var certModel in resultList)
                    {
                        CertDataGridView.Rows.Add
                        (
                            chosenCertIdList.Any(x => x == certModel.Id),
                            certModel.Id,
                            i++,
                            certModel.StudentName,
                            certModel.SchoolName,
                            certModel.Serial,
                            certModel.ReferenceNumber
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
