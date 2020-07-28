namespace JBCert
{
    partial class ManagingCopyCertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagingCopyCertForm));
            this.CopiedCertDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CertName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPrinted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsGranted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SchoolComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.DetailButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.DeSelectAllButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.CopiedCertDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CopiedCertDataGridView
            // 
            this.CopiedCertDataGridView.AllowUserToAddRows = false;
            this.CopiedCertDataGridView.AllowUserToDeleteRows = false;
            this.CopiedCertDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CopiedCertDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CopiedCertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CopiedCertDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.RowCheckBox,
            this.STT,
            this.StudentName,
            this.RankingName,
            this.CertName,
            this.SchoolName,
            this.IsPrinted,
            this.IsGranted});
            this.CopiedCertDataGridView.EnableHeadersVisualStyles = false;
            this.CopiedCertDataGridView.Location = new System.Drawing.Point(12, 78);
            this.CopiedCertDataGridView.Name = "CopiedCertDataGridView";
            this.CopiedCertDataGridView.RowHeadersVisible = false;
            this.CopiedCertDataGridView.Size = new System.Drawing.Size(991, 471);
            this.CopiedCertDataGridView.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // RowCheckBox
            // 
            this.RowCheckBox.HeaderText = "Chọn";
            this.RowCheckBox.Name = "RowCheckBox";
            this.RowCheckBox.Width = 60;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 60;
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "Tên học sinh";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Width = 200;
            // 
            // RankingName
            // 
            this.RankingName.HeaderText = "Xếp loại";
            this.RankingName.Name = "RankingName";
            this.RankingName.ReadOnly = true;
            this.RankingName.Width = 150;
            // 
            // CertName
            // 
            this.CertName.HeaderText = "Tên văn bằng";
            this.CertName.Name = "CertName";
            this.CertName.ReadOnly = true;
            this.CertName.Width = 200;
            // 
            // SchoolName
            // 
            this.SchoolName.HeaderText = "Tên trường";
            this.SchoolName.Name = "SchoolName";
            this.SchoolName.ReadOnly = true;
            this.SchoolName.Width = 200;
            // 
            // IsPrinted
            // 
            this.IsPrinted.HeaderText = "Đã in chưa";
            this.IsPrinted.Name = "IsPrinted";
            this.IsPrinted.ReadOnly = true;
            // 
            // IsGranted
            // 
            this.IsGranted.HeaderText = "Đã cấp chưa";
            this.IsGranted.Name = "IsGranted";
            this.IsGranted.ReadOnly = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(511, 31);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(115, 25);
            this.SearchButton.TabIndex = 15;
            this.SearchButton.Text = "Tìm kiếm";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // SchoolComboBox
            // 
            this.SchoolComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolComboBox.FormattingEnabled = true;
            this.SchoolComboBox.Location = new System.Drawing.Point(227, 31);
            this.SchoolComboBox.Name = "SchoolComboBox";
            this.SchoolComboBox.Size = new System.Drawing.Size(221, 25);
            this.SchoolComboBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(224, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tên trường";
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullNameTextBox.Location = new System.Drawing.Point(12, 31);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(172, 25);
            this.FullNameTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tên học sinh";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(15, 76);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(115, 25);
            this.DeleteButton.TabIndex = 16;
            this.DeleteButton.Text = "Xóa";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DetailButton
            // 
            this.DetailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailButton.Location = new System.Drawing.Point(15, 45);
            this.DetailButton.Name = "DetailButton";
            this.DetailButton.Size = new System.Drawing.Size(115, 25);
            this.DetailButton.TabIndex = 17;
            this.DetailButton.Text = "Chi tiết";
            this.DetailButton.UseVisualStyleBackColor = true;
            this.DetailButton.Click += new System.EventHandler(this.DetailButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectAllButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllButton.Location = new System.Drawing.Point(15, 15);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(115, 25);
            this.SelectAllButton.TabIndex = 18;
            this.SelectAllButton.Text = "Chọn tất cả";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // DeSelectAllButton
            // 
            this.DeSelectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeSelectAllButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeSelectAllButton.Location = new System.Drawing.Point(15, 46);
            this.DeSelectAllButton.Name = "DeSelectAllButton";
            this.DeSelectAllButton.Size = new System.Drawing.Size(115, 25);
            this.DeSelectAllButton.TabIndex = 19;
            this.DeSelectAllButton.Text = "Bỏ chọn tất cả";
            this.DeSelectAllButton.UseVisualStyleBackColor = true;
            this.DeSelectAllButton.Click += new System.EventHandler(this.DeSelectAllButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(15, 14);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(115, 25);
            this.AddButton.TabIndex = 20;
            this.AddButton.Text = "Thêm";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.DetailButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Location = new System.Drawing.Point(1026, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 118);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.DeSelectAllButton);
            this.panel2.Controls.Add(this.SelectAllButton);
            this.panel2.Location = new System.Drawing.Point(1026, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(146, 86);
            this.panel2.TabIndex = 22;
            // 
            // ManagingCopyCertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SchoolComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FullNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CopiedCertDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManagingCopyCertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bản sao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManagingCopyCertForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CopiedCertDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CopiedCertDataGridView;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ComboBox SchoolComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button DetailButton;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button DeSelectAllButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RowCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RankingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CertName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPrinted;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsGranted;
    }
}