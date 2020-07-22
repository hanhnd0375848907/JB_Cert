using Common;
using JBCert.Authorization;
using Model;
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
    public partial class HomeForm : Form
    {
        int kindCert = 0;
        AccountModel _accountModel;
        public HomeForm(AccountModel accountModel)
        {
            InitializeComponent();
            SelectRootOrCopyCertForm.OnCopyCertSelected += SelectRootOrCopyCert_OnCopyCertSelected;
            SelectRootOrCopyCertForm.OnRootCertSelected += SelectRootOrCopyCert_OnRootCertSelected;
            _accountModel = accountModel;
        }

        private void SelectRootOrCopyCert_OnRootCertSelected()
        {
            kindCert = 1;
        }

        private void SelectRootOrCopyCert_OnCopyCertSelected()
        {
            kindCert = 2;
        }

        private Form activeForm = null;
        private List<Form> activeForms = new List<Form>();
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                if (activeForm.Text != childForm.Text)
                {
                    activeForm.Close();
                    activeForm = childForm;
                    childForm.TopLevel = false;
                    childForm.FormBorderStyle = FormBorderStyle.None;
                    //childForm.Dock = DockStyle.Fill;
                    childForm.AutoScroll = true;
                    childForm.BackColor = Color.FromArgb(230, 235, 252);
                    childForm.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);
                    ChildFormPanel.Controls.Add(childForm);
                    ChildFormPanel.Tag = childForm;
                    childForm.BringToFront();
                    childForm.Show();
                }
            }
            else
            {
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                //childForm.Dock = DockStyle.Fill;
                childForm.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);
                childForm.AutoScroll = true;
                childForm.BackColor = Color.FromArgb(230, 235, 252);
                ChildFormPanel.Controls.Add(childForm);
                ChildFormPanel.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }

            activeForm = childForm;


        }

        private void BlankCertListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.BlankCertList }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new ManagingBlankCertForm());
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.FromArgb(204, 213, 240);
            this.Text = "Phần mềm Quản lý văn bằng chứng chỉ theo quy chế của BGD – JB-Cert phiên bản " + Common.Common.VERSION;
            OpenChildForm(new DepartmentOfEducationAndTrainingForm());
        }


        private void thêmPhôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.AddBlankCert }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddBlankCertForm addBlankCertForm = new AddBlankCertForm();
            addBlankCertForm.ShowDialog();
        }

        private void loạiPhôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.BlankCertTypeList }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new ManagingBlankCertTypeForm());
        }

        private void danhSáchHọcSinhSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.StudentList }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new ManagingStudentForm());
        }

        private void thêmSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.AddStudent }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.ShowDialog();
        }

        private void danhSáchTrườngHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!Auth.HavePermissions(new string[] { Permission.SchoolList }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new ManagingSchoolForm());
        }

        private void quảnLýThôngTinVănBằngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.CertList }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new ManagingCertForm());
        }

        private void tạoMớiThôngTinVănBằngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.AddCert }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelectBlankCertTypeForm selectBlankCertForm = new SelectBlankCertTypeForm();
            selectBlankCertForm.ShowDialog();
        }

        private void thôngTinSởGiáoDụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.EducationAndTraning }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EditDoEaTForm editDoEaTForm = new EditDoEaTForm();
            editDoEaTForm.ShowDialog();
        }

        private void kếtNốiMáyInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.PrintCert }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new ManagingPrinterForm());
        }

        private void quảnLýThôngSốVănBằngToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void inVănBằngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.PrintCert }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelectRootOrCopyCertForm selectRootOrCopyCert = new SelectRootOrCopyCertForm();
            selectRootOrCopyCert.ShowDialog();
            switch (kindCert)
            {
                case (int)Common.KindOfCert.Root:
                    OpenChildForm(new PrintRootCertForm());
                    break;
                case (int)Common.KindOfCert.Copy:
                    OpenChildForm(new PrintCopyCertForm());
                    break;
            }
        }

        private void danhSáchCácKỳThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void thêmKỳThiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inVănBằngGốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.PrintCert }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            OpenChildForm(new PrintRootCertForm());
         
        }

        private void quảnLýThôngSốVănBằngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void danhSáchCácKỳThiToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void thêmKỳThiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        
        private void danhSáchKỳThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.ExamList }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new ManagingExamForm());

        }

        private void thêmKỳThiToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.AddExam }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddExamForm addExamForm = new AddExamForm();
            addExamForm.ShowDialog();
        }

        private void thôngSốInVănBằngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngSốInTrênPhôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.BlankCertConfig }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new ManagingBlankCertConfig());
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.ManagingAccount }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new ManagingUserForm());
        }

        private void quảnLýQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Auth.HavePermissions(new string[] { Permission.ManagingAccount }))
            {
                MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenChildForm(new ManagingRoleForm());
        }

        private void quảnLýKỳThiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cấuHìnhCSDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!Auth.HavePermissions(new string[] { Permission.ManagingAccount }))
            //{
            //    MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            MessageBox.Show("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tàiKhoảnCủaBạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void inBảnSaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!Auth.HavePermissions(new string[] { Permission.PrintCert }))
            //{
            //    MessageBox.Show("Tài khoản không có quền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //OpenChildForm(new PrintCopyCertForm());
            MessageBox.Show("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntroductionForm introductionForm = new IntroductionForm();
            introductionForm.ShowDialog();
        }

        private void tàiKhoảnCủaBạnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //OpenChildForm(new ManagingYourAccountForm());
            ManagingYourAccountForm managingYourAccountForm = new ManagingYourAccountForm();
            managingYourAccountForm.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnlineHelpingForm onlineHelpingForm = new OnlineHelpingForm();
            onlineHelpingForm.ShowDialog();
        }

        private void báoCáoThôngThườngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenChildForm(new MonthlyReportForm());
        }

        private void báoCáoTheoNămToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void sốLầnCấpBảnSaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cấpPhátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void quảnLýThuHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là sản phẩm demo, chức năng này có trên sản phẩm chính thức", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tàiLiệuHướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new CertHelpDocForm());
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            object fileName = Path.Combine(path, "Doc/PreTestHelp.doc");
            Microsoft.Office.Interop.Word._Application ap = new Microsoft.Office.Interop.Word.Application();
            ap.Visible = true;
            Microsoft.Office.Interop.Word._Document document = ap.Documents.Open(fileName);
        }
    }
}
