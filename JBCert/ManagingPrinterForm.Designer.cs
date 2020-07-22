namespace JBCert
{
    partial class ManagingPrinterForm
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
            this.PrinterComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.XTextBox = new System.Windows.Forms.TextBox();
            this.CreateDocumentButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.YTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PrinterComboBox
            // 
            this.PrinterComboBox.FormattingEnabled = true;
            this.PrinterComboBox.Location = new System.Drawing.Point(12, 17);
            this.PrinterComboBox.Name = "PrinterComboBox";
            this.PrinterComboBox.Size = new System.Drawing.Size(139, 21);
            this.PrinterComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X :";
            // 
            // XTextBox
            // 
            this.XTextBox.Location = new System.Drawing.Point(64, 53);
            this.XTextBox.Name = "XTextBox";
            this.XTextBox.Size = new System.Drawing.Size(87, 20);
            this.XTextBox.TabIndex = 4;
            this.XTextBox.Text = "320";
            // 
            // CreateDocumentButton
            // 
            this.CreateDocumentButton.Location = new System.Drawing.Point(223, 11);
            this.CreateDocumentButton.Margin = new System.Windows.Forms.Padding(2);
            this.CreateDocumentButton.Name = "CreateDocumentButton";
            this.CreateDocumentButton.Size = new System.Drawing.Size(141, 27);
            this.CreateDocumentButton.TabIndex = 2;
            this.CreateDocumentButton.Text = "Tạo document";
            this.CreateDocumentButton.UseVisualStyleBackColor = true;
            this.CreateDocumentButton.Click += new System.EventHandler(this.CreateDocumentButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y :";
            // 
            // YTextBox
            // 
            this.YTextBox.Location = new System.Drawing.Point(64, 79);
            this.YTextBox.Name = "YTextBox";
            this.YTextBox.Size = new System.Drawing.Size(87, 20);
            this.YTextBox.TabIndex = 6;
            this.YTextBox.Text = "460";
            // 
            // ManagingPrinterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 368);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.YTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.XTextBox);
            this.Controls.Add(this.PrinterComboBox);
            this.Controls.Add(this.CreateDocumentButton);
            this.Name = "ManagingPrinterForm";
            this.Text = "ManagingPrinterForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManagingPrinterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PrinterComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox XTextBox;
        private System.Windows.Forms.Button CreateDocumentButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox YTextBox;
    }
}