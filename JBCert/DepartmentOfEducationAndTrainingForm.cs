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
    public partial class DepartmentOfEducationAndTrainingForm : Form
    {
        IDepartmentOfEducationAndTrainingService departmentOfEducationAndTrainingService;

        public DepartmentOfEducationAndTrainingForm()
        {
            InitializeComponent();
            departmentOfEducationAndTrainingService = new DepartmentOfEducationAndTrainingService();
            EditDoEaTForm.OnInforUpdated += EditDoEaTForm_OnInforUpdated;
        }

        private void EditDoEaTForm_OnInforUpdated()
        {
            DepartmentOfEducationAndTrainingModel departmentOfEducationAndTrainingModel
                                                   = departmentOfEducationAndTrainingService.GetInfor();
            DoEaLNameLabel.Text = departmentOfEducationAndTrainingModel.Name;
            DoEaLNameLabel.BackColor = Color.Transparent;
            DoEaLNameLabel.Parent = pictureBox1;
        }

        private void DepartmentOfEducationAndTrainingForm_Load(object sender, EventArgs e)
        {
            DepartmentOfEducationAndTrainingModel departmentOfEducationAndTrainingModel
                                                    = departmentOfEducationAndTrainingService.GetInfor();
            DoEaLNameLabel.Text = departmentOfEducationAndTrainingModel.Name;
            DoEaLNameLabel.BackColor = Color.Transparent;
            DoEaLNameLabel.Parent = pictureBox1;

            SystemNameLabel.BackColor = Color.Transparent;
            SystemNameLabel.Parent = pictureBox1;

            LevelLabel.BackColor = Color.Transparent;
            LevelLabel.Parent = pictureBox1;

            TeamLabel.BackColor = Color.Transparent;
            TeamLabel.Parent = pictureBox1;

            VersionLabel.BackColor = Color.Transparent;
            VersionLabel.Parent = pictureBox1;
            VersionLabel.Text = "Phiên bản " + Common.Common.VERSION + ": Bản Demo";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
