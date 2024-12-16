namespace WindowsFormsApp_Yurt
{
    partial class WorkerManagementPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerManagementPage));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.workerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yurt_DBDataSet1 = new WindowsFormsApp_Yurt.Yurt_DBDataSet1();
            this.workerTableAdapter = new WindowsFormsApp_Yurt.Yurt_DBDataSet1TableAdapters.WorkerTableAdapter();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGüncelle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yurt_DBDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Thistle;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 362);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(886, 227);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // workerBindingSource
            // 
            this.workerBindingSource.DataMember = "Worker";
            this.workerBindingSource.DataSource = this.yurt_DBDataSet1;
            // 
            // yurt_DBDataSet1
            // 
            this.yurt_DBDataSet1.DataSetName = "Yurt_DBDataSet1";
            this.yurt_DBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // workerTableAdapter
            // 
            this.workerTableAdapter.ClearBeforeFill = true;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(682, 10);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(236, 53);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "INSERT";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.ekle_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBack.Location = new System.Drawing.Point(40, 608);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(64, 52);
            this.btnBack.TabIndex = 1;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(217, 197);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(183, 22);
            this.textBox5.TabIndex = 20;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(217, 161);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(183, 22);
            this.textBox4.TabIndex = 19;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(217, 124);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(183, 22);
            this.textBox3.TabIndex = 18;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(217, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 22);
            this.textBox2.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 22);
            this.textBox1.TabIndex = 16;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "WorkerPassword";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "IdNumber";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "PhoneNumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "JobTitle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "FullName";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(682, 93);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(236, 53);
            this.btnSil.TabIndex = 21;
            this.btnSil.Text = "DELETE";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGüncelle
            // 
            this.btnGüncelle.Location = new System.Drawing.Point(682, 182);
            this.btnGüncelle.Name = "btnGüncelle";
            this.btnGüncelle.Size = new System.Drawing.Size(236, 53);
            this.btnGüncelle.TabIndex = 22;
            this.btnGüncelle.Text = "UPDATE";
            this.btnGüncelle.UseVisualStyleBackColor = true;
            this.btnGüncelle.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 16);
            this.label6.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "IsAdmin";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(217, 270);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "DormId";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(217, 234);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(183, 22);
            this.textBox6.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "WorkerID";
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(217, 12);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(183, 22);
            this.textBox7.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(443, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "Permission :";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(572, 48);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(443, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 32;
            this.label11.Text = "Ekleme";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(444, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 16);
            this.label12.TabIndex = 33;
            this.label12.Text = "Silme";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(444, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 16);
            this.label13.TabIndex = 34;
            this.label13.Text = "Güncelleme";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(572, 77);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(18, 17);
            this.checkBox3.TabIndex = 35;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(572, 105);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(18, 17);
            this.checkBox4.TabIndex = 36;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(29, 325);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(173, 16);
            this.label14.TabIndex = 37;
            this.label14.Text = "SEARCH ADMIN/WORKER";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(217, 322);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(441, 22);
            this.textBox8.TabIndex = 38;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(682, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 24);
            this.button1.TabIndex = 39;
            this.button1.Text = "SEARCH";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // WorkerManagementPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(979, 672);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGüncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridView1);
            this.Name = "WorkerManagementPage";
            this.Text = "WorkerManagementPage";
            this.Load += new System.EventHandler(this.WorkerManagementPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yurt_DBDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Yurt_DBDataSet1 yurt_DBDataSet1;
        private System.Windows.Forms.BindingSource workerBindingSource;
        private Yurt_DBDataSet1TableAdapters.WorkerTableAdapter workerTableAdapter;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGüncelle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button1;
    }
}