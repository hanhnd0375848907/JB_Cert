namespace JBCert
{
    partial class SelectBlankCertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectBlankCertForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BlankCertDataGridView = new System.Windows.Forms.DataGridView();
            this.ResetBlankCertButton = new System.Windows.Forms.Button();
            this.SearchBlankCertButton = new System.Windows.Forms.Button();
            this.SerialTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ChosenBlankCertDataGridView = new System.Windows.Forms.DataGridView();
            this.ChosenResetBlankCertButton = new System.Windows.Forms.Button();
            this.ChosenSearchBlankCertButton = new System.Windows.Forms.Button();
            this.ChosenSerialTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CertNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowImage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ChosenId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChosenNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChosenSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChosenReferenceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChosenShowImage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlankCertDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChosenBlankCertDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.BlankCertDataGridView);
            this.panel1.Controls.Add(this.ResetBlankCertButton);
            this.panel1.Controls.Add(this.SearchBlankCertButton);
            this.panel1.Controls.Add(this.SerialTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 446);
            this.panel1.TabIndex = 0;
            // 
            // BlankCertDataGridView
            // 
            this.BlankCertDataGridView.AllowUserToAddRows = false;
            this.BlankCertDataGridView.AllowUserToDeleteRows = false;
            this.BlankCertDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlankCertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BlankCertDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.No,
            this.Serial,
            this.ShowImage,
            this.Select});
            this.BlankCertDataGridView.Location = new System.Drawing.Point(18, 50);
            this.BlankCertDataGridView.Name = "BlankCertDataGridView";
            this.BlankCertDataGridView.ReadOnly = true;
            this.BlankCertDataGridView.RowHeadersVisible = false;
            this.BlankCertDataGridView.Size = new System.Drawing.Size(426, 380);
            this.BlankCertDataGridView.TabIndex = 4;
            this.BlankCertDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BlankCertDataGridView_CellContentClick);
            // 
            // ResetBlankCertButton
            // 
            this.ResetBlankCertButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetBlankCertButton.Location = new System.Drawing.Point(369, 14);
            this.ResetBlankCertButton.Margin = new System.Windows.Forms.Padding(2);
            this.ResetBlankCertButton.Name = "ResetBlankCertButton";
            this.ResetBlankCertButton.Size = new System.Drawing.Size(75, 27);
            this.ResetBlankCertButton.TabIndex = 3;
            this.ResetBlankCertButton.Text = "Làm mới";
            this.ResetBlankCertButton.UseVisualStyleBackColor = true;
            this.ResetBlankCertButton.Click += new System.EventHandler(this.ResetBlankCertButton_Click);
            // 
            // SearchBlankCertButton
            // 
            this.SearchBlankCertButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBlankCertButton.Location = new System.Drawing.Point(266, 14);
            this.SearchBlankCertButton.Margin = new System.Windows.Forms.Padding(2);
            this.SearchBlankCertButton.Name = "SearchBlankCertButton";
            this.SearchBlankCertButton.Size = new System.Drawing.Size(99, 27);
            this.SearchBlankCertButton.TabIndex = 2;
            this.SearchBlankCertButton.Text = "Tìm kiếm";
            this.SearchBlankCertButton.UseVisualStyleBackColor = true;
            this.SearchBlankCertButton.Click += new System.EventHandler(this.SearchBlankCertButton_Click);
            // 
            // SerialTextBox
            // 
            this.SerialTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialTextBox.Location = new System.Drawing.Point(66, 15);
            this.SerialTextBox.Name = "SerialTextBox";
            this.SerialTextBox.Size = new System.Drawing.Size(192, 25);
            this.SerialTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.ChosenBlankCertDataGridView);
            this.panel2.Controls.Add(this.ChosenResetBlankCertButton);
            this.panel2.Controls.Add(this.ChosenSearchBlankCertButton);
            this.panel2.Controls.Add(this.ChosenSerialTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(480, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(593, 446);
            this.panel2.TabIndex = 5;
            // 
            // ChosenBlankCertDataGridView
            // 
            this.ChosenBlankCertDataGridView.AllowUserToAddRows = false;
            this.ChosenBlankCertDataGridView.AllowUserToDeleteRows = false;
            this.ChosenBlankCertDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChosenBlankCertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChosenBlankCertDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChosenId,
            this.ChosenNo,
            this.ChosenSerial,
            this.ChosenReferenceNumber,
            this.ChosenShowImage,
            this.Remove});
            this.ChosenBlankCertDataGridView.Location = new System.Drawing.Point(18, 50);
            this.ChosenBlankCertDataGridView.Name = "ChosenBlankCertDataGridView";
            this.ChosenBlankCertDataGridView.RowHeadersVisible = false;
            this.ChosenBlankCertDataGridView.Size = new System.Drawing.Size(559, 383);
            this.ChosenBlankCertDataGridView.TabIndex = 4;
            this.ChosenBlankCertDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChosenBlankCertDataGridView_CellContentClick);
            this.ChosenBlankCertDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChosenBlankCertDataGridView_CellValueChanged);
            this.ChosenBlankCertDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.ChosenBlankCertDataGridView_CurrentCellDirtyStateChanged);
            // 
            // ChosenResetBlankCertButton
            // 
            this.ChosenResetBlankCertButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChosenResetBlankCertButton.Location = new System.Drawing.Point(394, 14);
            this.ChosenResetBlankCertButton.Margin = new System.Windows.Forms.Padding(2);
            this.ChosenResetBlankCertButton.Name = "ChosenResetBlankCertButton";
            this.ChosenResetBlankCertButton.Size = new System.Drawing.Size(75, 27);
            this.ChosenResetBlankCertButton.TabIndex = 3;
            this.ChosenResetBlankCertButton.Text = "Làm mới";
            this.ChosenResetBlankCertButton.UseVisualStyleBackColor = true;
            this.ChosenResetBlankCertButton.Click += new System.EventHandler(this.ChosenResetBlankCertButton_Click);
            // 
            // ChosenSearchBlankCertButton
            // 
            this.ChosenSearchBlankCertButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChosenSearchBlankCertButton.Location = new System.Drawing.Point(291, 14);
            this.ChosenSearchBlankCertButton.Margin = new System.Windows.Forms.Padding(2);
            this.ChosenSearchBlankCertButton.Name = "ChosenSearchBlankCertButton";
            this.ChosenSearchBlankCertButton.Size = new System.Drawing.Size(99, 27);
            this.ChosenSearchBlankCertButton.TabIndex = 2;
            this.ChosenSearchBlankCertButton.Text = "Tìm kiếm";
            this.ChosenSearchBlankCertButton.UseVisualStyleBackColor = true;
            this.ChosenSearchBlankCertButton.Click += new System.EventHandler(this.ChosenSearchBlankCertButton_Click);
            // 
            // ChosenSerialTextBox
            // 
            this.ChosenSerialTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChosenSerialTextBox.Location = new System.Drawing.Point(70, 15);
            this.ChosenSerialTextBox.Name = "ChosenSerialTextBox";
            this.ChosenSerialTextBox.Size = new System.Drawing.Size(192, 25);
            this.ChosenSerialTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Serial";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.CertNameTextBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 46);
            this.panel3.TabIndex = 6;
            // 
            // CertNameTextBox
            // 
            this.CertNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CertNameTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CertNameTextBox.Location = new System.Drawing.Point(88, 13);
            this.CertNameTextBox.Name = "CertNameTextBox";
            this.CertNameTextBox.Size = new System.Drawing.Size(465, 25);
            this.CertNameTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tên bằng";
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(998, 543);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 27);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Tạo";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(901, 543);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 27);
            this.BackButton.TabIndex = 8;
            this.BackButton.Text = "Trở về";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(806, 543);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 27);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Hủy";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
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
            // Serial
            // 
            this.Serial.HeaderText = "Số hiệu";
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            // 
            // ShowImage
            // 
            this.ShowImage.HeaderText = "Xem ảnh";
            this.ShowImage.Name = "ShowImage";
            this.ShowImage.ReadOnly = true;
            this.ShowImage.Text = "Xem ảnh";
            this.ShowImage.UseColumnTextForButtonValue = true;
            // 
            // Select
            // 
            this.Select.HeaderText = "Chọn";
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Text = "Chọn";
            this.Select.UseColumnTextForButtonValue = true;
            // 
            // ChosenId
            // 
            this.ChosenId.HeaderText = "Id";
            this.ChosenId.Name = "ChosenId";
            this.ChosenId.ReadOnly = true;
            this.ChosenId.Visible = false;
            this.ChosenId.Width = 75;
            // 
            // ChosenNo
            // 
            this.ChosenNo.HeaderText = "STT";
            this.ChosenNo.Name = "ChosenNo";
            // 
            // ChosenSerial
            // 
            this.ChosenSerial.HeaderText = "Số hiệu";
            this.ChosenSerial.Name = "ChosenSerial";
            this.ChosenSerial.ReadOnly = true;
            // 
            // ChosenReferenceNumber
            // 
            this.ChosenReferenceNumber.HeaderText = "Số vào sổ";
            this.ChosenReferenceNumber.Name = "ChosenReferenceNumber";
            // 
            // ChosenShowImage
            // 
            this.ChosenShowImage.HeaderText = "Xem ảnh";
            this.ChosenShowImage.Name = "ChosenShowImage";
            this.ChosenShowImage.Text = "Xem ảnh";
            this.ChosenShowImage.UseColumnTextForButtonValue = true;
            // 
            // Remove
            // 
            this.Remove.HeaderText = "Xóa";
            this.Remove.Name = "Remove";
            this.Remove.Text = "Xóa";
            this.Remove.UseColumnTextForButtonValue = true;
            // 
            // SelectBlankCertForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 581);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1100, 620);
            this.Name = "SelectBlankCertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn phôi";
            this.Load += new System.EventHandler(this.SelectBlankCertForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlankCertDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChosenBlankCertDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SerialTextBox;
        private System.Windows.Forms.DataGridView BlankCertDataGridView;
        private System.Windows.Forms.Button ResetBlankCertButton;
        private System.Windows.Forms.Button SearchBlankCertButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView ChosenBlankCertDataGridView;
        private System.Windows.Forms.Button ChosenResetBlankCertButton;
        private System.Windows.Forms.Button ChosenSearchBlankCertButton;
        private System.Windows.Forms.TextBox ChosenSerialTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CertNameTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewButtonColumn ShowImage;
        private System.Windows.Forms.DataGridViewButtonColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChosenId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChosenNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChosenSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChosenReferenceNumber;
        private System.Windows.Forms.DataGridViewButtonColumn ChosenShowImage;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
    }
}