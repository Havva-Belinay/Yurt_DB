namespace YedeklemeApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelBackupDate;
        private System.Windows.Forms.Label labelBackupFile;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.DateTimePicker dateTimePickerBackup;
        private System.Windows.Forms.TextBox textBoxBackupFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelBackupDate = new System.Windows.Forms.Label();
            this.labelBackupFile = new System.Windows.Forms.Label();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.dateTimePickerBackup = new System.Windows.Forms.DateTimePicker();
            this.textBoxBackupFile = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();

            // labelBackupDate
            this.labelBackupDate.AutoSize = true;
            this.labelBackupDate.Location = new System.Drawing.Point(10, 20);
            this.labelBackupDate.Name = "labelBackupDate";
            this.labelBackupDate.Size = new System.Drawing.Size(85, 13);
            this.labelBackupDate.TabIndex = 0;
            this.labelBackupDate.Text = "Yedekleme Tarihi:";

            // labelBackupFile
            this.labelBackupFile.AutoSize = true;
            this.labelBackupFile.Location = new System.Drawing.Point(10, 60);
            this.labelBackupFile.Name = "labelBackupFile";
            this.labelBackupFile.Size = new System.Drawing.Size(95, 13);
            this.labelBackupFile.TabIndex = 1;
            this.labelBackupFile.Text = "Yedekleme Dosyası:";

            // buttonBackup
            this.buttonBackup.Location = new System.Drawing.Point(10, 100);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(75, 23);
            this.buttonBackup.TabIndex = 2;
            this.buttonBackup.Text = "Yedekle";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);

            // buttonRestore
            this.buttonRestore.Location = new System.Drawing.Point(100, 100);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(75, 23);
            this.buttonRestore.TabIndex = 3;
            this.buttonRestore.Text = "Geri Yükle";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);

            // dateTimePickerBackup
            this.dateTimePickerBackup.Location = new System.Drawing.Point(120, 20);
            this.dateTimePickerBackup.Name = "dateTimePickerBackup";
            this.dateTimePickerBackup.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBackup.TabIndex = 4;

            // textBoxBackupFile
            this.textBoxBackupFile.Location = new System.Drawing.Point(120, 60);
            this.textBoxBackupFile.Name = "textBoxBackupFile";
            this.textBoxBackupFile.Size = new System.Drawing.Size(200, 20);
            this.textBoxBackupFile.TabIndex = 5;

            // openFileDialog
            this.openFileDialog.Filter = "Yedekleme Dosyaları|*.bak";

            // Form1
            this.ClientSize = new System.Drawing.Size(350, 150);
            this.Controls.Add(this.textBoxBackupFile);
            this.Controls.Add(this.dateTimePickerBackup);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.labelBackupFile);
            this.Controls.Add(this.labelBackupDate);
            this.Name = "Form1";
            this.Text = "Yedekleme ve Geri Yükleme";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
