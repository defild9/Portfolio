using System;
using MobileBank.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MobileBank.Forms
{
    public partial class СhangePhoneNumber : Form
    {
        DataBaseConnection dataBase = new DataBaseConnection();

        public СhangePhoneNumber()
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

        private void changePhoneBtn_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата збереження";

            if (!Regex.IsMatch(NumberTextBox.Text, "^[+][3][8][0][0-9]{7,14}$"))
            {
                MessageBox.Show("Будь ласка, введіть ваш номер телефону", caption, btn, ico);
                NumberTextBox.Select();
                return;
            }

            var phonenumber = NumberTextBox.Text;
            var changeNumQuery = $"update client set client_phone_number = '{phonenumber}' where id_client = '{DataStorage.idClient}'";
            var command = new SqlCommand(changeNumQuery, dataBase.getConnection());
            dataBase.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Номер телефона успішно змінено!");
                Close();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }
            dataBase.closeConnection();
        }

        private void СhangePhoneNumber_MouseDown(object sender, MouseEventArgs e)
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