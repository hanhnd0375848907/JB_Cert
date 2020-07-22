namespace JBCert
{
    partial class CertHelpDocForm
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
            this.CertHelpRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CertHelpRichTextBox
            // 
            this.CertHelpRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CertHelpRichTextBox.Location = new System.Drawing.Point(13, 13);
            this.CertHelpRichTextBox.Name = "CertHelpRichTextBox";
            this.CertHelpRichTextBox.ReadOnly = true;
            this.CertHelpRichTextBox.Size = new System.Drawing.Size(859, 536);
            this.CertHelpRichTextBox.TabIndex = 0;
            this.CertHelpRichTextBox.Text = "";
            // 
            // CertHelpDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.CertHelpRichTextBox);
            this.Name = "CertHelpDocForm";
            this.Text = "CertHelpDocForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CertHelpDocForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox CertHelpRichTextBox;
    }
}