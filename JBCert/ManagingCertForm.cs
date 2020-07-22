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
    public partial class ManagingCertForm : Form
    {
        IManagingCertService managingCertService;
        IManagingStudentService managingStudentService;
        IManagingBlankCertService managingBlankCertService;
        IManagingSchoolService managingSchoolService;
        public ManagingCertForm()
        {
            InitializeComponent();
            managingCertService = new ManagingCertService();
            managingStudentService = new ManagingStudentService();
            managingBlankCertService = new ManagingBlankCertService();
            managingSchoolService = new ManagingSchoolService();
        }

        private void ManagingCertForm_Load(object sender, EventArgs e)
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


            LoadCert();
        }

        private void LoadCert()
        {
            List<CertModel> certModels = managingCertService.GetAllCert();
            CertDataGridView.Rows.Clear();
            int i = 1;
            foreach (var certModel in certModels)
            {
                CertDataGridView.Rows.Add
                (
                    certModel.Id,
                    false,
                    i++,
                    certModel.StudentName,
                    certModel.RankingName,
                    certModel.CertName,
                    certModel.SchoolName,
                    certModel.Serial,
                    certModel.ReferenceNumber,
                    certModel.ProviderName,
                    certModel.Position,
                    certModel.GrantedDate.ToShortDateString(),
                    certModel.GrantedAddress,
                    certModel.ReceiverName,
                    certModel.ReceiverIdentityNumber,
                    certModel.IsGranted == true ? "Đã cấp" : "Chưa cấp",
                    certModel.IsPrinted == true ? "Đã in" : "Chưa in"

                );
            }
        }

        private void AddCertButton_Click(object sender, EventArgs e)
        {
            SelectBlankCertTypeForm addCertForm = new SelectBlankCertTypeForm();
            addCertForm.ShowDialog();
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
                    //MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
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
                    //MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NotificationForm notificationForm = new NotificationForm("Không tìm thấy ảnh", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                    return;
                }
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                ShowingImageForm showingImageForm = new ShowingImageForm(Path.Combine(@"C:\JbCert_Resource\Images\", imageName));
                showingImageForm.ShowDialog();

            }
            //else if (e.ColumnIndex == CertDataGridView.Columns["Edit"].Index && e.RowIndex >= 0)
            //{
            //    int certId = int.Parse(CertDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            //    EditCertForm editCertForm = new EditCertForm(certId);
            //    editCertForm.ShowDialog();
            //}
            //else if (e.ColumnIndex == CertDataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
            //{
            //    DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            int certId = int.Parse(CertDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            //            int result = managingCertService.DeleteCert(certId);
            //            if (result > 0)
            //            {
            //                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                LoadCert();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        //no delete
            //    }

            //}
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string studentName = "";
                int schoolId = -1;
                string serial = "";
                string referenceNumber = "";

                if (!string.IsNullOrEmpty(FullNameTextBox.Text))
                {
                    studentName = FullNameTextBox.Text;
                }

                if (!string.IsNullOrEmpty(SerialTextBox.Text))
                {
                    serial = SerialTextBox.Text;
                }

                if (!string.IsNullOrEmpty(ReferenceNumberTextBox.Text))
                {
                    referenceNumber = ReferenceNumberTextBox.Text;
                }

                schoolId = int.Parse(SchoolComboBox.SelectedValue.ToString());

                List<CertModel> certModels = managingCertService.SearchCert(studentName, schoolId, serial, referenceNumber);
                CertDataGridView.Rows.Clear();
                int i = 1;
                foreach (var certModel in certModels)
                {
                    CertDataGridView.Rows.Add
                    (
                        certModel.Id,
                        false,
                        i++,
                        certModel.StudentName,
                        certModel.RankingName,
                        certModel.CertName,
                        certModel.SchoolName,
                        certModel.Serial,
                        certModel.ReferenceNumber,
                        certModel.ProviderName,
                        certModel.Position,
                        certModel.GrantedDate.ToShortDateString(),
                        certModel.GrantedAddress,
                        certModel.ReceiverName,
                        certModel.ReceiverIdentityNumber,
                        certModel.IsGranted == true ? "Đã cấp" : "Chưa cấp",
                        certModel.IsPrinted == true ? "Đã in" : "Chưa in"

                    );
                }
            }
            catch(Exception ex)
            {
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> certIds = (from DataGridViewRow r in CertDataGridView.Rows
                                     where Convert.ToBoolean(r.Cells[1].Value) == true
                                     select Convert.ToInt32(r.Cells[0].Value)).ToList();
                if (certIds.Count == 1)
                {
                    int certId = certIds.FirstOrDefault();
                    EditCertForm editCertForm = new EditCertForm(certId);
                    editCertForm.ShowDialog();
                }
                else if (certIds.Count == 0)
                {
                    //MessageBox.Show("Chưa chọn văn bằng nào", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chưa chọn văn bằng nào", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("Chỉ được chọn 1 văn bằng để sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NotificationForm notificationForm = new NotificationForm("Chỉ được chọn 1 văn bằng để sửa", "Cảnh báo", MessageBoxIcon.Warning);
                    notificationForm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> certIds = (from DataGridViewRow r in CertDataGridView.Rows
                                     where Convert.ToBoolean(r.Cells[1]) == true
                                     select Convert.ToInt32(r.Cells[0])).ToList();
                //DialogResult dialogResult = MessageBox.Show("Đồng ý xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    int result = managingCertService.DeleteManyCert(certIds);
                //    if (result > 0)
                //    {
                //        //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                //        notificationForm.ShowDialog();
                //        LoadCert();
                //    }
                //    else
                //    {
                //        //MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        NotificationForm notificationForm = new NotificationForm("Xóa không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                //        notificationForm.ShowDialog();
                //    }
                //}

                ConfirmForm confirmForm = new ConfirmForm("Đồng ý xóa ?");
                confirmForm.ShowDialog();
                if(confirmForm.Result == DialogResult.Yes)
                {
                    int result = managingCertService.DeleteManyCert(certIds);
                    if (result > 0)
                    {
                        //MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotificationForm notificationForm = new NotificationForm("Xóa thành công", "Thông báo", MessageBoxIcon.Information);
                        notificationForm.ShowDialog();
                        LoadCert();
                    }
                    else
                    {
                        //MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NotificationForm notificationForm = new NotificationForm("Xóa không thành công", "Cảnh báo", MessageBoxIcon.Warning);
                        notificationForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        private void DeSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in CertDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = false;
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in CertDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = true;
            }
        }
    }
}
