namespace JBCert
{
    partial class AddBlankCertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBlankCertForm));
            this.label2 = new System.Windows.Forms.Label();
            this.SerialCertTextBox = new System.Windows.Forms.TextBox();
            this.ChooseCertImageButton = new System.Windows.Forms.Button();
            this.AddBlankCertButton = new System.Windows.Forms.Button();
            this.BlankCertImagePictureBox = new System.Windows.Forms.PictureBox();
            this.BlankCertTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BlankCertImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Serial";
            // 
            // SerialCertTextBox
            // 
            this.SerialCertTextBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialCertTextBox.Location = new System.Drawing.Point(79, 18);
            this.SerialCertTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SerialCertTextBox.Name = "SerialCertTextBox";
            this.SerialCertTextBox.Size = new System.Drawing.Size(169, 24);
            this.SerialCertTextBox.TabIndex = 2;
            // 
            // ChooseCertImageButton
            // 
            this.ChooseCertImageButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseCertImageButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChooseCertImageButton.Location = new System.Drawing.Point(572, 17);
            this.ChooseCertImageButton.Margin = new System.Windows.Forms.Padding(2);
            this.ChooseCertImageButton.Name = "ChooseCertImageButton";
            this.ChooseCertImageButton.Size = new System.Drawing.Size(108, 25);
            this.ChooseCertImageButton.TabIndex = 3;
            this.ChooseCertImageButton.Text = "Chọn ảnh";
            this.ChooseCertImageButton.UseVisualStyleBackColor = true;
            this.ChooseCertImageButton.Click += new System.EventHandler(this.ChooseCertImageButton_Click);
            // 
            // AddBlankCertButton
            // 
            this.AddBlankCertButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBlankCertButton.Location = new System.Drawing.Point(797, 17);
            this.AddBlankCertButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddBlankCertButton.Name = "AddBlankCertButton";
            this.AddBlankCertButton.Size = new System.Drawing.Size(76, 25);
            this.AddBlankCertButton.TabIndex = 4;
            this.AddBlankCertButton.Text = "Lưu";
            this.AddBlankCertButton.UseVisualStyleBackColor = true;
            this.AddBlankCertButton.Click += new System.EventHandler(this.AddBlankCertButton_Click);
            // 
            // BlankCertImagePictureBox
            // 
            this.BlankCertImagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlankCertImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlankCertImagePictureBox.Location = new System.Drawing.Point(11, 55);
            this.BlankCertImagePictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.BlankCertImagePictureBox.Name = "BlankCertImagePictureBox";
            this.BlankCertImagePictureBox.Size = new System.Drawing.Size(866, 332);
            this.BlankCertImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BlankCertImagePictureBox.TabIndex = 6;
            this.BlankCertImagePictureBox.TabStop = false;
            // 
            // BlankCertTypeComboBox
            // 
            this.BlankCertTypeComboBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlankCertTypeComboBox.FormattingEnabled = true;
            this.BlankCertTypeComboBox.Location = new System.Drawing.Point(349, 18);
            this.BlankCertTypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.BlankCertTypeComboBox.Name = "BlankCertTypeComboBox";
            this.BlankCertTypeComboBox.Size = new System.Drawing.Size(194, 25);
            this.BlankCertTypeComboBox.TabIndex = 7;
            this.BlankCertTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BlankCertTypeComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(279, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Loại phôi";
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(711, 17);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(65, 25);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Thoát";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddBlankCertForm
            // 
            this.AcceptButton = this.AddBlankCertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 393);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BlankCertTypeComboBox);
            this.Controls.Add(this.BlankCertImagePictureBox);
            this.Controls.Add(this.AddBlankCertButton);
            this.Controls.Add(this.ChooseCertImageButton);
            this.Controls.Add(this.SerialCertTextBox);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddBlankCertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm phôi";
            this.Load += new System.EventHandler(this.AddBlankCertForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BlankCertImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SerialCertTextBox;
        private System.Windows.Forms.Button ChooseCertImageButton;
        private System.Windows.Forms.Button AddBlankCertButton;
        private System.Windows.Forms.PictureBox BlankCertImagePictureBox;
        private System.Windows.Forms.ComboBox BlankCertTypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelButton;
    }
}