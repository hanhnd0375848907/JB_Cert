namespace JBCert
{
    partial class ManagingRoleForm
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
            this.RoleNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PermissionCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.RoleCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.IsAddCheckBox = new System.Windows.Forms.CheckBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RoleNameTextBox
            // 
            this.RoleNameTextBox.Enabled = false;
            this.RoleNameTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoleNameTextBox.Location = new System.Drawing.Point(291, 76);
            this.RoleNameTextBox.Name = "RoleNameTextBox";
            this.RoleNameTextBox.Size = new System.Drawing.Size(325, 25);
            this.RoleNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên quyền";
            // 
            // PermissionCheckedListBox
            // 
            this.PermissionCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PermissionCheckedListBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PermissionCheckedListBox.FormattingEnabled = true;
            this.PermissionCheckedListBox.Location = new System.Drawing.Point(622, 19);
            this.PermissionCheckedListBox.Name = "PermissionCheckedListBox";
            this.PermissionCheckedListBox.Size = new System.Drawing.Size(238, 524);
            this.PermissionCheckedListBox.TabIndex = 3;
            // 
            // RoleCheckedListBox
            // 
            this.RoleCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RoleCheckedListBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoleCheckedListBox.FormattingEnabled = true;
            this.RoleCheckedListBox.Location = new System.Drawing.Point(12, 19);
            this.RoleCheckedListBox.Name = "RoleCheckedListBox";
            this.RoleCheckedListBox.Size = new System.Drawing.Size(242, 524);
            this.RoleCheckedListBox.TabIndex = 4;
            this.RoleCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.RoleCheckedListBox_ItemCheck);
            // 
            // IsAddCheckBox
            // 
            this.IsAddCheckBox.AutoSize = true;
            this.IsAddCheckBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsAddCheckBox.Location = new System.Drawing.Point(291, 21);
            this.IsAddCheckBox.Name = "IsAddCheckBox";
            this.IsAddCheckBox.Size = new System.Drawing.Size(138, 21);
            this.IsAddCheckBox.TabIndex = 5;
            this.IsAddCheckBox.Text = "Thêm mới quyền";
            this.IsAddCheckBox.UseVisualStyleBackColor = true;
            this.IsAddCheckBox.CheckedChanged += new System.EventHandler(this.IsAddCheckBox_CheckedChanged);
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(289, 128);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(140, 31);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Thêm mới";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(476, 205);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(140, 31);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Lưu";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(289, 205);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(140, 31);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Xóa";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ManagingRoleForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.IsAddCheckBox);
            this.Controls.Add(this.RoleCheckedListBox);
            this.Controls.Add(this.PermissionCheckedListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RoleNameTextBox);
            this.Name = "ManagingRoleForm";
            this.Text = "ManagingRoleForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManagingRoleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RoleNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox PermissionCheckedListBox;
        private System.Windows.Forms.CheckedListBox RoleCheckedListBox;
        private System.Windows.Forms.CheckBox IsAddCheckBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}