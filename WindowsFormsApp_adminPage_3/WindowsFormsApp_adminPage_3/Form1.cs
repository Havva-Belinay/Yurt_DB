using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YedeklemeApp
{
    public partial class Form1 : Form
    {
        // SQL Server bağlantı dizesi
        private string connectionString = @"Data Source=HATICENUR\hatic;Initial Catalog=Yurt;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        // Yedekleme butonuna tıklanıldığında çalışacak fonksiyon
        private void buttonBackup_Click(object sender, EventArgs e)
        {
            // Yedekleme dosyasının adını ve yolunu oluştur
            string backupFilePath = @"C:\Backup\" + "Backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";

            // Yedekleme dosyasının yolunu textbox'a yaz
            textBoxBackupFile.Text = backupFilePath;

            // SQL yedekleme sorgusu
            string backupQuery = $"BACKUP DATABASE Yurt TO DISK = '{backupFilePath}'";

            try
            {
                // SQL bağlantısını aç
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(backupQuery, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Yedekleme başarılı! Dosya yolu: {backupFilePath}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı göster
                MessageBox.Show($"Yedekleme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Geri yükleme butonuna tıklanıldığında çalışacak fonksiyon
        private void buttonRestore_Click(object sender, EventArgs e)
        {
            // Yedekleme dosyasını seçmek için OpenFileDialog
            openFileDialog.Filter = "Yedekleme Dosyaları (*.bak)|*.bak";
            openFileDialog.InitialDirectory = @"C:\Backup\";  // Başlangıç klasörü
            openFileDialog.FileName = "Backup_";  // Dosya adı

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string restoreFilePath = openFileDialog.FileName;

                // Seçilen dosya yolunu textBox'a yaz
                textBoxBackupFile.Text = restoreFilePath;

                string restoreQuery = $"RESTORE DATABASE Yurt FROM DISK = '{restoreFilePath}'";

                try
                {
                    // SQL bağlantısını aç
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(restoreQuery, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Veritabanı başarıyla geri yüklendi! Dosya yolu: {restoreFilePath}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Hata mesajı göster
                    MessageBox.Show($"Veritabanı geri yükleme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Dosya seçilmediğinde bilgi mesajı
                MessageBox.Show("Geri yüklemek için bir dosya seçmediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
