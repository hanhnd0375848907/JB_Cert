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
    public partial class MonthlyReportForm : Form
    {
        public MonthlyReportForm()
        {
            InitializeComponent();
        }

        private void MonthlyReportForm_Load(object sender, EventArgs e)
        {
            // load title
            DateTime dateTime = DateTime.Now;
            TitleMonthlyReportLabel.Text = "Báo cáo Tháng " + dateTime.ToString("MM");

            MessageBox.Show("Đây là dữ liệu ảo trong bản demo để trải nghiệm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            AddChartContent();
        }

        private void AddChartContent()
        {
            DateTime dateTime = DateTime.Now;
            int totalDayInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            Random random = new Random();
            for(int i = 1; i <= totalDayInMonth; i++)
            {
                int randomNumberOfCert = random.Next(1,20);
                PrintedCertChart.Series["Ngày"].Points.AddXY("Ngày " + i, randomNumberOfCert);
            }
        }
    }
}
