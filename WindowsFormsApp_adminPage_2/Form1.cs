using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp_adminPage_2
{
    public partial class Form1 : Form
    {
        // Bağlantı dizesi (örnek)
        private string connectionString = "Server=HATICENUR;Database=yurt;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            // SQL sorgusunu yazalım
            string query = "SELECT * FROM Worker"; // Veritabanınızdaki tablo adıyla değiştirin

            // SqlConnection ve SqlDataAdapter ile veri çekelim
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // DataGridView'e veri aktaralım
                dataGridView1.DataSource = dataTable;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            // Excel uygulamasını başlat
            var excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Yeni bir çalışma kitabı oluştur
            Excel.Workbook workBook = excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Sheets[1];

            // DataGridView başlıklarını aktar
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                workSheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }

            // DataGridView verilerini aktar
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    // Null değerler kontrol ediliyor
                    workSheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Çalışma kitabını kaydetmeden sadece göster
            // workBook.SaveAs("C:\\path\\to\\your\\file.xlsx"); // Dosyayı kaydetmek isterseniz
        }
    }
}
