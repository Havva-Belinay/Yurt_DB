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

namespace WindowsFormsApp_Yurt
{
    public partial class loginpage : Form
    {
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan değerler
            string tc = textBox1.Text.Trim();  // TC alanı (kullanıcı adı)
            string password = textBox2.Text.Trim();  // Şifre alanı

            // Veritabanı bağlantı stringi
            string connectionString = "Server=LAPTOP-VCIVPG77\\VTYS;Database=Yurt_DB;Trusted_Connection=True;";

            // Sorgu
            string query = "SELECT COUNT(*) FROM Worker WHERE IdNumber = @tc AND WorkerPassword = @password";

            // Veritabanı bağlantısı ve komutu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@tc", tc);
                        command.Parameters.AddWithValue("@password", password);

                        // Sorguyu çalıştır ve sonucu kontrol et
                        int result = (int)command.ExecuteScalar();

                        if (result > 0)
                        {
                            MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Başarılı giriş sonrası yapılacak işlemler (örn. yeni forma yönlendirme)
                            // Form yeniForm = new AnaSayfa();
                            // yeniForm.Show();
                            // this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
