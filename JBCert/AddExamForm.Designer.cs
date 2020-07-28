namespace JBCert
{
    partial class AddExamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExamForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ExamNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SchoolNameComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ExamDateTextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên kỳ thi";
            // 
            // ExamNameTextBox
            // 
            this.ExamNameTextBox.Location = new System.Drawing.Point(60, 36);
            this.ExamNameTextBox.Name = "ExamNameTextBox";
            this.ExamNameTextBox.Size = new System.Drawing.Size(352, 25);
            this.ExamNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên trường";
            // 
            // SchoolNameComboBox
            // 
            this.SchoolNameComboBox.FormattingEnabled = true;
            this.SchoolNameComboBox.Location = new System.Drawing.Point(60, 102);
            this.SchoolNameComboBox.Name = "SchoolNameComboBox";
            this.SchoolNameComboBox.Size = new System.Drawing.Size(352, 25);
            this.SchoolNameComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khóa thi";
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(270, 223);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(142, 25);
            this.AddButton.TabIndex = 13;
            this.AddButton.Text = "Thêm kỳ thi";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(157, 223);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(105, 25);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Thoát";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ExamDateTextBox
            // 
            this.ExamDateTextBox.Location = new System.Drawing.Point(60, 171);
            this.ExamDateTextBox.Name = "ExamDateTextBox";
            this.ExamDateTextBox.Size = new System.Drawing.Size(352, 25);
            this.ExamDateTextBox.TabIndex = 15;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(125, 16);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(14, 18);
            this.label23.TabIndex = 44;
            this.label23.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(137, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 18);
            this.label4.TabIndex = 45;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(116, 151);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 18);
            this.label5.TabIndex = 46;
            this.label5.Text = "*";
            // 
            // AddExamForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 261);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.ExamDateTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SchoolNameComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExamNameTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(503, 300);
            this.MinimumSize = new System.Drawing.Size(503, 300);
            this.Name = "AddExamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm kỳ thi / khóa thi";
            this.Load += new System.EventHandler(this.AddExamForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ExamNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SchoolNameComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox ExamDateTextBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}