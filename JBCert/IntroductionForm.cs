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
    public partial class IntroductionForm : Form
    {
        public IntroductionForm()
        {
            InitializeComponent();
        }

        private void IntroductionForm_Load(object sender, EventArgs e)
        {
            label3.Text = "Phiên bản: " + Common.Common.VERSION;
            label6.Text = "Đơn vị phát triển: Công ty Công nghệ JB";
        }
    }
}
