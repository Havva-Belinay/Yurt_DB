using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Yurt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Veritabanı bağlantı dizgesi
            string connectionString = "Server=LAPTOP-VCIVPG77\\VTYS;Database=Yurt_DB;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Bağlantıyı açmayı deniyoruz
                    connection.Open();
                    Console.WriteLine("Bağlantı başarılı!");
                    // Veritabanındaki tabloları listeleyen sorgu
                    string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    Console.WriteLine("Tablolar:");
                    while (reader.Read())
                    {
                        Console.WriteLine("- " + reader["TABLE_NAME"]);
                    }

                    reader.Close();
                }
            
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj yazdırılır
                Console.WriteLine("Bağlantı hatası: " + ex.Message);
            }
        }
    }
}
