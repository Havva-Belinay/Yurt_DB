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
    public partial class mainpage : Form
    {
        public mainpage( string FullName , int isAdmin)
        {
            InitializeComponent();
            name.Text = "Hosgeldiniz " + FullName;

            // Admin olmayan kullanıcı için buton devre dışı bırakır.
            if (isAdmin == 0)
            {
                WMButton.Enabled = false;
                WMButton.BackColor = Color.LightGray;
            }
            else
            {
                WMButton.Enabled = true;
                WMButton.BackColor = SystemColors.Control;
            }

            //            string connectionString = "Server=LAPTOP-VCIVPG77\\VTYS;Database=Yurt_DB;Trusted_Connection=True;";
            //string workerQuery = "SELECT * FROM Worker";
            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            //SqlCommand command = new SqlCommand(workerQuery, connection);
            //using (SqlDataReader reader = command.ExecuteReader())
            //{
            //while (reader.Read())  // Satır satır veri okuma
            // {
            //string fullName = reader["FullName"].ToString();
            //           string idNumber = reader["IdNumber"].ToString();
            //
            // ListBox'a ekleme
            //listBox1.Items.Add($"Adı: {fullName}, TC: {idNumber}");
        }

        public mainpage()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void WMButton_Click(object sender, EventArgs e)
        {
            // Yeni formu oluştur
            WorkerManagementPage workerManagementPage = new WorkerManagementPage();

            // Yeni formu göster
            workerManagementPage.Show();

            // Bu formu gizle
            this.Hide();
        }

        private void SMButton_Click(object sender, EventArgs e)
        {
            // Yeni formu oluştur
           StudentManagementPage studentManagementPage = new StudentManagementPage();

            // Yeni formu göster
            studentManagementPage.Show();

            // Bu formu gizle
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
