using System;
using MobileBank.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MobileBank.Forms
{
    public partial class СhangeEmail : Form
    {

        DataBaseConnection dataBase = new DataBaseConnection();

        public СhangeEmail()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();

        private void changeEmailBtn_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата збереження";

            if (!Regex.IsMatch(EmailTextBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Будь ласка, введіть вашу пошту", caption, btn, ico);
                EmailTextBox.Select();
                return;
            }

            var email = EmailTextBox.Text;
            var changeNumQuery = $"update client set client_email = '{email}' where id_client = '{DataStorage.idClient}'";
            dataBase.openConnection();
            var command = new SqlCommand(changeNumQuery, dataBase.getConnection());
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Електрона пошта успішно змінена!");
                Close();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }
            dataBase.closeConnection();
        }

        private void СhangeEmail_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}