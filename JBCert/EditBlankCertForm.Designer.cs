namespace JBCert
{
    partial class EditBlankCertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBlankCertForm));
            this.SerialCertTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChooseCertImageButton = new System.Windows.Forms.Button();
            this.AddBlankCertButton = new System.Windows.Forms.Button();
            this.FailBlankCertCheckbox = new System.Windows.Forms.CheckBox();
            this.ReturnBlankCertCheckbox = new System.Windows.Forms.CheckBox();
            this.BlankCertImagePictureBox = new System.Windows.Forms.PictureBox();
            this.ReasonReturnRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BlankCertTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BlankCertImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SerialCertTextBox
            // 
            this.SerialCertTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialCertTextBox.Location = new System.Drawing.Point(81, 18);
            this.SerialCertTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SerialCertTextBox.Name = "SerialCertTextBox";
            this.SerialCertTextBox.Size = new System.Drawing.Size(129, 23);
            this.SerialCertTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số Serial";
            // 
            // ChooseCertImageButton
            // 
            this.ChooseCertImageButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseCertImageButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChooseCertImageButton.Location = new System.Drawing.Point(456, 17);
            this.ChooseCertImageButton.Margin = new System.Windows.Forms.Padding(2);
            this.ChooseCertImageButton.Name = "ChooseCertImageButton";
            this.ChooseCertImageButton.Size = new System.Drawing.Size(101, 25);
            this.ChooseCertImageButton.TabIndex = 5;
            this.ChooseCertImageButton.Text = "Chọn ảnh";
            this.ChooseCertImageButton.UseVisualStyleBackColor = true;
            this.ChooseCertImageButton.Click += new System.EventHandler(this.ChooseCertImageButton_Click);
            // 
            // AddBlankCertButton
            // 
            this.AddBlankCertButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBlankCertButton.Location = new System.Drawing.Point(576, 17);
            this.AddBlankCertButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddBlankCertButton.Name = "AddBlankCertButton";
            this.AddBlankCertButton.Size = new System.Drawing.Size(59, 25);
            this.AddBlankCertButton.TabIndex = 6;
            this.AddBlankCertButton.Text = "Thoát";
            this.AddBlankCertButton.UseVisualStyleBackColor = true;
            this.AddBlankCertButton.Click += new System.EventHandler(this.AddBlankCertButton_Click);
            // 
            // FailBlankCertCheckbox
            // 
            this.FailBlankCertCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FailBlankCertCheckbox.AutoSize = true;
            this.FailBlankCertCheckbox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FailBlankCertCheckbox.Location = new System.Drawing.Point(730, 19);
            this.FailBlankCertCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.FailBlankCertCheckbox.Name = "FailBlankCertCheckbox";
            this.FailBlankCertCheckbox.Size = new System.Drawing.Size(77, 21);
            this.FailBlankCertCheckbox.TabIndex = 7;
            this.FailBlankCertCheckbox.Text = "Lỗi phôi";
            this.FailBlankCertCheckbox.UseVisualStyleBackColor = true;
            this.FailBlankCertCheckbox.CheckedChanged += new System.EventHandler(this.FailBlankCertCheckbox_CheckedChanged);
            // 
            // ReturnBlankCertCheckbox
            // 
            this.ReturnBlankCertCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReturnBlankCertCheckbox.AutoSize = true;
            this.ReturnBlankCertCheckbox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnBlankCertCheckbox.Location = new System.Drawing.Point(817, 19);
            this.ReturnBlankCertCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.ReturnBlankCertCheckbox.Name = "ReturnBlankCertCheckbox";
            this.ReturnBlankCertCheckbox.Size = new System.Drawing.Size(106, 21);
            this.ReturnBlankCertCheckbox.TabIndex = 8;
            this.ReturnBlankCertCheckbox.Text = "Thu hồi phôi";
            this.ReturnBlankCertCheckbox.UseVisualStyleBackColor = true;
            this.ReturnBlankCertCheckbox.CheckedChanged += new System.EventHandler(this.ReturnBlankCertCheckbox_CheckedChanged);
            // 
            // BlankCertImagePictureBox
            // 
            this.BlankCertImagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlankCertImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlankCertImagePictureBox.Location = new System.Drawing.Point(8, 57);
            this.BlankCertImagePictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.BlankCertImagePictureBox.Name = "BlankCertImagePictureBox";
            this.BlankCertImagePictureBox.Size = new System.Drawing.Size(586, 329);
            this.BlankCertImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BlankCertImagePictureBox.TabIndex = 9;
            this.BlankCertImagePictureBox.TabStop = false;
            // 
            // ReasonReturnRichTextBox
            // 
            this.ReasonReturnRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReasonReturnRichTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReasonReturnRichTextBox.Location = new System.Drawing.Point(633, 57);
            this.ReasonReturnRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ReasonReturnRichTextBox.Name = "ReasonReturnRichTextBox";
            this.ReasonReturnRichTextBox.Size = new System.Drawing.Size(294, 330);
            this.ReasonReturnRichTextBox.TabIndex = 10;
            this.ReasonReturnRichTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(226, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Loại phôi";
            // 
            // BlankCertTypeComboBox
            // 
            this.BlankCertTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlankCertTypeComboBox.FormattingEnabled = true;
            this.BlankCertTypeComboBox.Location = new System.Drawing.Point(296, 17);
            this.BlankCertTypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.BlankCertTypeComboBox.Name = "BlankCertTypeComboBox";
            this.BlankCertTypeComboBox.Size = new System.Drawing.Size(154, 24);
            this.BlankCertTypeComboBox.TabIndex = 11;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(651, 17);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(60, 25);
            this.CancelButton.TabIndex = 13;
            this.CancelButton.Text = "Hủy";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditBlankCertForm
            // 
            this.AcceptButton = this.AddBlankCertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 393);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BlankCertTypeComboBox);
            this.Controls.Add(this.ReasonReturnRichTextBox);
            this.Controls.Add(this.BlankCertImagePictureBox);
            this.Controls.Add(this.ReturnBlankCertCheckbox);
            this.Controls.Add(this.FailBlankCertCheckbox);
            this.Controls.Add(this.AddBlankCertButton);
            this.Controls.Add(this.ChooseCertImageButton);
            this.Controls.Add(this.SerialCertTextBox);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditBlankCertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa phôi";
            this.Load += new System.EventHandler(this.EditBlankCertForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BlankCertImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SerialCertTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChooseCertImageButton;
        private System.Windows.Forms.Button AddBlankCertButton;
        private System.Windows.Forms.CheckBox FailBlankCertCheckbox;
        private System.Windows.Forms.CheckBox ReturnBlankCertCheckbox;
        private System.Windows.Forms.PictureBox BlankCertImagePictureBox;
        private System.Windows.Forms.RichTextBox ReasonReturnRichTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox BlankCertTypeComboBox;
        private System.Windows.Forms.Button CancelButton;
    }
}