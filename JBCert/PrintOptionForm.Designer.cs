namespace JBCert
{
    partial class PrintOptionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintOptionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.PrinterComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberOfDocumentLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BlankCertTypeComboBox = new System.Windows.Forms.ComboBox();
            this.PrintButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CertDataGridView = new System.Windows.Forms.DataGridView();
            this.IsPrinted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CertDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn máy in";
            // 
            // PrinterComboBox
            // 
            this.PrinterComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrinterComboBox.FormattingEnabled = true;
            this.PrinterComboBox.Location = new System.Drawing.Point(108, 12);
            this.PrinterComboBox.Name = "PrinterComboBox";
            this.PrinterComboBox.Size = new System.Drawing.Size(179, 25);
            this.PrinterComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(650, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tổng số bản in";
            // 
            // NumberOfDocumentLabel
            // 
            this.NumberOfDocumentLabel.AutoSize = true;
            this.NumberOfDocumentLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfDocumentLabel.Location = new System.Drawing.Point(760, 16);
            this.NumberOfDocumentLabel.Name = "NumberOfDocumentLabel";
            this.NumberOfDocumentLabel.Size = new System.Drawing.Size(69, 17);
            this.NumberOfDocumentLabel.TabIndex = 3;
            this.NumberOfDocumentLabel.Text = "Số bản in";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chọn thông số in";
            // 
            // BlankCertTypeComboBox
            // 
            this.BlankCertTypeComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlankCertTypeComboBox.FormattingEnabled = true;
            this.BlankCertTypeComboBox.Location = new System.Drawing.Point(432, 12);
            this.BlankCertTypeComboBox.Name = "BlankCertTypeComboBox";
            this.BlankCertTypeComboBox.Size = new System.Drawing.Size(179, 25);
            this.BlankCertTypeComboBox.TabIndex = 5;
            this.BlankCertTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BlankCertTypeComboBox_SelectedIndexChanged);
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintButton.Location = new System.Drawing.Point(757, 524);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(115, 25);
            this.PrintButton.TabIndex = 6;
            this.PrintButton.Text = "In bằng";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(622, 524);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(115, 25);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Hủy";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CertDataGridView
            // 
            this.CertDataGridView.AllowUserToAddRows = false;
            this.CertDataGridView.AllowUserToDeleteRows = false;
            this.CertDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CertDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CertDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsPrinted,
            this.Id,
            this.No,
            this.FullName,
            this.SchoolName,
            this.Serial,
            this.ReferenceNumber});
            this.CertDataGridView.EnableHeadersVisualStyles = false;
            this.CertDataGridView.Location = new System.Drawing.Point(12, 49);
            this.CertDataGridView.Name = "CertDataGridView";
            this.CertDataGridView.ReadOnly = true;
            this.CertDataGridView.RowHeadersVisible = false;
            this.CertDataGridView.Size = new System.Drawing.Size(860, 460);
            this.CertDataGridView.TabIndex = 8;
            this.CertDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CertDataGridView_CellContentClick);
            // 
            // IsPrinted
            // 
            this.IsPrinted.HeaderText = "Trạng thái";
            this.IsPrinted.Name = "IsPrinted";
            this.IsPrinted.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 75;
            // 
            // No
            // 
            this.No.HeaderText = "STT";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "Họ và tên";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            // 
            // SchoolName
            // 
            this.SchoolName.HeaderText = "Trường học";
            this.SchoolName.Name = "SchoolName";
            this.SchoolName.ReadOnly = true;
            this.SchoolName.Width = 200;
            // 
            // Serial
            // 
            this.Serial.HeaderText = "Số hiệu";
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            // 
            // ReferenceNumber
            // 
            this.ReferenceNumber.HeaderText = "Số vào sổ";
            this.ReferenceNumber.Name = "ReferenceNumber";
            this.ReferenceNumber.ReadOnly = true;
            this.ReferenceNumber.Width = 150;
            // 
            // PrintOptionForm
            // 
            this.AcceptButton = this.PrintButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.CertDataGridView);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.BlankCertTypeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumberOfDocumentLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PrinterComboBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintOptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In";
            this.Load += new System.EventHandler(this.PrintOptionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CertDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PrinterComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NumberOfDocumentLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox BlankCertTypeComboBox;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridView CertDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsPrinted;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceNumber;
    }
}