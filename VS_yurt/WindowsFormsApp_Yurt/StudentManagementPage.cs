using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp_Yurt
{
    public partial class StudentManagementPage : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public StudentManagementPage()
        {
            InitializeComponent();
        }
        void StudentTable() // Tekrar yazmamak için burada fonsiyon yazdık. Ve aşağıda ihtiyaç oldukça bu fonsiyonu çağırıyoruz.
        {
            baglanti = new SqlConnection("Data Source=LAPTOP-VCIVPG77\\VTYS;Initial Catalog=Yurt_DB;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM StudentTable", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();


        }
        private void StudentManagementPage_Load(object sender, EventArgs e)
        {
            StudentTable(); // Yukarıda tanımladığımız fonsiyon çağrılır.

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Mevcut formu kapat
            this.Close();
            mainpage back = new mainpage();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            dateTimePicker1.Value = dataGridView1.CurrentRow.Cells[11].Value != null ? Convert.ToDateTime(dataGridView1.CurrentRow.Cells[11].Value) : DateTime.Now;
            textBox12.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            textBox15.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            textBox16.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            textBox17.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            textBox18.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            textBox19.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            textBox20.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            // İlk sorgu: Ad ile arama
            using (SqlCommand command = new SqlCommand("sp_SearchByName", baglanti))
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
            using (SqlCommand command = new SqlCommand("sp_SearchByFullName", baglanti))
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
            using (SqlCommand command = new SqlCommand("sp_SearchByPartialName", baglanti))
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
    }
    }
}
