using System;
using MobileBank.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobileBank.Forms
{
    public partial class Validation : Form
    {
        DataBaseConnection database = new DataBaseConnection();
        public Validation()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            int attempts = 3;
            int cardPin = Convert.ToInt32(numericUpDownPin.Value);
            int pin = 0;

            var queryCheckPin = $"select bank_card_pin from bank_card where bank_card_number = '{DataStorage.bankCard}'";
            SqlCommand command = new SqlCommand(queryCheckPin, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                pin = Convert.ToInt32(reader[0]);
            reader.Close();

            if (cardPin == pin) {
                MessageBox.Show("Операцію підтверджено", "ОК", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                DataStorage.attempts = attempts;
            }
            else {
                MessageBox.Show("Помилка. Невірний PIN", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (attempts > 0)
                    attempts--;
                else {
                    DataStorage.attempts = attempts;
                    MessageBox.Show("У Вас закінчилися спроби", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }
    }
}
