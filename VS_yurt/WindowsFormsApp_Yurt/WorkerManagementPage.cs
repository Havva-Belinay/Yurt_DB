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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp_Yurt
{
    public partial class WorkerManagementPage : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da ;
        
        public WorkerManagementPage()
        {
            InitializeComponent();
        }

        void Worker() // Tekrar yazmamak için burada fonsiyon yazdık. Ve aşağıda ihtiyaç oldukça bu fonsiyonu çağırıyoruz.
        {
            baglanti = new SqlConnection("Data Source=LAPTOP-VCIVPG77\\VTYS;Initial Catalog=Yurt_DB;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM Worker", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            

        }

        private void WorkerManagementPage_Load(object sender, EventArgs e)
        {
            Worker(); // Yukarıda tanımladığımız fonsiyon çağrılır.

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }               
    
       
        private void ekle_Click(object sender, EventArgs e) // EKLE
        {
            string sorgu = "INSERT INTO Worker (FullName ,JobTitle ,PhoneNumber ,DormId ,IdNumber ,WorkerPassword ,IsAdmin ) VALUES (@FullName ,@JobTitle ,@PhoneNumber ,@DormId ,@IdNumber ,@WorkerPassword ,@IsAdmin )";
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@WorkerID", textBox7.Text);
            komut.Parameters.AddWithValue("@FullName", textBox1.Text);
            komut.Parameters.AddWithValue("@JobTitle", textBox2.Text);
            komut.Parameters.AddWithValue("@PhoneNumber", textBox3.Text);
            komut.Parameters.AddWithValue("@DormId", textBox6.Text);
            komut.Parameters.AddWithValue("@IdNumber", textBox4.Text);
            komut.Parameters.AddWithValue("@WorkerPassword", textBox5.Text);
            komut.Parameters.AddWithValue("@IsAdmin", checkBox1.Checked); // IsAdmin için CheckBox kullanılıyor
            baglanti.Open();
            
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt başarıyla eklendi!");
            baglanti.Close();
            Worker();

        }
        

        private void button1_Click(object sender, EventArgs e) //DELETE
        {
            string sorgu = "DELETE FROM Worker WHERE FullName = @FullName";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@FullName",(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt başarıyla silindi!");
            baglanti.Close();
            Worker();
        }

        private void button2_Click(object sender, EventArgs e) //GÜNCELLE
        {
            string sorgu = "UPDATE Worker SET FullName=@FullName ,JobTitle=@JobTitle,PhoneNumber=@PhoneNumber ,DormId=@DormId ,IdNumber=@IdNumber ,WorkerPassword=@WorkerPassword ,IsAdmin=@IsAdmin WHERE WorkerID=@WorkerID";
            komut = new SqlCommand(sorgu, baglanti);
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@WorkerID", Convert.ToInt32(textBox7.Text));
            komut.Parameters.AddWithValue("@FullName", textBox1.Text);
            komut.Parameters.AddWithValue("@JobTitle", textBox2.Text);
            komut.Parameters.AddWithValue("@PhoneNumber", textBox3.Text);
            komut.Parameters.AddWithValue("@DormId", textBox6.Text);
            komut.Parameters.AddWithValue("@IdNumber", textBox4.Text);
            komut.Parameters.AddWithValue("@WorkerPassword", textBox5.Text);
            komut.Parameters.AddWithValue("@IsAdmin", checkBox1.Checked); // IsAdmin için CheckBox kullanılıyor

            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar başarıyla güncellendi!");
            baglanti.Close();
            Worker();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            // CheckBox IsAdmin değeri için
            if (dataGridView1.CurrentRow.Cells[7].Value != null)
            {
                checkBox1.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value); // IsAdmin
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();

            // İlk sorgu: Ad ile arama
            using (SqlCommand command = new SqlCommand("sp_SearchWorkerByName", baglanti))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Ad", textBox8.Text.Trim());

                // DataGridView temizle
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);

                // Sonuçları DataGridView'e yükle
                dataGridView1.DataSource = table;
                reader.Close(); // Reader'ı kapatıyoruz, ikinci sorgu çalışacak
            }

            // İkinci sorgu: Ad ve Soyad ile arama
            using (SqlCommand command = new SqlCommand("sp_SearchWorkerByFullName", baglanti))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Ad", textBox8.Text.Trim());
                command.Parameters.AddWithValue("@Soyad", textBox8.Text.Trim()); // Soyad farklı TextBox'tan alınmalı

                // DataGridView temizle
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);

                // Sonuçları DataGridView'e yükle
                dataGridView1.DataSource = table;
                reader.Close(); // Reader'ı kapatıyoruz, üçüncü sorgu çalışacak
            }

            // Üçüncü sorgu: İsim parçası ile arama
            using (SqlCommand command = new SqlCommand("sp_SearchWorkerByPartialName", baglanti))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NamePart", textBox8.Text.Trim());

                // DataGridView temizle
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);

                // Sonuçları DataGridView'e yükle
                dataGridView1.DataSource = table;
                reader.Close(); // Reader'ı kapatıyoruz
            }

            // Bağlantıyı kapat
            baglanti.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();

            // Tüm verileri tekrar getirmek için SQL sorgusu çalıştırıyoruz
            using (SqlCommand command = new SqlCommand("SELECTFullName ,JobTitle ,PhoneNumber ,DormId ,IdNumber ,WorkerPassword ,IsAdmin FROM Worker", baglanti))
            {
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);

                // Sonuçları DataGridView'e yükle
                dataGridView1.DataSource = table;
                reader.Close(); // Reader'ı kapatıyoruz
            }

            // Bağlantıyı kapatıyoruz
            baglanti.Close();
        }
    }
}
    