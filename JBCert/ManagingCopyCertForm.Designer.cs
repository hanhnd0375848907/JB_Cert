namespace JBCert
{
    partial class ManagingCopyCertForm
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
            this.CopyCertDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.CopyCertDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CopyCertDataGridView
            // 
            this.CopyCertDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CopyCertDataGridView.Location = new System.Drawing.Point(13, 72);
            this.CopyCertDataGridView.Name = "CopyCertDataGridView";
            this.CopyCertDataGridView.Size = new System.Drawing.Size(720, 477);
            this.CopyCertDataGridView.TabIndex = 0;
            // 
            // ManagingCopyCertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.CopyCertDataGridView);
            this.Name = "ManagingCopyCertForm";
            this.Text = "ManagingCopyCertForm";
            ((System.ComponentModel.ISupportInitialize)(this.CopyCertDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CopyCertDataGridView;
    }
}