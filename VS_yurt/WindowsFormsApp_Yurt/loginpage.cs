using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;


namespace WindowsFormsApp_Yurt
{
    public partial class loginpage : Form
    {
        public string Worker { get; private set; }
        public string StudentTable { get; private set; }

        
        public loginpage()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);
        }
        
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan değerler
            string tc = textBox1.Text.Trim();  // TC alanı (kullanıcı adı)
            string password =sha256(textBox2.Text.Trim());  // Şifre alanı
           
            // Veritabanı bağlantı stringi
            string connectionString = "Server=LAPTOP-VCIVPG77\\VTYS;Database=Yurt_DB;Trusted_Connection=True;";

            //string studentQuery = "SELECT 'Student' AS Role, StudentID AS IdNumber FROM Student WHERE IdNumber = @tc AND Sifre = HASHBYTES('SHA2_256', @password)";
            string studentQuery = "SELECT * FROM StudentTable WHERE IdNumber = @tc AND StudentPassword = @password";
            //string workerQuery = "SELECT 'Worker' AS Role, WorkerID AS UserID, IsAdmin FROM Worker WHERE IdNumber = @tc AND WorkerPassword = @password";
            string workerQuery = "SELECT * FROM Worker WHERE IdNumber = @tc AND WorkerPassword = @password";
            // Sorgu
            // string query = "SELECT COUNT(*) FROM Worker WHERE IdNumber = @tc AND WorkerPassword = @password";

            // Veritabanı bağlantısı ve komutu

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //  Öğrenci değilse, işçi sorgusunu çalıştır
                    using (SqlCommand command = new SqlCommand(workerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@tc", tc);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fullname = Convert.ToString(reader["FullName"]);
                                int isAdmin = Convert.ToInt32(reader["IsAdmin"]);
                                //MessageBox.Show("IsAdmin: " + reader["IsAdmin"], "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                mainpage WorkerPage = new mainpage(fullname, isAdmin);
                                if (isAdmin ==1)
                                {
                                    // Admin giriş başarılı
                                    MessageBox.Show("Admin girişi başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Admin sayfasına yönlendirme yapılabilir
                                    WorkerPage.Show();
                                    this.Hide();  // Giriş sayfasını gizle
                                    connection.Close();
                                }
                                else
                                {
                                    // İşçi giriş başarılı
                                    MessageBox.Show("Worker girişi başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    WorkerPage.Show();
                                    connection.Close();
                                    // İşçi sayfasına yönlendirme yapılabilir
                                }
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı bulunamadı!", "Başarısız!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    // Öğrenci sorgusunu çalıştır
                    using (SqlCommand command = new SqlCommand(studentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@tc", tc);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                // Öğrenci verilerini al
                                int studentId = Convert.ToInt32(reader["StudentID"]);
                                string name = reader["Name"].ToString();
                                string surname = reader["Surname"].ToString();
                                string idNumber = reader["IdNumber"].ToString();

                                // Öğrenciyi başarılı şekilde giriş yaptıysa ana sayfaya yönlendir
                                studentMainPage studentPage = new studentMainPage(studentId, name, surname, idNumber);
                                studentPage.Show();
                                this.Hide();  // Giriş sayfasını gizle

                                // Öğrenci girişi başarılı
                                MessageBox.Show("Öğrenci giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Başka sayfaya yönlendirme işlemi burada yapılabilir
                                return;
                            }
                        }
                    }

                    // Kullanıcı bulunamadı veya şifre hatalı
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    //string logPath = "error_log.txt"; // Log dosyasının yolu
                    //string logMessage = $"{DateTime.Now}: {ex.Message}\n{ex.StackTrace}";
                    //File.AppendAllText(logPath, logMessage);
                }
            }
        }

        private void loginpage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
    }

