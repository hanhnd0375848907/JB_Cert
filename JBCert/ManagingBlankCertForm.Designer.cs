namespace JBCert
{
    partial class ManagingBlankCertForm
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
            this.AddBlankCertButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SerialTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BlankCertTypeComboBox = new System.Windows.Forms.ComboBox();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SeachButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.BlankCertDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsReturned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlankCertType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectAllCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.BlankCertDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddBlankCertButton
            // 
            this.AddBlankCertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBlankCertButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBlankCertButton.Location = new System.Drawing.Point(9, 11);
            this.AddBlankCertButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddBlankCertButton.Name = "AddBlankCertButton";
            this.AddBlankCertButton.Size = new System.Drawing.Size(115, 25);
            this.AddBlankCertButton.TabIndex = 0;
            this.AddBlankCertButton.Text = "Thêm";
            this.AddBlankCertButton.UseVisualStyleBackColor = true;
            this.AddBlankCertButton.Click += new System.EventHandler(this.AddBlankCertButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số hiệu";
            // 
            // SerialTextBox
            // 
            this.SerialTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialTextBox.Location = new System.Drawing.Point(11, 53);
            this.SerialTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SerialTextBox.Name = "SerialTextBox";
            this.SerialTextBox.Size = new System.Drawing.Size(151, 25);
            this.SerialTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Loại phôi";
            // 
            // BlankCertTypeComboBox
            // 
            this.BlankCertTypeComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlankCertTypeComboBox.FormattingEnabled = true;
            this.BlankCertTypeComboBox.Location = new System.Drawing.Point(189, 53);
            this.BlankCertTypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.BlankCertTypeComboBox.Name = "BlankCertTypeComboBox";
            this.BlankCertTypeComboBox.Size = new System.Drawing.Size(169, 25);
            this.BlankCertTypeComboBox.TabIndex = 5;
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Location = new System.Drawing.Point(396, 53);
            this.StatusComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(83, 25);
            this.StatusComboBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(393, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Trạng thái";
            // 
            // SeachButton
            // 
            this.SeachButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeachButton.Location = new System.Drawing.Point(532, 52);
            this.SeachButton.Margin = new System.Windows.Forms.Padding(2);
            this.SeachButton.Name = "SeachButton";
            this.SeachButton.Size = new System.Drawing.Size(115, 25);
            this.SeachButton.TabIndex = 8;
            this.SeachButton.Text = "Tìm kiếm";
            this.SeachButton.UseVisualStyleBackColor = true;
            this.SeachButton.Click += new System.EventHandler(this.SeachButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(8, 69);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(115, 25);
            this.DeleteButton.TabIndex = 9;
            this.DeleteButton.Text = "Xóa";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(9, 40);
            this.EditButton.Margin = new System.Windows.Forms.Padding(2);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(115, 25);
            this.EditButton.TabIndex = 10;
            this.EditButton.Text = "Sửa";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // BlankCertDataGridView
            // 
            this.BlankCertDataGridView.AllowUserToAddRows = false;
            this.BlankCertDataGridView.AllowUserToDeleteRows = false;
            this.BlankCertDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BlankCertDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.BlankCertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BlankCertDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.RowCheckBox,
            this.No,
            this.Serial,
            this.IsAvailable,
            this.IsReturned,
            this.CreatedDate,
            this.BlankCertType,
            this.UpdatedDate,
            this.Edit,
            this.Delete});
            this.BlankCertDataGridView.EnableHeadersVisualStyles = false;
            this.BlankCertDataGridView.Location = new System.Drawing.Point(11, 110);
            this.BlankCertDataGridView.Name = "BlankCertDataGridView";
            this.BlankCertDataGridView.RowHeadersVisible = false;
            this.BlankCertDataGridView.Size = new System.Drawing.Size(1017, 439);
            this.BlankCertDataGridView.TabIndex = 11;
            this.BlankCertDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BlankCertDataGridView_CellContentClick);
            this.BlankCertDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.BlankCertDataGridView_CellValueChanged);
            this.BlankCertDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.BlankCertDataGridView_CurrentCellDirtyStateChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // RowCheckBox
            // 
            this.RowCheckBox.HeaderText = "Chọn";
            this.RowCheckBox.Name = "RowCheckBox";
            this.RowCheckBox.Width = 60;
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
            this.Serial.Width = 150;
            // 
            // IsAvailable
            // 
            this.IsAvailable.HeaderText = "Có thể sử dụng";
            this.IsAvailable.Name = "IsAvailable";
            this.IsAvailable.ReadOnly = true;
            this.IsAvailable.Width = 150;
            // 
            // IsReturned
            // 
            this.IsReturned.HeaderText = "Thu Hồi";
            this.IsReturned.Name = "IsReturned";
            this.IsReturned.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "Ngày thêm vào";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Width = 200;
            // 
            // BlankCertType
            // 
            this.BlankCertType.HeaderText = "Kiểu phôi";
            this.BlankCertType.Name = "BlankCertType";
            this.BlankCertType.ReadOnly = true;
            this.BlankCertType.Width = 200;
            // 
            // UpdatedDate
            // 
            this.UpdatedDate.HeaderText = "Ngày cập nhật";
            this.UpdatedDate.Name = "UpdatedDate";
            this.UpdatedDate.ReadOnly = true;
            this.UpdatedDate.Width = 200;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Sửa";
            this.Edit.Name = "Edit";
            this.Edit.Visible = false;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Xóa";
            this.Delete.Name = "Delete";
            this.Delete.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.EditButton);
            this.panel2.Controls.Add(this.AddBlankCertButton);
            this.panel2.Controls.Add(this.DeleteButton);
            this.panel2.Location = new System.Drawing.Point(1037, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(135, 105);
            this.panel2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Danh sách phôi";
            // 
            // SelectAllCheckBox
            // 
            this.SelectAllCheckBox.AutoSize = true;
            this.SelectAllCheckBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllCheckBox.Location = new System.Drawing.Point(11, 83);
            this.SelectAllCheckBox.Name = "SelectAllCheckBox";
            this.SelectAllCheckBox.Size = new System.Drawing.Size(102, 21);
            this.SelectAllCheckBox.TabIndex = 17;
            this.SelectAllCheckBox.Text = "Chọn tất cả";
            this.SelectAllCheckBox.UseVisualStyleBackColor = true;
            this.SelectAllCheckBox.Click += new System.EventHandler(this.SelectAllCheckBox_Click);
            // 
            // ManagingBlankCertForm
            // 
            this.AcceptButton = this.AddBlankCertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.SelectAllCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BlankCertDataGridView);
            this.Controls.Add(this.SeachButton);
            this.Controls.Add(this.StatusComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BlankCertTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SerialTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManagingBlankCertForm";
            this.Text = "ManagingBlankCertForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManagingBlankCertForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BlankCertDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddBlankCertButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SerialTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BlankCertTypeComboBox;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SeachButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.DataGridView BlankCertDataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RowCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsReturned;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlankCertType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdatedDate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox SelectAllCheckBox;
    }
}