using iTextSharp.text;
using iTextSharp.text.pdf;
using LiveCharts;
using LiveCharts.Wpf;
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

            LoadGrantedBlankCertChart();
            LoadBlankCertStatusPieChart();
            LoadRootCertStatusPieChart();

            MessageBox.Show("Đây là dữ liệu ảo trong bản demo để trải nghiệm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void LoadGrantedBlankCertChart()
        {
            DateTime dateTime = DateTime.Now;
            int totalDayInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            Random random = new Random();
            for (int i = 1; i <= totalDayInMonth; i++)
            {
                int randomNumberOfCert = random.Next(1, 20);
                PrintedCertChart.Series["Ngày"].Points.AddXY("Ngày " + i, randomNumberOfCert);
            }
        }

        private void LoadBlankCertStatusPieChart()
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            // Define the collection of Values to display in the Pie Chart
            BlankCertStatusPieChart.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Phôi đã dùng",
                    Values = new ChartValues<double> {20},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Blue,

                },
                new PieSeries
                {
                    Title = "Phôi chưa dùng",
                    Values = new ChartValues<double> {64},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Green,
                },
                new PieSeries
                {
                    Title = "Phôi lỗi",
                    Values = new ChartValues<double> {4},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Red,

                }
            };

            // Set the legend location to appear in the bottom of the chart
            BlankCertStatusPieChart.LegendLocation = LegendLocation.Bottom;
        }

        private void LoadRootCertStatusPieChart()
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            // Define the collection of Values to display in the Pie Chart
            RootCertStatusPieChart.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Văn bằng gốc chưa cấp",
                    Values = new ChartValues<double> {30},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Blue,

                },
                new PieSeries
                {
                    Title = "Văn bằng gốc đã cấp",
                    Values = new ChartValues<double> {15},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Green,
                },
                new PieSeries
                {
                    Title = "Văn bằng gốc thu hồi",
                    Values = new ChartValues<double> {2},
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Red,

                }
            };

            // Set the legend location to appear in the bottom of the chart
            RootCertStatusPieChart.LegendLocation = LegendLocation.Bottom;
        }
    }
}
