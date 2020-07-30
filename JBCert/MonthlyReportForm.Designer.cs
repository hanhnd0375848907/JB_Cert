namespace JBCert
{
    partial class MonthlyReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyReportForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PrintedCertChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.TitleMonthlyReportLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.BlankCertStatusPieChart = new LiveCharts.WinForms.PieChart();
            this.RootCertStatusPieChart = new LiveCharts.WinForms.PieChart();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NumberOfPrintedCert = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintedCertChart)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.PrintedCertChart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 565);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 295);
            this.panel1.TabIndex = 0;
            // 
            // PrintedCertChart
            // 
            this.PrintedCertChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.PrintedCertChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.PrintedCertChart.Legends.Add(legend1);
            this.PrintedCertChart.Location = new System.Drawing.Point(3, 30);
            this.PrintedCertChart.Name = "PrintedCertChart";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Ngày";
            this.PrintedCertChart.Series.Add(series1);
            this.PrintedCertChart.Size = new System.Drawing.Size(853, 262);
            this.PrintedCertChart.TabIndex = 3;
            this.PrintedCertChart.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số lượng văn bằng được cấp theo từng ngày trong tháng";
            // 
            // TitleMonthlyReportLabel
            // 
            this.TitleMonthlyReportLabel.AutoSize = true;
            this.TitleMonthlyReportLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleMonthlyReportLabel.ForeColor = System.Drawing.Color.Coral;
            this.TitleMonthlyReportLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleMonthlyReportLabel.Name = "TitleMonthlyReportLabel";
            this.TitleMonthlyReportLabel.Size = new System.Drawing.Size(153, 24);
            this.TitleMonthlyReportLabel.TabIndex = 2;
            this.TitleMonthlyReportLabel.Text = "Tháng hiện tại";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.BlankCertStatusPieChart);
            this.panel7.Location = new System.Drawing.Point(14, 248);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(316, 297);
            this.panel7.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(61, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(196, 19);
            this.label16.TabIndex = 4;
            this.label16.Text = "Thông tin trạng thái phôi";
            // 
            // BlankCertStatusPieChart
            // 
            this.BlankCertStatusPieChart.Location = new System.Drawing.Point(5, 44);
            this.BlankCertStatusPieChart.Name = "BlankCertStatusPieChart";
            this.BlankCertStatusPieChart.Size = new System.Drawing.Size(308, 250);
            this.BlankCertStatusPieChart.TabIndex = 0;
            this.BlankCertStatusPieChart.Text = "pieChart1";
            // 
            // RootCertStatusPieChart
            // 
            this.RootCertStatusPieChart.Location = new System.Drawing.Point(3, 44);
            this.RootCertStatusPieChart.Name = "RootCertStatusPieChart";
            this.RootCertStatusPieChart.Size = new System.Drawing.Size(308, 250);
            this.RootCertStatusPieChart.TabIndex = 5;
            this.RootCertStatusPieChart.Text = "pieChart1";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.RootCertStatusPieChart);
            this.panel8.Controls.Add(this.label20);
            this.panel8.Location = new System.Drawing.Point(377, 248);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(316, 297);
            this.panel8.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(66, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(193, 19);
            this.label20.TabIndex = 4;
            this.label20.Text = "Trạng thái văn bằng gốc";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(856, 198);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.MaximumSize = new System.Drawing.Size(221, 93);
            this.panel5.MinimumSize = new System.Drawing.Size(221, 93);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(221, 93);
            this.panel5.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(47, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 44);
            this.label10.TabIndex = 5;
            this.label10.Text = "20";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(105, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 19);
            this.label11.TabIndex = 4;
            this.label11.Text = "Phôi";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 19);
            this.label12.TabIndex = 4;
            this.label12.Text = "Số lượng phôi thu hồi";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(230, 3);
            this.panel4.MaximumSize = new System.Drawing.Size(221, 93);
            this.panel4.MinimumSize = new System.Drawing.Size(221, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(221, 93);
            this.panel4.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(40, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 44);
            this.label7.TabIndex = 5;
            this.label7.Text = "100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(118, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 19);
            this.label8.TabIndex = 4;
            this.label8.Text = "Phôi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(27, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "Số lượng phôi đã lấy";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Location = new System.Drawing.Point(457, 3);
            this.panel6.MaximumSize = new System.Drawing.Size(221, 93);
            this.panel6.MinimumSize = new System.Drawing.Size(221, 93);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(221, 93);
            this.panel6.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(47, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 44);
            this.label13.TabIndex = 5;
            this.label13.Text = "20";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(105, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 19);
            this.label14.TabIndex = 4;
            this.label14.Text = "Bản sao";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(20, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(187, 19);
            this.label15.TabIndex = 4;
            this.label15.Text = "Số lượng bản sao đã in";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(3, 102);
            this.panel3.MaximumSize = new System.Drawing.Size(221, 93);
            this.panel3.MinimumSize = new System.Drawing.Size(221, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(221, 93);
            this.panel3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(47, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 44);
            this.label4.TabIndex = 5;
            this.label4.Text = "30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Văn bằng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số lượng văn bằng đã cấp";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.NumberOfPrintedCert);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(230, 102);
            this.panel2.MaximumSize = new System.Drawing.Size(221, 93);
            this.panel2.MinimumSize = new System.Drawing.Size(221, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 93);
            this.panel2.TabIndex = 6;
            // 
            // NumberOfPrintedCert
            // 
            this.NumberOfPrintedCert.AutoSize = true;
            this.NumberOfPrintedCert.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfPrintedCert.ForeColor = System.Drawing.SystemColors.Highlight;
            this.NumberOfPrintedCert.Location = new System.Drawing.Point(39, 40);
            this.NumberOfPrintedCert.Name = "NumberOfPrintedCert";
            this.NumberOfPrintedCert.Size = new System.Drawing.Size(62, 44);
            this.NumberOfPrintedCert.TabIndex = 5;
            this.NumberOfPrintedCert.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(97, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Văn bằng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số lượng văn bằng đã in";
            // 
            // MonthlyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(884, 867);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.TitleMonthlyReportLabel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 906);
            this.Name = "MonthlyReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo theo tháng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MonthlyReportForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintedCertChart)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart PrintedCertChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TitleMonthlyReportLabel;
        private System.Windows.Forms.Panel panel7;
        private LiveCharts.WinForms.PieChart BlankCertStatusPieChart;
        private System.Windows.Forms.Label label16;
        private LiveCharts.WinForms.PieChart RootCertStatusPieChart;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label NumberOfPrintedCert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}