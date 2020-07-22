namespace JBCert
{
    partial class ManagingCertForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CertDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CertName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProvideAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProvideDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrantedAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityReceiver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsGranted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPrinted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewStudentImage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ViewBlankCertImage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.SerialTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ReferenceNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SchoolComboBox = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.DeSelectAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CertDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CertDataGridView
            // 
            this.CertDataGridView.AllowUserToAddRows = false;
            this.CertDataGridView.AllowUserToDeleteRows = false;
            this.CertDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CertDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.CertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CertDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.RowCheckBox,
            this.STT,
            this.StudentName,
            this.RankingName,
            this.CertName,
            this.SchoolName,
            this.Serial,
            this.ReferenceNumber,
            this.ProvideAddress,
            this.Position,
            this.ProvideDate,
            this.GrantedAddress,
            this.ReceiverName,
            this.IdentityReceiver,
            this.IsGranted,
            this.IsPrinted,
            this.ViewStudentImage,
            this.ViewBlankCertImage});
            this.CertDataGridView.Location = new System.Drawing.Point(13, 78);
            this.CertDataGridView.Name = "CertDataGridView";
            this.CertDataGridView.RowHeadersVisible = false;
            this.CertDataGridView.Size = new System.Drawing.Size(721, 471);
            this.CertDataGridView.TabIndex = 0;
            this.CertDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CertDataGridView_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // RowCheckBox
            // 
            this.RowCheckBox.HeaderText = "";
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
            this.SchoolName.Width = 150;
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
            // 
            // ProvideAddress
            // 
            this.ProvideAddress.HeaderText = "Nơi cung cấp";
            this.ProvideAddress.Name = "ProvideAddress";
            this.ProvideAddress.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.HeaderText = "Chức vụ";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // ProvideDate
            // 
            this.ProvideDate.HeaderText = "Ngày cấp";
            this.ProvideDate.Name = "ProvideDate";
            this.ProvideDate.ReadOnly = true;
            // 
            // GrantedAddress
            // 
            this.GrantedAddress.HeaderText = "Địa chỉ cấp";
            this.GrantedAddress.Name = "GrantedAddress";
            this.GrantedAddress.ReadOnly = true;
            this.GrantedAddress.Width = 150;
            // 
            // ReceiverName
            // 
            this.ReceiverName.HeaderText = "Người nhận";
            this.ReceiverName.Name = "ReceiverName";
            this.ReceiverName.ReadOnly = true;
            // 
            // IdentityReceiver
            // 
            this.IdentityReceiver.HeaderText = "CMT người nhận";
            this.IdentityReceiver.Name = "IdentityReceiver";
            this.IdentityReceiver.ReadOnly = true;
            // 
            // IsGranted
            // 
            this.IsGranted.HeaderText = "Trạng thái cấp";
            this.IsGranted.Name = "IsGranted";
            this.IsGranted.ReadOnly = true;
            // 
            // IsPrinted
            // 
            this.IsPrinted.HeaderText = "Trạng thái in";
            this.IsPrinted.Name = "IsPrinted";
            this.IsPrinted.ReadOnly = true;
            // 
            // ViewStudentImage
            // 
            this.ViewStudentImage.HeaderText = "Xem ảnh học sinh";
            this.ViewStudentImage.Name = "ViewStudentImage";
            this.ViewStudentImage.Text = "Xem ảnh học sinh";
            this.ViewStudentImage.UseColumnTextForButtonValue = true;
            this.ViewStudentImage.Width = 200;
            // 
            // ViewBlankCertImage
            // 
            this.ViewBlankCertImage.HeaderText = "Xem ảnh phôi";
            this.ViewBlankCertImage.Name = "ViewBlankCertImage";
            this.ViewBlankCertImage.Text = "Xem ảnh phôi";
            this.ViewBlankCertImage.UseColumnTextForButtonValue = true;
            this.ViewBlankCertImage.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên học sinh";
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullNameTextBox.Location = new System.Drawing.Point(16, 33);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(172, 25);
            this.FullNameTextBox.TabIndex = 2;
            // 
            // SerialTextBox
            // 
            this.SerialTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialTextBox.Location = new System.Drawing.Point(212, 33);
            this.SerialTextBox.Name = "SerialTextBox";
            this.SerialTextBox.Size = new System.Drawing.Size(142, 25);
            this.SerialTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số hiệu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(378, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số vào sổ";
            // 
            // ReferenceNumberTextBox
            // 
            this.ReferenceNumberTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReferenceNumberTextBox.Location = new System.Drawing.Point(381, 34);
            this.ReferenceNumberTextBox.Name = "ReferenceNumberTextBox";
            this.ReferenceNumberTextBox.Size = new System.Drawing.Size(135, 25);
            this.ReferenceNumberTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(537, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên trường";
            // 
            // SchoolComboBox
            // 
            this.SchoolComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolComboBox.FormattingEnabled = true;
            this.SchoolComboBox.Location = new System.Drawing.Point(540, 34);
            this.SchoolComboBox.Name = "SchoolComboBox";
            this.SchoolComboBox.Size = new System.Drawing.Size(155, 25);
            this.SchoolComboBox.TabIndex = 5;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(722, 34);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(110, 25);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "Tìm kiếm";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(752, 185);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(118, 39);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Thêm văn bằng";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddCertButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(752, 234);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(118, 32);
            this.EditButton.TabIndex = 7;
            this.EditButton.Text = "Sửa";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(752, 276);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(118, 32);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Xóa";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectAllButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllButton.Location = new System.Drawing.Point(752, 78);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(118, 39);
            this.SelectAllButton.TabIndex = 7;
            this.SelectAllButton.Text = "Chọn tất cả";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // DeSelectAllButton
            // 
            this.DeSelectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeSelectAllButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeSelectAllButton.Location = new System.Drawing.Point(752, 123);
            this.DeSelectAllButton.Name = "DeSelectAllButton";
            this.DeSelectAllButton.Size = new System.Drawing.Size(118, 39);
            this.DeSelectAllButton.TabIndex = 7;
            this.DeSelectAllButton.Text = "Bỏ chọn tất cả";
            this.DeSelectAllButton.UseVisualStyleBackColor = true;
            this.DeSelectAllButton.Click += new System.EventHandler(this.DeSelectAllButton_Click);
            // 
            // ManagingCertForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.SelectAllButton);
            this.Controls.Add(this.DeSelectAllButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SchoolComboBox);
            this.Controls.Add(this.ReferenceNumberTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SerialTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FullNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CertDataGridView);
            this.Name = "ManagingCertForm";
            this.Text = "ManagingCertForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManagingCertForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CertDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CertDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.TextBox SerialTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ReferenceNumberTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SchoolComboBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RowCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RankingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CertName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProvideAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProvideDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrantedAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityReceiver;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsGranted;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPrinted;
        private System.Windows.Forms.DataGridViewButtonColumn ViewStudentImage;
        private System.Windows.Forms.DataGridViewButtonColumn ViewBlankCertImage;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button DeSelectAllButton;
    }
}