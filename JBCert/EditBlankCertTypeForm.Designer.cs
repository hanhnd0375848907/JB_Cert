namespace JBCert
{
    partial class EditBlankCertTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBlankCertTypeForm));
            this.CancelBlankCertTypeButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NoteRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BlankCertTypeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelBlankCertTypeButton
            // 
            this.CancelBlankCertTypeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBlankCertTypeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBlankCertTypeButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBlankCertTypeButton.Location = new System.Drawing.Point(272, 238);
            this.CancelBlankCertTypeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelBlankCertTypeButton.Name = "CancelBlankCertTypeButton";
            this.CancelBlankCertTypeButton.Size = new System.Drawing.Size(85, 27);
            this.CancelBlankCertTypeButton.TabIndex = 13;
            this.CancelBlankCertTypeButton.Text = "Hủy bỏ";
            this.CancelBlankCertTypeButton.UseVisualStyleBackColor = true;
            this.CancelBlankCertTypeButton.Click += new System.EventHandler(this.CancelBlankCertTypeButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(387, 238);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(82, 27);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Sửa";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NoteRichTextBox
            // 
            this.NoteRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoteRichTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteRichTextBox.Location = new System.Drawing.Point(109, 53);
            this.NoteRichTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NoteRichTextBox.Name = "NoteRichTextBox";
            this.NoteRichTextBox.Size = new System.Drawing.Size(362, 165);
            this.NoteRichTextBox.TabIndex = 11;
            this.NoteRichTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ghi chú";
            // 
            // BlankCertTypeTextBox
            // 
            this.BlankCertTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BlankCertTypeTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlankCertTypeTextBox.Location = new System.Drawing.Point(109, 16);
            this.BlankCertTypeTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BlankCertTypeTextBox.Name = "BlankCertTypeTextBox";
            this.BlankCertTypeTextBox.Size = new System.Drawing.Size(362, 25);
            this.BlankCertTypeTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên kiểu phôi";
            // 
            // EditBlankCertTypeForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBlankCertTypeButton;
            this.ClientSize = new System.Drawing.Size(484, 292);
            this.Controls.Add(this.CancelBlankCertTypeButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NoteRichTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BlankCertTypeTextBox);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditBlankCertTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa kiểu phôi";
            this.Load += new System.EventHandler(this.EditBlankCertTypeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBlankCertTypeButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.RichTextBox NoteRichTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BlankCertTypeTextBox;
        private System.Windows.Forms.Label label2;
    }
}