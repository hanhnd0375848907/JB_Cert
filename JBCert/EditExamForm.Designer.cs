namespace JBCert
{
    partial class EditExamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditExamForm));
            this.CancelButton = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SchoolNameComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ExamNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExamDateTextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(156, 165);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(104, 25);
            this.CancelButton.TabIndex = 22;
            this.CancelButton.Text = "Thoát";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(266, 165);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(104, 25);
            this.Save.TabIndex = 21;
            this.Save.Text = "Cập nhật";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Khóa thi";
            // 
            // SchoolNameComboBox
            // 
            this.SchoolNameComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolNameComboBox.FormattingEnabled = true;
            this.SchoolNameComboBox.Location = new System.Drawing.Point(40, 79);
            this.SchoolNameComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.SchoolNameComboBox.Name = "SchoolNameComboBox";
            this.SchoolNameComboBox.Size = new System.Drawing.Size(330, 25);
            this.SchoolNameComboBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tên trường";
            // 
            // ExamNameTextBox
            // 
            this.ExamNameTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExamNameTextBox.Location = new System.Drawing.Point(40, 28);
            this.ExamNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ExamNameTextBox.Name = "ExamNameTextBox";
            this.ExamNameTextBox.Size = new System.Drawing.Size(330, 25);
            this.ExamNameTextBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tên kỳ thi";
            // 
            // ExamDateTextBox
            // 
            this.ExamDateTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExamDateTextBox.Location = new System.Drawing.Point(40, 135);
            this.ExamDateTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ExamDateTextBox.Name = "ExamDateTextBox";
            this.ExamDateTextBox.Size = new System.Drawing.Size(330, 25);
            this.ExamDateTextBox.TabIndex = 23;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(109, 9);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(14, 18);
            this.label23.TabIndex = 46;
            this.label23.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(121, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 18);
            this.label4.TabIndex = 47;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(100, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 18);
            this.label5.TabIndex = 48;
            this.label5.Text = "*";
            // 
            // EditExamForm
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 202);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.ExamDateTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SchoolNameComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExamNameTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(439, 241);
            this.MinimumSize = new System.Drawing.Size(439, 241);
            this.Name = "EditExamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa kỳ thi / khóa thi";
            this.Load += new System.EventHandler(this.EditExamForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SchoolNameComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ExamNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ExamDateTextBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}