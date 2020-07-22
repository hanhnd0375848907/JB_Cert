﻿namespace JBCert
{
    partial class AddSchoolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSchoolForm));
            this.label1 = new System.Windows.Forms.Label();
            this.SchoolNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BlankCertTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ProvinceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TownComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VillageComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FaxTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Representative = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.AddSchoolButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.NoteRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên trường";
            // 
            // SchoolNameTextBox
            // 
            this.SchoolNameTextBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolNameTextBox.Location = new System.Drawing.Point(11, 24);
            this.SchoolNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SchoolNameTextBox.Name = "SchoolNameTextBox";
            this.SchoolNameTextBox.Size = new System.Drawing.Size(312, 24);
            this.SchoolNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(373, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại";
            // 
            // BlankCertTypeComboBox
            // 
            this.BlankCertTypeComboBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlankCertTypeComboBox.FormattingEnabled = true;
            this.BlankCertTypeComboBox.Location = new System.Drawing.Point(376, 23);
            this.BlankCertTypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.BlankCertTypeComboBox.Name = "BlankCertTypeComboBox";
            this.BlankCertTypeComboBox.Size = new System.Drawing.Size(297, 25);
            this.BlankCertTypeComboBox.TabIndex = 3;
            // 
            // ProvinceTextBox
            // 
            this.ProvinceTextBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProvinceTextBox.Location = new System.Drawing.Point(11, 91);
            this.ProvinceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProvinceTextBox.Name = "ProvinceTextBox";
            this.ProvinceTextBox.ReadOnly = true;
            this.ProvinceTextBox.Size = new System.Drawing.Size(106, 24);
            this.ProvinceTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tỉnh";
            // 
            // TownComboBox
            // 
            this.TownComboBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TownComboBox.FormattingEnabled = true;
            this.TownComboBox.Location = new System.Drawing.Point(163, 90);
            this.TownComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.TownComboBox.Name = "TownComboBox";
            this.TownComboBox.Size = new System.Drawing.Size(239, 25);
            this.TownComboBox.TabIndex = 7;
            this.TownComboBox.SelectedIndexChanged += new System.EventHandler(this.TownComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(160, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Huyện";
            // 
            // VillageComboBox
            // 
            this.VillageComboBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VillageComboBox.FormattingEnabled = true;
            this.VillageComboBox.Location = new System.Drawing.Point(441, 91);
            this.VillageComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.VillageComboBox.Name = "VillageComboBox";
            this.VillageComboBox.Size = new System.Drawing.Size(232, 25);
            this.VillageComboBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(438, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Xã";
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressTextBox.Location = new System.Drawing.Point(14, 159);
            this.AddressTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(659, 24);
            this.AddressTextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 141);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Địa chỉ";
            // 
            // PhoneNumberTextBox
            // 
            this.PhoneNumberTextBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNumberTextBox.Location = new System.Drawing.Point(14, 242);
            this.PhoneNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            this.PhoneNumberTextBox.Size = new System.Drawing.Size(154, 24);
            this.PhoneNumberTextBox.TabIndex = 13;
            this.PhoneNumberTextBox.Leave += new System.EventHandler(this.PhoneNumberTextBox_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 224);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Số điện thoại";
            // 
            // FaxTextBox
            // 
            this.FaxTextBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FaxTextBox.Location = new System.Drawing.Point(220, 242);
            this.FaxTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FaxTextBox.Name = "FaxTextBox";
            this.FaxTextBox.Size = new System.Drawing.Size(154, 24);
            this.FaxTextBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(217, 224);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fax";
            // 
            // Representative
            // 
            this.Representative.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Representative.Location = new System.Drawing.Point(423, 242);
            this.Representative.Margin = new System.Windows.Forms.Padding(2);
            this.Representative.Name = "Representative";
            this.Representative.Size = new System.Drawing.Size(250, 24);
            this.Representative.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(420, 224);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Người đại diện";
            // 
            // AddSchoolButton
            // 
            this.AddSchoolButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSchoolButton.Location = new System.Drawing.Point(564, 400);
            this.AddSchoolButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddSchoolButton.Name = "AddSchoolButton";
            this.AddSchoolButton.Size = new System.Drawing.Size(109, 35);
            this.AddSchoolButton.TabIndex = 18;
            this.AddSchoolButton.Text = "Thêm trường";
            this.AddSchoolButton.UseVisualStyleBackColor = true;
            this.AddSchoolButton.Click += new System.EventHandler(this.AddSchoolButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(475, 400);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(79, 35);
            this.CancelButton.TabIndex = 19;
            this.CancelButton.Text = "Hủy";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 299);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ghi chú";
            // 
            // NoteRichTextBox
            // 
            this.NoteRichTextBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteRichTextBox.Location = new System.Drawing.Point(14, 318);
            this.NoteRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NoteRichTextBox.Name = "NoteRichTextBox";
            this.NoteRichTextBox.Size = new System.Drawing.Size(659, 62);
            this.NoteRichTextBox.TabIndex = 21;
            this.NoteRichTextBox.Text = "";
            // 
            // AddSchoolForm
            // 
            this.AcceptButton = this.AddSchoolButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.NoteRichTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddSchoolButton);
            this.Controls.Add(this.Representative);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.FaxTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PhoneNumberTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.VillageComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TownComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProvinceTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BlankCertTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SchoolNameTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "AddSchoolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm trường học";
            this.Load += new System.EventHandler(this.AddSchoolForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SchoolNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BlankCertTypeComboBox;
        private System.Windows.Forms.TextBox ProvinceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TownComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox VillageComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PhoneNumberTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox FaxTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Representative;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button AddSchoolButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox NoteRichTextBox;
    }
}