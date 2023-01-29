using System;
using System.Data;
using System.Linq;
using MobileBank.Classes;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace MobileBank.Forms
{
    public partial class RegistrationForm : Form
    {
        DataBaseConnection database = new DataBaseConnection();

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            LastNameTextBox.Select();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;

            string caption = "Дата збереження";

            if (!Regex.IsMatch(LastNameTextBox.Text, "[А-Яа-я]+$"))
            {
                MessageBox.Show("Будь ласка, введіть прізвище повторно!", caption, btn, ico);
                LastNameTextBox.Select();
                return;
            }

            if (!Regex.IsMatch(FirstNameTextBox.Text, "[А-Яа-я]+$"))
            {
                MessageBox.Show("Будь ласка, введіть ім'я повторно!", caption, btn, ico);
                FirstNameTextBox.Select();
                return;
            }

            if (!Regex.IsMatch(MiddleNameTextBox.Text, "[А-Яа-я]+$"))
            {
                MessageBox.Show("Будь ласка, введіть по батькові повторно!", caption, btn, ico);
                MiddleNameTextBox.Select();
                return;
            }

            if (string.IsNullOrEmpty(GenderComboBox.SelectedItem.ToString()))
            {
                MessageBox.Show("Будь ласка, оберіть стать", caption, btn, ico);
                GenderComboBox.Select();
                return;
            }

            if (!Regex.IsMatch(PasswordTextBox.Text, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
            {
                MessageBox.Show("Будь ласка, введіть пароль.", caption, btn, ico);
                PasswordTextBox.Select();
                return;
            }

            if (!Regex.IsMatch(ConfirmPasswordTextBox.Text, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
            {
                MessageBox.Show("Будь ласка, введіть підтвердження пароля.", caption, btn, ico);
                ConfirmPasswordTextBox.Select();
                return;
            }

            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                MessageBox.Show("Ваш пароль і пароль підтвердження не збігаються.", caption, btn, ico);
                ConfirmPasswordTextBox.SelectAll();
                return;
            }

            if (!Regex.IsMatch(EmailTextBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Будь ласка, введіть вашу пошту", caption, btn, ico);
                EmailTextBox.Select();
                return;
            }

            if (!Regex.IsMatch(PhoneNumberTextBox.Text, "^[+][3][8][0][0-9]{7,14}$"))
            {
                MessageBox.Show("Будь ласка, введіть ваш номер телефону", caption, btn, ico);
                PhoneNumberTextBox.Select();
                return;
            }

            string yourSQL = "SELECT client_phone_number FROM client WHERE client_phone_number = '" + PhoneNumberTextBox.Text + "'";
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand(yourSQL, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Номер телефону вже існує. Неможливо зареєструвати акаунт", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PhoneNumberTextBox.SelectAll();
                return;
            }

            DialogResult result;
            result = MessageBox.Show("Ви хочете зберегти запис?", "Збереження даних", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string mySQL = string.Empty;

                mySQL += "INSERT INTO client (client_last_name, client_first_name, client_middle_name, client_gender, client_password, client_email, client_phone_number) ";
                mySQL += "VALUES ('" + LastNameTextBox.Text + "','" + FirstNameTextBox.Text + "','" + MiddleNameTextBox.Text + "',";
                mySQL += "'" + GenderComboBox.SelectedItem.ToString() + "','" + PasswordTextBox.Text + "','" + EmailTextBox.Text + "','" + PhoneNumberTextBox.Text + "')";

                database.openConnection();
                SqlCommand commandAddNewUser = new SqlCommand(mySQL, database.getConnection());
                commandAddNewUser.ExecuteNonQuery();

                MessageBox.Show("Запис успішно збережено.", "Дані збережено", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearControls();
                database.closeConnection();
                Close();
            }
        }

        private void clearControls()
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = string.Empty;
            }

            foreach (ComboBox comboBox in Controls.OfType<ComboBox>())
            {
                comboBox.SelectedItem = null;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            LastNameTextBox.Select();
            clearControls();
        }

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordCheckBox.Checked == true)
            {
                PasswordTextBox.UseSystemPasswordChar = false;
                ConfirmPasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTextBox.UseSystemPasswordChar = true;
                ConfirmPasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}