using System;
using System.Data;
using MobileBank.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MobileBank.Forms
{
    public partial class PhoneForm : Form
    {
        DataBaseConnection database = new DataBaseConnection();
        Random rand = new Random();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public PhoneForm()
        {
            InitializeComponent();

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxSum_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSum.Text == string.Empty)
            {
                textBoxSum.Text = null;
                labelCommission.Text = "0";
                labelTotalSum.Text = "0";
            }
            else
            {
                double sum = Convert.ToDouble(textBoxSum.Text);
                labelCommission.Text = Convert.ToString((sum * 2) / 100);
                labelTotalSum.Text = Convert.ToString(((sum * 2) / 100) + sum);
            }
        }

        private void buttonSendToPhone_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата збереження";

            string tmp = textBoxNumber.Text;
            string phoneNumberToCheck = String.Concat(tmp[0], tmp[1]);

            string selectedOperator = comboBoxOperator.GetItemText(comboBoxOperator.SelectedItem);

            bool numberCheck = false;

            if (selectedOperator == "Kyivstar")
            {
                if (phoneNumberToCheck != "68" && phoneNumberToCheck != "96" && phoneNumberToCheck != "97" && phoneNumberToCheck != "98") {
                    MessageBox.Show("Будь ласка, введіть коректний номер телефону", caption, btn, ico);
                    numberCheck = true;
                }
            }
            else if (selectedOperator == "lifecell")
            {
                if (phoneNumberToCheck != "93" && phoneNumberToCheck != "73" && phoneNumberToCheck != "63") {
                    MessageBox.Show("Будь ласка, введіть коректний номер телефону", caption, btn, ico);
                    numberCheck = true;
                }
            }
            else if (selectedOperator == "Vodafone Ukraine") 
            {
                if (phoneNumberToCheck != "99" && phoneNumberToCheck != "95" && phoneNumberToCheck != "66" && phoneNumberToCheck != "50") {
                    MessageBox.Show("Будь ласка, введіть коректний номер телефону", caption, btn, ico);
                    numberCheck = true;
                }
            }

            if (numberCheck == false) {
                var phoneNumber = textBoxNumber.Text;
                double sum = Convert.ToDouble(textBoxSum.Text);
                var cardNumber = TextBoxCard.Text;
                var cardCVV = TextBoxCvv.Text;
                var cardDate = TextBoxCardTo.Text;
                var cardCVVCheck = "";
                var cardDateCheck = "";
                double cardBalanceCheck = 0;
                bool error = false;
                string cardCurrency = "";

                double commission = ((Convert.ToDouble(sum) * 2) / 100);
                double totalSum = commission + Convert.ToDouble(sum);

                if (!Regex.IsMatch(textBoxNumber.Text, "^[0-9]{9}$"))
                {
                    MessageBox.Show("Будь ласка, введіть ваш номер телефону", caption, btn, ico);
                    textBoxNumber.Select();
                    return;
                }

                var queryCheckCard = $"select bank_card_cvv_code, CONCAT(FORMAT(bank_card_date, '%M'), '/', FORMAT(bank_card_date, '%y')), bank_card_balance, bank_card_currency from bank_card where bank_card_number = '{cardNumber}'";
                SqlCommand commandCheckCard = new SqlCommand(queryCheckCard, database.getConnection());
                database.openConnection();
                SqlDataReader reader = commandCheckCard.ExecuteReader();

                while (reader.Read())
                {
                    cardCVVCheck = reader[0].ToString();
                    cardDateCheck = reader[1].ToString();
                    cardBalanceCheck = Convert.ToDouble(reader[2].ToString());
                    cardCurrency = reader[3].ToString();
                }
                reader.Close();

                if (cardCurrency != "UAH") {
                    MessageBox.Show("Поповнення мобільного може відбуватись лише в гривнях", "Відміна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true;
                }

                if (cardCVV != cardCVVCheck)
                {
                    MessageBox.Show("Помилка. Некоректно введено CVV-код", "Відміна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true;
                }

                if (cardDate != cardDateCheck)
                {
                    MessageBox.Show("Помилка. Некоректно введено дату карти", "Відміна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true;
                }

                if (Convert.ToDouble(sum) < 5.00)
                {
                    MessageBox.Show("Помилка. Мінімальна сума поповнення 5.00 UAH", "Відміна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true;
                }

                if (sum > cardBalanceCheck)
                {
                    MessageBox.Show("Помилка. Недостатньо коштів для здійснення операції.", "Відміна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true;
                }

                if (error == false)
                {
                    DataStorage.bankCard = TextBoxCard.Text;
                    Validation validation = new Validation();
                    validation.ShowDialog();

                    if (DataStorage.attempts > 0)
                    {
                        DateTime transactionDate = DateTime.Now;
                        var transactionNumber = "P";

                        for (int i = 0; i < 10; i++)
                        {
                            transactionNumber += Convert.ToString(rand.Next(0, 10));
                        }

                        var queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{totalSum}' where bank_card_number = '{cardNumber}'";
                        var queryTransaction2 = $"insert into transactions(transaction_type, transaction_destination, transaction_date, transaction_number, transaction_value, id_bank_card) values('Поповнення мобільного', '+380{textBoxNumber.Text}', '{transactionDate}', '{transactionNumber}', '{totalSum}', (select id_bank_card from bank_card where bank_card_number = '{cardNumber}'))";
                        var queryTransaction3 = $"update clientServices set serviceBalance = serviceBalance + '{sum}' where serviceName = '{comboBoxOperator.GetItemText(comboBoxOperator.SelectedItem)}' and serviceType = 'Mobile'";

                        var command1 = new SqlCommand(queryTransaction1, database.getConnection());
                        var command2 = new SqlCommand(queryTransaction2, database.getConnection());
                        var command3 = new SqlCommand(queryTransaction3, database.getConnection());

                        database.openConnection();

                        command1.ExecuteNonQuery();
                        command2.ExecuteNonQuery();
                        command3.ExecuteNonQuery();

                        database.closeConnection();

                        Close();
                    }
                }
            }
        }

        private void PhoneForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PhoneForm_Load(object sender, EventArgs e)
        {
            textBoxNumber.Text = DataStorage.phoneNumber;
            TextBoxCard.Text = DataStorage.cardNumber;

            var queryChooseOperator = $"select id_service, serviceName from clientServices where serviceType = 'Mobile'";
            SqlDataAdapter commandChooseOperaot = new SqlDataAdapter(queryChooseOperator, database.getConnection());
            database.openConnection();
            DataTable operators = new DataTable();
            commandChooseOperaot.Fill(operators);
            comboBoxOperator.DataSource = operators;
            comboBoxOperator.ValueMember = "id_service";
            comboBoxOperator.DisplayMember = "serviceName";
            database.closeConnection();
        }
    }
}