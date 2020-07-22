using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Printing;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class PrintOptionForm : Form
    {
        List<int> _certIds;
        IManagingCertService managingCertService;
        IManagingBlankCertConfigService managingBlankCertConfigService;
        IManagingBlankCertTypeService managingBlankCertTypeService;
        IManagingStudentService managingStudentService;
        int blankCertTypeId, i;
        BlankCertConfigModel blankCertConfigModel;
        public PrintOptionForm(List<int> certIds)
        {
            InitializeComponent();
            _certIds = certIds;
            managingCertService = new ManagingCertService();
            managingBlankCertConfigService = new ManagingBlankCertConfigService();
            managingBlankCertTypeService = new ManagingBlankCertTypeService();
            managingStudentService = new ManagingStudentService();
        }

        private void PrintOptionForm_Load(object sender, EventArgs e)
        {
            try
            {
                NumberOfDocumentLabel.Text = _certIds.Count + " bản gốc";

                // load printers
                //See if any printers are installed  
                if (PrinterSettings.InstalledPrinters.Count <= 0)
                {
                    MessageBox.Show("Printer not found!");
                    return;
                }

                //Get all available printers and add them to the combo box  
                foreach (String printer in PrinterSettings.InstalledPrinters)
                {
                    PrinterComboBox.Items.Add(printer.ToString());
                }
                PrinterComboBox.SelectedIndex = 0;

                LoadCertList();

                // load blank cert type
                BlankCertTypeComboBox.DataSource = managingBlankCertTypeService.GetAllBlankCertType();
                BlankCertTypeComboBox.DisplayMember = "Name";
                BlankCertTypeComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCertList()
        {
            CertDataGridView.Rows.Clear();
            foreach (var certId in _certIds)
            {
                CertModel certModel = managingCertService.GetSingleCertById(certId);
                int i = 1;
                CertDataGridView.Rows.Add
                (
                    certModel.IsPrinted,
                    certModel.Id,
                    i++,
                    certModel.StudentName,
                    certModel.SchoolName,
                    certModel.Serial,
                    certModel.ReferenceNumber
                );

            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
            try
            {
                blankCertConfigModel = managingBlankCertConfigService.GetSingleByBlankCertType(blankCertTypeId);
                BlankCertTypeComboBox.Enabled = false;
                //Create a PrintDocument object  
                PrintDocument pd = new PrintDocument();

                //Set PrinterName as the selected printer in the printers list  
                pd.PrinterSettings.PrinterName = PrinterComboBox.SelectedItem.ToString();

                //Add PrintPage event handler  
                pd.PrintPage += Pd_PrintPage;
                pd.EndPrint += Pd_EndPrint;
                

                foreach (var certId in _certIds)
                {
                    pd.DocumentName = certId.ToString();
                    pd.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("In không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pd_EndPrint(object sender, PrintEventArgs e)
        {
            // update your fields.
            CertDataGridView.Rows[i++].Cells[0].Value = true;
        }

        private void BlankCertTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                blankCertTypeId = int.Parse(BlankCertTypeComboBox.SelectedValue.ToString());
            }
            catch
            {

            }
        }

        private void CertDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int certId = int.Parse(((PrintDocument)sender).DocumentName);
            CertModel certModel = managingCertService.GetSingleCertById(certId);
            StudentModel studentModel = managingStudentService.GetSingleStudentById(certModel.StudentId);
            BlankCertConfigModel blankCertConfigModel = managingBlankCertConfigService.GetSingleByBlankCertType(blankCertTypeId);
            //Get the Graphics object  
            Graphics g = e.Graphics;

            //Create a font Arial with size 16  
            Font font = new Font("Arial", 16);

            //Create a solid brush with black color  
            SolidBrush brush = new SolidBrush(Color.Black);

            if (blankCertTypeId == (int)Common.BlankCertType.HightSchool)
            {
                //g.DrawString("Hanhsama " + certId,
                //   font, brush,
                //   new Rectangle(20, 70, 200, 100));

                //g.DrawString(studentModel.GraduatingYear.ToString(),
                //   font, brush,
                //   new Rectangle(blankCertConfigModel., 200, 100));
                // thieu graduating year trong blankcertconfig

            }
            else if(blankCertTypeId == (int)Common.BlankCertType.JuniorHighSchool)
            {

            }
            else if (blankCertTypeId == (int)Common.BlankCertType.University)
            {

            }
            else if (blankCertTypeId == (int)Common.BlankCertType.Master)
            {

            }
           
        }
    }
}
