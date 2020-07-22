using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class AddBlankCertConfigForm : Form
    {
        IManagingBlankCertTypeService managingBlankCertTypeService;
        IManagingBlankCertConfigService managingBlankCertConfigService;
        public AddBlankCertConfigForm()
        {
            InitializeComponent();
            managingBlankCertTypeService = new ManagingBlankCertTypeService();
            managingBlankCertConfigService = new ManagingBlankCertConfigService();
        }

        private void AddBlankCertConfigForm_Load(object sender, EventArgs e)
        {
            try
            {

                // load blank cert type 
                BlankCertTypeComboBox.DataSource = managingBlankCertTypeService.GetAllBlankCertType();
                BlankCertTypeComboBox.DisplayMember = "Name";
                BlankCertTypeComboBox.ValueMember = "Id";
                BlankCertTypeComboBox.SelectedIndex = 0;
               
                // load panel
                LoadConfigPanel();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NotificationForm notificationForm = new NotificationForm("Có lỗi, vui lòng liên hệ bên phát triển phần mềm", "Lỗi" ,MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }



        //private void TextBox_Enter(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Vui lòng điền số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //    //TextBox tb = (TextBox)sender;
        //    //string text = tb.Text;
        //    //try
        //    //{
        //    //    int a = int.Parse(text);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    tb.Text = "0";
        //    //    MessageBox.Show("Vui lòng điền số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //}
        //}

        private void BlankCertTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadConfigPanel();
            }
            catch
            {

            }
        }

        private void LoadConfigPanel()
        {
            int selectedBlankCertTypeModelId = (int)BlankCertTypeComboBox.SelectedValue;
            if (selectedBlankCertTypeModelId == (int)Common.BlankCertType.HightSchool)
            {
                ExamPanel.Visible = true;
                GraduatingYearPanel.Visible = true;
                SchoolPanel.Visible = true;
                FullNamePanel.Visible = true;
                DobPanel.Visible = true;
                BornedAddressPanel.Visible = true;
                GenderPanel.Visible = true;
                EthnicPanel.Visible = true;
                ScorePanel.Visible = true;
                SerialPanel.Visible = true;
                ReferenceNumberPanel.Visible = true;
                CreatedDatePanel.Visible = true;
                MajorPanel.Visible = false;
                TrainingModePanel.Visible = false;
                RankingPanel.Visible = false;
            }
            else if (selectedBlankCertTypeModelId == (int)Common.BlankCertType.JuniorHighSchool)
            {
                ExamPanel.Visible = true;
                GraduatingYearPanel.Visible = true;
                SchoolPanel.Visible = true;
                FullNamePanel.Visible = true;
                DobPanel.Visible = true;
                BornedAddressPanel.Visible = true;
                GenderPanel.Visible = true;
                EthnicPanel.Visible = true;
                ScorePanel.Visible = false;
                SerialPanel.Visible = true;
                ReferenceNumberPanel.Visible = true;
                CreatedDatePanel.Visible = true;
                MajorPanel.Visible = false;
                TrainingModePanel.Visible = false;
                RankingPanel.Visible = true;
            }
            else if (selectedBlankCertTypeModelId == (int)Common.BlankCertType.University)
            {
                ExamPanel.Visible = true;
                GraduatingYearPanel.Visible = true;
                SchoolPanel.Visible = true;
                FullNamePanel.Visible = true;
                DobPanel.Visible = true;
                BornedAddressPanel.Visible = true;
                GenderPanel.Visible = true;
                EthnicPanel.Visible = true;
                ScorePanel.Visible = false;
                SerialPanel.Visible = true;
                ReferenceNumberPanel.Visible = true;
                CreatedDatePanel.Visible = true;
                MajorPanel.Visible = true;
                TrainingModePanel.Visible = true;
                RankingPanel.Visible = true;
            }
            else if (selectedBlankCertTypeModelId == (int)Common.BlankCertType.Master)
            {
                ExamPanel.Visible = true;
                GraduatingYearPanel.Visible = true;
                SchoolPanel.Visible = true;
                FullNamePanel.Visible = true;
                DobPanel.Visible = true;
                BornedAddressPanel.Visible = true;
                GenderPanel.Visible = true;
                EthnicPanel.Visible = true;
                ScorePanel.Visible = false;
                SerialPanel.Visible = true;
                ReferenceNumberPanel.Visible = true;
                CreatedDatePanel.Visible = true;
                MajorPanel.Visible = true;
                TrainingModePanel.Visible = true;
                RankingPanel.Visible = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NotificationForm notificationForm = new NotificationForm("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxIcon.Error);
            notificationForm.ShowDialog();
            //try
            //{
            //    BlankCertConfigModel blankCertConfigModel = new BlankCertConfigModel();
            //    //managingBlankCertConfigService.AddBlankCertConfig(blankCertConfigModel);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            //MessageBox.Show("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NotificationForm notificationForm = new NotificationForm("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxIcon.Error);
            notificationForm.ShowDialog();
        }
    }
}
