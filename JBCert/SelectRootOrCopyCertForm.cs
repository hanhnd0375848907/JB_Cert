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
    public partial class SelectRootOrCopyCertForm : Form
    {
        public delegate void SelectKindOfCert();

        public static event SelectKindOfCert OnRootCertSelected;
        public static event SelectKindOfCert OnCopyCertSelected;
        public SelectRootOrCopyCertForm()
        {
            InitializeComponent();
            OnRootCertSelected += SelectRootOrCopyCert_OnRootCertSelected;
            OnCopyCertSelected += SelectRootOrCopyCert_OnCopyCertSelected;
        }

        private void SelectRootOrCopyCert_OnCopyCertSelected()
        {
        }

        private void SelectRootOrCopyCert_OnRootCertSelected()
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectRootOrCopyCert_Load(object sender, EventArgs e)
        {

        }

        private void PrintRootCertButton_Click(object sender, EventArgs e)
        {
            OnRootCertSelected();
            this.Close();
        }

        private void PrintCopyCertButton_Click(object sender, EventArgs e)
        {
            OnCopyCertSelected();
            this.Close();
        }
    }
}
