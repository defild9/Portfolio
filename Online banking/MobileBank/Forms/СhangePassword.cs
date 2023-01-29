using System;
using MobileBank.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MobileBank.Forms
{
    public partial class СhangePassword : Form
    {
        DataBaseConnection dataBase = new DataBaseConnection();

        public СhangePassword()
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

        private void changePassBtn_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата збереження";

            if (!Regex.IsMatch(PasswordTextBox.Text, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
            {
                MessageBox.Show("Будь ласка, введіть пароль.", caption, btn, ico);
                PasswordTextBox.Select();
                return;
            }

            var pass = PasswordTextBox.Text;
            var changeNumQuery = $"update client set client_password = '{pass}' where id_client = (select id_client from client where id_client = '{DataStorage.idClient}')";
            dataBase.openConnection();
            var command = new SqlCommand(changeNumQuery, dataBase.getConnection());
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Пароль успішно змінений!");
                Close();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }
            dataBase.closeConnection();
        }

        private void СhangePassword_MouseDown(object sender, MouseEventArgs e)
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