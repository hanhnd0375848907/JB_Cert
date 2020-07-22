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
    public partial class SelectBlankCertForm : Form
    {
        private AddCertForm _addCertForm;
        private int _blankCertTypeId;
        private IManagingBlankCertService managingBlankCertService;
        private IManagingCertService managingCertService;
        private List<BlankCertModel> chosenBlankCertModels;
        public SelectBlankCertForm(AddCertForm addCertForm, int blankCertTypeId)
        {
            InitializeComponent();
            _addCertForm = addCertForm;
            managingBlankCertService = new ManagingBlankCertService();
            _blankCertTypeId = blankCertTypeId;
            chosenBlankCertModels = new List<BlankCertModel>();
            managingCertService = new ManagingCertService();
        }

        private void SelectBlankCertForm_Load(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _addCertForm.Close();
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _addCertForm.Show();
        }

        private void SearchBlankCertButton_Click(object sender, EventArgs e)
        {
            LoadBlankCert();
        }

        private void LoadBlankCert()
        {
            if (string.IsNullOrEmpty(SerialTextBox.Text))
            {
                SerialTextBox.Text = "";
            }
            List<BlankCertModel> blankCertModels = managingBlankCertService.SearchBlankCertFormForAddingCert(SerialTextBox.Text, _blankCertTypeId);
            BlankCertDataGridView.Rows.Clear();
            int i = 1;
            foreach(var blankCertModel in blankCertModels)
            {
                BlankCertDataGridView.Rows.Add
                (
                    blankCertModel.Id,
                    i++,
                    blankCertModel.Serial
                );
            }
        }

        private void BlankCertDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == BlankCertDataGridView.Columns["Select"].Index && e.RowIndex >= 0)
            {
                int blankCertId = int.Parse(BlankCertDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                ChangeDataChosenBlankCerts(blankCertId, true);
            }
            else if (e.ColumnIndex == BlankCertDataGridView.Columns["ShowImage"].Index && e.RowIndex >= 0)
            {
                int blankCertId = int.Parse(BlankCertDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                string imageName = managingBlankCertService.GetSingleById(blankCertId).Image;
                if (string.IsNullOrEmpty(imageName))
                {
                    MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                ShowingImageForm showingImageForm = new ShowingImageForm(Path.Combine(@"C:\JbCert_Resource\Images\", imageName));
                showingImageForm.ShowDialog();

            }
  
        }

        private void ChangeDataChosenBlankCerts(int blankCertId, bool doAdd)
        {
            try
            {
                if (chosenBlankCertModels.Any(x => x.Id == blankCertId) && doAdd)
                {
                    MessageBox.Show("Đã chọn phôi này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (doAdd)
                    {
                        BlankCertModel blankCertModel = managingBlankCertService.GetSingleById(blankCertId);
                        blankCertModel.ReferenceNumber = "";
                        chosenBlankCertModels.Add(blankCertModel);
                    }
                    else
                    {
                        chosenBlankCertModels.Remove(chosenBlankCertModels.Where(x => x.Id == blankCertId).FirstOrDefault());
                    }
                }
                LoadChosenBlankCerts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChosenBlankCerts()
        {
            ChosenBlankCertDataGridView.Rows.Clear();
            int i = 1;
            foreach (var chosenBlankCertModel in chosenBlankCertModels)
            {
                ChosenBlankCertDataGridView.Rows.Add
                (
                    chosenBlankCertModel.Id,
                    i++,
                    chosenBlankCertModel.Serial,
                    chosenBlankCertModel.ReferenceNumber
                );
            }

        }

        private void ChosenSearchBlankCertButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (string.IsNullOrEmpty(ChosenSerialTextBox.Text))
                {
                    ChosenSerialTextBox.Text = "";
                }

                ChosenBlankCertDataGridView.Rows.Clear();

                List<BlankCertModel> searchedChosenBlankCerts = new List<BlankCertModel>();

                searchedChosenBlankCerts = chosenBlankCertModels.Where(x => x.Serial.Contains(ChosenSerialTextBox.Text)).ToList();

                foreach (var searchChosenBlankCert in searchedChosenBlankCerts)
                {

                    ChosenBlankCertDataGridView.Rows.Add
                    (
                        searchChosenBlankCert.Id,
                        searchChosenBlankCert.Serial,
                        searchChosenBlankCert.ReferenceNumber
                    );

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetBlankCertButton_Click(object sender, EventArgs e)
        {
            SerialTextBox.Text = "";
            BlankCertDataGridView.Rows.Clear();
        }

        private void ChosenResetBlankCertButton_Click(object sender, EventArgs e)
        {
            ChosenSerialTextBox.Text = "";
            ChosenBlankCertDataGridView.Rows.Clear();
        }

        private void ChosenBlankCertDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ChosenBlankCertDataGridView.Columns["Remove"].Index && e.RowIndex >= 0)
            {
                int blankCertId = int.Parse(ChosenBlankCertDataGridView.Rows[e.RowIndex].Cells["ChosenId"].Value.ToString());
                ChangeDataChosenBlankCerts(blankCertId, false);
            }
            else if (e.ColumnIndex == ChosenBlankCertDataGridView.Columns["ChosenShowImage"].Index && e.RowIndex >= 0)
            {
                int blankCertId = int.Parse(ChosenBlankCertDataGridView.Rows[e.RowIndex].Cells["ChosenId"].Value.ToString());
                string imageName = managingBlankCertService.GetSingleById(blankCertId).Image;
                if (string.IsNullOrEmpty(imageName))
                {
                    MessageBox.Show("Không tìm thấy ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                ShowingImageForm showingImageForm = new ShowingImageForm(Path.Combine(@"C:\JbCert_Resource\Images\", imageName));
                showingImageForm.ShowDialog();

            }
        }

        private void ChosenBlankCertDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&e.ColumnIndex == ChosenBlankCertDataGridView.Columns["ChosenReferenceNumber"].Index)
            {
                int blankCertId = int.Parse(ChosenBlankCertDataGridView.Rows[e.RowIndex].Cells["ChosenId"].Value.ToString());
                DataGridViewTextBoxCell referenceNumberTextBoxCell = (DataGridViewTextBoxCell)ChosenBlankCertDataGridView.Rows[e.RowIndex].Cells["ChosenReferenceNumber"];
                string referenceNumber = "";
                if (referenceNumberTextBoxCell.Value != null)
                {
                    referenceNumber = referenceNumberTextBoxCell.Value.ToString();
                }
                else
                {
                    referenceNumber = "";
                }
                UpdateReferenceNumber(referenceNumber, blankCertId);
            }
        }

        private void ChosenBlankCertDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ChosenBlankCertDataGridView.IsCurrentCellDirty)
            {
                ChosenBlankCertDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void UpdateReferenceNumber(string referenceNumber, int blankCertId)
        {
            chosenBlankCertModels.Where(x => x.Id == blankCertId).FirstOrDefault().ReferenceNumber = referenceNumber;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (_addCertForm.chosenStudents.Count > chosenBlankCertModels.Count)
            {
                MessageBox.Show("Số lượng sinh viên nhiều hơn số lượng phôi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_addCertForm.chosenStudents.Count < chosenBlankCertModels.Count)
            {
                MessageBox.Show("Số lượng sinh viên ít hơn số lượng phôi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(CertNameTextBox.Text))
            {
                MessageBox.Show("Điền tên bằng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CertNameTextBox.Focus();
                return;
            }

            BlankCertModel blankCertModel = chosenBlankCertModels.Where(x => string.IsNullOrEmpty(x.ReferenceNumber)).FirstOrDefault();
            if (blankCertModel != null)
            {
                MessageBox.Show("Số vào sổ của phôi có số hiệu" + blankCertModel.Serial + " đang trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                int result = managingCertService.AddManyCerts(chosenBlankCertModels, _addCertForm.chosenStudents, CertNameTextBox.Text);
                if (result == _addCertForm.chosenStudents.Count)
                {
                    MessageBox.Show("Thêm thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
