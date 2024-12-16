using System;
using System.Windows.Forms;

namespace WindowsFormsApp_Yurt
{
    public partial class studentMainPage : Form
    {
        // Öğrenci bilgileri
        private int studentId;
        private string studentName;
        private string studentSurname;
        private string studentIdNumber;

        public studentMainPage(int id, string name, string surname, string idNumber)
        {
            InitializeComponent();

            // Öğrenci bilgilerini al
            studentId = id;
            studentName = name;
            studentSurname = surname;
            studentIdNumber = idNumber;

            // Öğrenci bilgilerini ekranda göster
            labelStudentName.Text = $"Ad: {studentName} {studentSurname}";
            labelStudentId.Text = $"TC: {studentIdNumber}";
        }

        private void studentMainPage_Load(object sender, EventArgs e)
        {
            // Burada, giriş yapan öğrenciye ait başka verilerle işlem yapılabilir.
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
