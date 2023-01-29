using System;
using MobileBank.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobileBank.Forms
{
    public partial class UserForm : Form
    {
        DataBaseConnection database = new DataBaseConnection();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();

        public UserForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void RefreshData()
        {
            var queryPIB = $"select concat(client_last_name, ' ' ,client_first_name, ' ' ,client_middle_name), client_phone_number, client_email from client where id_client = '{DataStorage.idClient}'";
            SqlCommand commandPIB = new SqlCommand(queryPIB, database.getConnection());
            database.openConnection();
            SqlDataReader reader = commandPIB.ExecuteReader();
            while (reader.Read())
            {
                labelPIB.Text += reader[0].ToString();
                labelPhone.Text += reader[1].ToString();
                labelEmail.Text += reader[2].ToString();
            }
            reader.Close();
        }

        private void ClearFields()
        {
            labelPIB.Text = string.Empty;
            labelPhone.Text = string.Empty;
            labelEmail.Text = string.Empty;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();
        }

        private void changePhoneBtn_Click(object sender, EventArgs e)
        {
            СhangePhoneNumber changePhoneNumber = new СhangePhoneNumber();
            changePhoneNumber.Show();
        }

        private void changeEmailBtn_Click(object sender, EventArgs e)
        {
            СhangeEmail changeEmail = new СhangeEmail();
            changeEmail.Show();
        }

        private void ChangePasswrodBtn_Click(object sender, EventArgs e)
        {
            СhangePassword changePassword = new СhangePassword();
            changePassword.Show();
        }
    }
}