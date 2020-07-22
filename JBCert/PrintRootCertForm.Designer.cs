namespace JBCert
{
    partial class PrintRootCertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintRootCertForm));
            this.OpenPrintOptionFormButton = new System.Windows.Forms.Button();
            this.CertDataGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewStudentImage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ViewBlankCertImage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Detail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.SchoolComboBox = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.IsCheckedComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CertDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenPrintOptionFormButton
            // 
            this.OpenPrintOptionFormButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenPrintOptionFormButton.Location = new System.Drawing.Point(12, 13);
            this.OpenPrintOptionFormButton.Name = "OpenPrintOptionFormButton";
            this.OpenPrintOptionFormButton.Size = new System.Drawing.Size(136, 27);
            this.OpenPrintOptionFormButton.TabIndex = 1;
            this.OpenPrintOptionFormButton.Text = "In văn bằng gốc";
            this.OpenPrintOptionFormButton.UseVisualStyleBackColor = true;
            this.OpenPrintOptionFormButton.Click += new System.EventHandler(this.OpenPrintOptionFormButton_Click);
            // 
            // CertDataGridView
            // 
            this.CertDataGridView.AllowUserToAddRows = false;
            this.CertDataGridView.AllowUserToDeleteRows = false;
            this.CertDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CertDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Id,
            this.No,
            this.FullName,
            this.SchoolName,
            this.Serial,
            this.ReferenceNumber,
            this.ViewStudentImage,
            this.ViewBlankCertImage,
            this.Detail});
            this.CertDataGridView.Location = new System.Drawing.Point(12, 64);
            this.CertDataGridView.Name = "CertDataGridView";
            this.CertDataGridView.RowHeadersVisible = false;
            this.CertDataGridView.RowHeadersWidth = 62;
            this.CertDataGridView.Size = new System.Drawing.Size(776, 374);
            this.CertDataGridView.TabIndex = 2;
            this.CertDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CertDataGridView_CellContentClick);
            this.CertDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CertDataGridView_CellValueChanged);
            this.CertDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.CertDataGridView_CurrentCellDirtyStateChanged);
            // 
            // Select
            // 
            this.Select.HeaderText = "";
            this.Select.MinimumWidth = 8;
            this.Select.Name = "Select";
            this.Select.Width = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 75;
            // 
            // No
            // 
            this.No.HeaderText = "STT";
            this.No.Name = "No";
            // 
            // FullName
            // 
            this.FullName.HeaderText = "Họ và tên";
            this.FullName.MinimumWidth = 8;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 150;
            // 
            // SchoolName
            // 
            this.SchoolName.HeaderText = "Trường học";
            this.SchoolName.MinimumWidth = 8;
            this.SchoolName.Name = "SchoolName";
            this.SchoolName.ReadOnly = true;
            this.SchoolName.Width = 200;
            // 
            // Serial
            // 
            this.Serial.HeaderText = "Số hiệu";
            this.Serial.MinimumWidth = 8;
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            this.Serial.Width = 150;
            // 
            // ReferenceNumber
            // 
            this.ReferenceNumber.HeaderText = "Số vào sổ";
            this.ReferenceNumber.MinimumWidth = 8;
            this.ReferenceNumber.Name = "ReferenceNumber";
            this.ReferenceNumber.ReadOnly = true;
            this.ReferenceNumber.Width = 150;
            // 
            // ViewStudentImage
            // 
            this.ViewStudentImage.HeaderText = "Xem ảnh học sinh";
            this.ViewStudentImage.MinimumWidth = 8;
            this.ViewStudentImage.Name = "ViewStudentImage";
            this.ViewStudentImage.ReadOnly = true;
            this.ViewStudentImage.Text = "Xem ảnh học sinh";
            this.ViewStudentImage.UseColumnTextForButtonValue = true;
            this.ViewStudentImage.Width = 150;
            // 
            // ViewBlankCertImage
            // 
            this.ViewBlankCertImage.HeaderText = "Xem ảnh phôi";
            this.ViewBlankCertImage.MinimumWidth = 8;
            this.ViewBlankCertImage.Name = "ViewBlankCertImage";
            this.ViewBlankCertImage.ReadOnly = true;
            this.ViewBlankCertImage.Text = "Xem ảnh phôi";
            this.ViewBlankCertImage.UseColumnTextForButtonValue = true;
            this.ViewBlankCertImage.Width = 150;
            // 
            // Detail
            // 
            this.Detail.HeaderText = "Chi tiết";
            this.Detail.MinimumWidth = 8;
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            this.Detail.Text = "Chi tiết";
            this.Detail.UseColumnTextForButtonValue = true;
            this.Detail.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn trường";
            // 
            // SchoolComboBox
            // 
            this.SchoolComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolComboBox.FormattingEnabled = true;
            this.SchoolComboBox.Location = new System.Drawing.Point(293, 14);
            this.SchoolComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.SchoolComboBox.Name = "SchoolComboBox";
            this.SchoolComboBox.Size = new System.Drawing.Size(163, 25);
            this.SchoolComboBox.TabIndex = 4;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(696, 13);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(92, 27);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Tìm kiếm";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // IsCheckedComboBox
            // 
            this.IsCheckedComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsCheckedComboBox.FormattingEnabled = true;
            this.IsCheckedComboBox.Location = new System.Drawing.Point(551, 14);
            this.IsCheckedComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.IsCheckedComboBox.Name = "IsCheckedComboBox";
            this.IsCheckedComboBox.Size = new System.Drawing.Size(113, 25);
            this.IsCheckedComboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(475, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Trạng thái";
            // 
            // PrintRootCertForm
            // 
            this.AcceptButton = this.OpenPrintOptionFormButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IsCheckedComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SchoolComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CertDataGridView);
            this.Controls.Add(this.OpenPrintOptionFormButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintRootCertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In văn bằng gốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrintRootCertForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CertDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenPrintOptionFormButton;
        private System.Windows.Forms.DataGridView CertDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SchoolComboBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ComboBox IsCheckedComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceNumber;
        private System.Windows.Forms.DataGridViewButtonColumn ViewStudentImage;
        private System.Windows.Forms.DataGridViewButtonColumn ViewBlankCertImage;
        private System.Windows.Forms.DataGridViewButtonColumn Detail;
    }
}