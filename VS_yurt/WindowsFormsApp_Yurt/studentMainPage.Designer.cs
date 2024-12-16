using System;

namespace WindowsFormsApp_Yurt
{
    partial class studentMainPage
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
            this.labelStudentName = new System.Windows.Forms.Label();
            this.labelStudentId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelStudentName
            // 
            this.labelStudentName.AutoSize = true;
            this.labelStudentName.Location = new System.Drawing.Point(63, 40);
            this.labelStudentName.Name = "labelStudentName";
            this.labelStudentName.Size = new System.Drawing.Size(87, 16);
            this.labelStudentName.TabIndex = 0;
            this.labelStudentName.Text = "student name";
            this.labelStudentName.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelStudentId
            // 
            this.labelStudentId.AutoSize = true;
            this.labelStudentId.Location = new System.Drawing.Point(63, 70);
            this.labelStudentId.Name = "labelStudentId";
            this.labelStudentId.Size = new System.Drawing.Size(44, 16);
            this.labelStudentId.TabIndex = 1;
            this.labelStudentId.Text = "label2";
            // 
            // studentMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 575);
            this.Controls.Add(this.labelStudentId);
            this.Controls.Add(this.labelStudentName);
            this.Name = "studentMainPage";
            this.Text = "studentmainpage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal void Show()
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label labelStudentName;
        private System.Windows.Forms.Label labelStudentId;
        private string fullName;
        private string iban;
        private string phoneNumber;
        private string roomNumber;
        private DateTime entryTime;
        private DateTime exitTime;
        private decimal deposit;
        private DateTime birthDate;
        private string department;
        private string grade;
        private string university;

        public studentMainPage(int studentId, string fullName, string iban, string phoneNumber, string roomNumber, DateTime entryTime, DateTime exitTime, decimal deposit, DateTime birthDate, string department, string grade, string university)
        {
            this.studentId = studentId;
            this.fullName = fullName;
            this.iban = iban;
            this.phoneNumber = phoneNumber;
            this.roomNumber = roomNumber;
            this.entryTime = entryTime;
            this.exitTime = exitTime;
            this.deposit = deposit;
            this.birthDate = birthDate;
            this.department = department;
            this.grade = grade;
            this.university = university;
        }
    }
}