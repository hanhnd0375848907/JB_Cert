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
    public partial class SelectBlankCertTypeForm : Form
    {
        IManagingBlankCertTypeService managingBlankCertTypeService;
        public SelectBlankCertTypeForm()
        {
            InitializeComponent();
            managingBlankCertTypeService = new ManagingBlankCertTypeService();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            AddCertForm addCertForm = new AddCertForm(int.Parse(BlankCertTypeComboBox.SelectedValue.ToString()));
            addCertForm.ShowDialog();
            this.Close();
        }

        private void SelectBlankCertTypeForm_Load(object sender, EventArgs e)
        {
            BlankCertTypeComboBox.DataSource = managingBlankCertTypeService.GetAllBlankCertType();
            BlankCertTypeComboBox.DisplayMember = "Name";
            BlankCertTypeComboBox.ValueMember = "Id";
        }
    }
}
