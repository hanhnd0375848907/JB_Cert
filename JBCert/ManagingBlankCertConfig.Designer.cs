namespace JBCert
{
    partial class ManagingBlankCertConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.BlankCertTypeComboBox = new System.Windows.Forms.ComboBox();
            this.IsActiveComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.BlankCertConfigDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlankCertTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AddButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BlankCertConfigDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại phôi";
            // 
            // BlankCertTypeComboBox
            // 
            this.BlankCertTypeComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlankCertTypeComboBox.FormattingEnabled = true;
            this.BlankCertTypeComboBox.Location = new System.Drawing.Point(82, 50);
            this.BlankCertTypeComboBox.Name = "BlankCertTypeComboBox";
            this.BlankCertTypeComboBox.Size = new System.Drawing.Size(287, 25);
            this.BlankCertTypeComboBox.TabIndex = 1;
            // 
            // IsActiveComboBox
            // 
            this.IsActiveComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsActiveComboBox.FormattingEnabled = true;
            this.IsActiveComboBox.Location = new System.Drawing.Point(469, 50);
            this.IsActiveComboBox.Name = "IsActiveComboBox";
            this.IsActiveComboBox.Size = new System.Drawing.Size(75, 25);
            this.IsActiveComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(391, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trạng thái";
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(578, 49);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(89, 25);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Tìm kiếm";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // BlankCertConfigDataGridView
            // 
            this.BlankCertConfigDataGridView.AllowUserToAddRows = false;
            this.BlankCertConfigDataGridView.AllowUserToDeleteRows = false;
            this.BlankCertConfigDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BlankCertConfigDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.BlankCertConfigDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BlankCertConfigDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.RowCheckBox,
            this.No,
            this.BlankCertTypeName,
            this.CreatedAt,
            this.IsActive,
            this.Detail,
            this.Delete});
            this.BlankCertConfigDataGridView.EnableHeadersVisualStyles = false;
            this.BlankCertConfigDataGridView.Location = new System.Drawing.Point(13, 81);
            this.BlankCertConfigDataGridView.Name = "BlankCertConfigDataGridView";
            this.BlankCertConfigDataGridView.ReadOnly = true;
            this.BlankCertConfigDataGridView.RowHeadersVisible = false;
            this.BlankCertConfigDataGridView.Size = new System.Drawing.Size(1023, 468);
            this.BlankCertConfigDataGridView.TabIndex = 5;
            this.BlankCertConfigDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BlankCertConfigDataGridView_CellContentClick);
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
            this.RowCheckBox.HeaderText = "";
            this.RowCheckBox.Name = "RowCheckBox";
            this.RowCheckBox.ReadOnly = true;
            this.RowCheckBox.Visible = false;
            this.RowCheckBox.Width = 60;
            // 
            // No
            // 
            this.No.HeaderText = "STT";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 60;
            // 
            // BlankCertTypeName
            // 
            this.BlankCertTypeName.HeaderText = "Loại phôi";
            this.BlankCertTypeName.Name = "BlankCertTypeName";
            this.BlankCertTypeName.ReadOnly = true;
            this.BlankCertTypeName.Width = 200;
            // 
            // CreatedAt
            // 
            this.CreatedAt.HeaderText = "Ngày tạo";
            this.CreatedAt.Name = "CreatedAt";
            this.CreatedAt.ReadOnly = true;
            this.CreatedAt.Width = 200;
            // 
            // IsActive
            // 
            this.IsActive.HeaderText = "Trạng thái phôi";
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            this.IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IsActive.Width = 150;
            // 
            // Detail
            // 
            this.Detail.HeaderText = "Chi tiết";
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            this.Detail.Text = "Chi tiết";
            this.Detail.UseColumnTextForButtonValue = true;
            this.Detail.Visible = false;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Xóa";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Xóa";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Visible = false;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(1053, 81);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 25);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Thêm mới";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Danh sách cấu hình in phôi";
            // 
            // ManagingBlankCertConfig
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.BlankCertConfigDataGridView);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.IsActiveComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BlankCertTypeComboBox);
            this.Controls.Add(this.label1);
            this.Name = "ManagingBlankCertConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagingBlankCertConfig";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManagingBlankCertConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BlankCertConfigDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BlankCertTypeComboBox;
        private System.Windows.Forms.ComboBox IsActiveComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView BlankCertConfigDataGridView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RowCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlankCertTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewButtonColumn Detail;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Label label3;
    }
}