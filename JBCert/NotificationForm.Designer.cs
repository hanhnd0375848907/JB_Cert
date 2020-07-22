namespace JBCert
{
    partial class NotificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationForm));
            this.ContentNotificationLabel = new System.Windows.Forms.Label();
            this.WarningPictureBox = new System.Windows.Forms.PictureBox();
            this.InformationPictureBox = new System.Windows.Forms.PictureBox();
            this.ErrorPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WarningPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformationPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentNotificationLabel
            // 
            this.ContentNotificationLabel.AutoSize = true;
            this.ContentNotificationLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContentNotificationLabel.Location = new System.Drawing.Point(103, 43);
            this.ContentNotificationLabel.Margin = new System.Windows.Forms.Padding(10, 20, 50, 20);
            this.ContentNotificationLabel.Name = "ContentNotificationLabel";
            this.ContentNotificationLabel.Size = new System.Drawing.Size(46, 17);
            this.ContentNotificationLabel.TabIndex = 0;
            this.ContentNotificationLabel.Text = "label1";
            // 
            // WarningPictureBox
            // 
            this.WarningPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("WarningPictureBox.Image")));
            this.WarningPictureBox.Location = new System.Drawing.Point(28, 29);
            this.WarningPictureBox.Name = "WarningPictureBox";
            this.WarningPictureBox.Size = new System.Drawing.Size(47, 44);
            this.WarningPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WarningPictureBox.TabIndex = 1;
            this.WarningPictureBox.TabStop = false;
            // 
            // InformationPictureBox
            // 
            this.InformationPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("InformationPictureBox.Image")));
            this.InformationPictureBox.Location = new System.Drawing.Point(28, 29);
            this.InformationPictureBox.Name = "InformationPictureBox";
            this.InformationPictureBox.Size = new System.Drawing.Size(47, 44);
            this.InformationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InformationPictureBox.TabIndex = 1;
            this.InformationPictureBox.TabStop = false;
            // 
            // ErrorPictureBox
            // 
            this.ErrorPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ErrorPictureBox.Image")));
            this.ErrorPictureBox.Location = new System.Drawing.Point(28, 29);
            this.ErrorPictureBox.Name = "ErrorPictureBox";
            this.ErrorPictureBox.Size = new System.Drawing.Size(47, 44);
            this.ErrorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ErrorPictureBox.TabIndex = 1;
            this.ErrorPictureBox.TabStop = false;
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(691, 117);
            this.Controls.Add(this.ErrorPictureBox);
            this.Controls.Add(this.InformationPictureBox);
            this.Controls.Add(this.WarningPictureBox);
            this.Controls.Add(this.ContentNotificationLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông báo";
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WarningPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformationPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ContentNotificationLabel;
        private System.Windows.Forms.PictureBox WarningPictureBox;
        private System.Windows.Forms.PictureBox InformationPictureBox;
        private System.Windows.Forms.PictureBox ErrorPictureBox;
    }
}