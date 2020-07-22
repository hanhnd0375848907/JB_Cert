namespace JBCert
{
    partial class SelectRootOrCopyCertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectRootOrCopyCertForm));
            this.PrintCopyCertButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PrintRootCertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrintCopyCertButton
            // 
            this.PrintCopyCertButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintCopyCertButton.Location = new System.Drawing.Point(90, 93);
            this.PrintCopyCertButton.Name = "PrintCopyCertButton";
            this.PrintCopyCertButton.Size = new System.Drawing.Size(118, 28);
            this.PrintCopyCertButton.TabIndex = 13;
            this.PrintCopyCertButton.Text = "In bản sao";
            this.PrintCopyCertButton.UseVisualStyleBackColor = true;
            this.PrintCopyCertButton.Click += new System.EventHandler(this.PrintCopyCertButton_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(223, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 28);
            this.button2.TabIndex = 14;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PrintRootCertButton
            // 
            this.PrintRootCertButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintRootCertButton.Location = new System.Drawing.Point(90, 31);
            this.PrintRootCertButton.Name = "PrintRootCertButton";
            this.PrintRootCertButton.Size = new System.Drawing.Size(118, 28);
            this.PrintRootCertButton.TabIndex = 12;
            this.PrintRootCertButton.Text = "In văn bằng gốc";
            this.PrintRootCertButton.UseVisualStyleBackColor = true;
            this.PrintRootCertButton.Click += new System.EventHandler(this.PrintRootCertButton_Click);
            // 
            // SelectRootOrCopyCertForm
            // 
            this.AcceptButton = this.PrintRootCertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(311, 176);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PrintCopyCertButton);
            this.Controls.Add(this.PrintRootCertButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(327, 215);
            this.MinimumSize = new System.Drawing.Size(327, 215);
            this.Name = "SelectRootOrCopyCertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn kiểu in";
            this.Load += new System.EventHandler(this.SelectRootOrCopyCert_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button PrintCopyCertButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button PrintRootCertButton;
    }
}