namespace WindowsFormsApp_Yurt
{
    partial class StudentManagementPage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.studentTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yurt_DBDataSet1 = new WindowsFormsApp_Yurt.Yurt_DBDataSet1();
            this.studentTableTableAdapter = new WindowsFormsApp_Yurt.Yurt_DBDataSet1TableAdapters.StudentTableTableAdapter();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.btnGüncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yurt_DBDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Thistle;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Thistle;
            this.dataGridView1.Location = new System.Drawing.Point(12, 370);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1048, 227);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // studentTableBindingSource
            // 
            this.studentTableBindingSource.DataMember = "StudentTable";
            this.studentTableBindingSource.DataSource = this.yurt_DBDataSet1;
            // 
            // yurt_DBDataSet1
            // 
            this.yurt_DBDataSet1.DataSetName = "Yurt_DBDataSet1";
            this.yurt_DBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentTableTableAdapter
            // 
            this.studentTableTableAdapter.ClearBeforeFill = true;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBack.Image = global::WindowsFormsApp_Yurt.Properties.Resources.Adsız__58_x_45_piksel___1_;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBack.Location = new System.Drawing.Point(12, 617);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(64, 52);
            this.btnBack.TabIndex = 2;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "StudentID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "FullName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "IdNumber";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "IBAN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "PhoneNumber";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "BedNumber";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "RoomNumber";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "ExitTime";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "EntryTime";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(361, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Deposit";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(361, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "BirtDate";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(361, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "Department";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(361, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 20);
            this.label13.TabIndex = 14;
            this.label13.Text = "Grade";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(361, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 20);
            this.label14.TabIndex = 13;
            this.label14.Text = "University";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(361, 186);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 20);
            this.label15.TabIndex = 12;
            this.label15.Text = "RoomID";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(361, 215);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 20);
            this.label16.TabIndex = 11;
            this.label16.Text = "DormBlockID";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(361, 248);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 20);
            this.label17.TabIndex = 19;
            this.label17.Text = "DormID";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(361, 280);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 20);
            this.label18.TabIndex = 20;
            this.label18.Text = "MealID";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(454, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 21;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 22);
            this.textBox1.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(130, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(198, 22);
            this.textBox2.TabIndex = 23;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(130, 92);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(198, 22);
            this.textBox3.TabIndex = 24;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(130, 121);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(198, 22);
            this.textBox4.TabIndex = 25;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(130, 154);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(198, 22);
            this.textBox5.TabIndex = 26;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(130, 184);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(198, 22);
            this.textBox6.TabIndex = 27;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(130, 215);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(198, 22);
            this.textBox7.TabIndex = 28;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(130, 248);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(198, 22);
            this.textBox8.TabIndex = 29;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(130, 280);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(198, 22);
            this.textBox9.TabIndex = 30;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(456, 56);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(198, 22);
            this.textBox10.TabIndex = 31;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(456, 83);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(198, 22);
            this.textBox11.TabIndex = 32;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(456, 118);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(198, 22);
            this.textBox12.TabIndex = 33;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(456, 152);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(198, 22);
            this.textBox13.TabIndex = 34;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(456, 180);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(198, 22);
            this.textBox14.TabIndex = 35;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(456, 210);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(198, 22);
            this.textBox15.TabIndex = 36;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(456, 238);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(198, 22);
            this.textBox16.TabIndex = 37;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(456, 271);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(198, 22);
            this.textBox17.TabIndex = 38;
            // 
            // btnGüncelle
            // 
            this.btnGüncelle.Location = new System.Drawing.Point(701, 182);
            this.btnGüncelle.Name = "btnGüncelle";
            this.btnGüncelle.Size = new System.Drawing.Size(359, 53);
            this.btnGüncelle.TabIndex = 41;
            this.btnGüncelle.Text = "UPDATE";
            this.btnGüncelle.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(701, 249);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(359, 53);
            this.btnSil.TabIndex = 40;
            this.btnSil.Text = "DELETE";
            this.btnSil.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(701, 109);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(359, 53);
            this.btnEkle.TabIndex = 39;
            this.btnEkle.Text = "INSERT";
            this.btnEkle.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(701, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(359, 24);
            this.button1.TabIndex = 44;
            this.button1.Text = "SEARCH";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(178, 333);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(476, 22);
            this.textBox18.TabIndex = 43;
            this.textBox18.TextChanged += new System.EventHandler(this.textBox18_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.Location = new System.Drawing.Point(13, 336);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(165, 20);
            this.label19.TabIndex = 42;
            this.label19.Text = "SEARCH STUDENT";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(827, 59);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(198, 22);
            this.textBox19.TabIndex = 48;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(827, 25);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(198, 22);
            this.textBox20.TabIndex = 47;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(698, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(140, 20);
            this.label20.TabIndex = 46;
            this.label20.Text = "StudentPassword";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(698, 30);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 16);
            this.label21.TabIndex = 45;
            this.label21.Text = "ParentID";
            // 
            // StudentManagementPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1120, 681);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnGüncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StudentManagementPage";
            this.Text = "StudentManagementPage";
            this.Load += new System.EventHandler(this.StudentManagementPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yurt_DBDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Yurt_DBDataSet1 yurt_DBDataSet1;
        private System.Windows.Forms.BindingSource studentTableBindingSource;
        private Yurt_DBDataSet1TableAdapters.StudentTableTableAdapter studentTableTableAdapter;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Button btnGüncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
    }
}