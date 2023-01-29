using System;
using System.Data;
using MobileBank.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MobileBank.Forms
{
    public partial class ArmyHelp : Form
    {
        DataBaseConnection database = new DataBaseConnection(); 
        Random rand = new Random(); 
        DataTable operators = new DataTable(); 
        Validation validation = new Validation(); 

        public ArmyHelp()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1; 
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")] 

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam); 

        [System.Runtime.InteropServices.DllImport("user32.dll")] 

        public static extern bool ReleaseCapture(); 

        private void ArmyHelp_Load(object sender, EventArgs e)
        {
            
            TextBoxCard.Text = DataStorage.cardNumber; 

            var queryChooseOperator = $"select id_service, serviceName from clientServices where serviceType = 'charity'"; 
            SqlDataAdapter commandChooseOperaot = new SqlDataAdapter(queryChooseOperator, database.getConnection()); 
            database.openConnection();
            commandChooseOperaot.Fill(operators); 
            comboBoxArmyHelp.DataSource = operators; 
            comboBoxArmyHelp.ValueMember = "id_service"; 
            comboBoxArmyHelp.DisplayMember = "serviceName"; 
            database.closeConnection();
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;

            string caption = "Дата збереження";
            double sum = Convert.ToDouble(textBoxSum.Text);
            var cardNumber = TextBoxCard.Text;
            var cardCVV = TextBoxCvv.Text;
            var cardDate = TextBoxCardTo.Text;
            var cardCVVCheck = "";
            var cardDateCheck = "";
            double cardBalanceCheck = 0;
            bool error = false;
            string cardCurrency = "";

           

            var queryCheckCard = $"select bank_card_cvv_code, CONCAT(FORMAT(bank_card_date, '%M'), '/', FORMAT(bank_card_date, '%y')), bank_card_balance, bank_card_currency from bank_card where bank_card_number = '{cardNumber}'"; // Створюємо запит на вибірку даних із таблиці
            SqlCommand commandCheckCard = new SqlCommand(queryCheckCard, database.getConnection()); /
            database.openConnection();
            SqlDataReader reader = commandCheckCard.ExecuteReader(); 
            while (reader.Read()) { 
                cardCVVCheck = reader[0].ToString();
                cardDateCheck = reader[1].ToString();
                cardBalanceCheck = Convert.ToDouble(reader[2].ToString());
                cardCurrency = reader[3].ToString();
            }
            reader.Close();

            if (cardCurrency != "UAH") { 
                MessageBox.Show("Оплата комунальних послуг може відбуватись лише в гривнях", "Відміна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }

            if (cardCVV != cardCVVCheck) { 
                MessageBox.Show("Помилка. Некоректно введено CVV-код", "Відміна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }

            if (cardDate != cardDateCheck) { 
                MessageBox.Show("Помилка. Некоректно введено дату карти", "Відміна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }

            if (sum > cardBalanceCheck) { 
                MessageBox.Show("Помилка. Недостатньо коштів для здійснення операції.", "Відміна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }

            if (error == false) { 
                DataStorage.bankCard = TextBoxCard.Text; 
                validation.ShowDialog(); 

                if (DataStorage.attempts > 0) { 
                    DateTime transactionDate = DateTime.Now; 
                    var transactionNumber = "P"; 

                    for (int i = 0; i < 10; i++) {
                        transactionNumber += Convert.ToString(rand.Next(0, 10)); 
                    }

                    // Запит на оновлення балансу поточної картки
                    var queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                    // Запит на вставку в таблицю даних про транзацію
                    var queryTransaction2 = $"insert into transactions(transaction_type, transaction_destination, transaction_date, transaction_number, transaction_value, id_bank_card) values('Допомога армії', '{comboBoxArmyHelp.GetItemText(comboBoxArmyHelp.SelectedItem)}', '{transactionDate}', '{transactionNumber}', '{sum}', (select id_bank_card from bank_card where bank_card_number = '{cardNumber}'))";
                    // Запит на оновлення рахунку сервісу
                    var queryTransaction3 = $"update clientServices set serviceBalance = serviceBalance + '{sum}' where serviceName = '{comboBoxArmyHelp.GetItemText(comboBoxArmyHelp.SelectedItem)}' and serviceType = 'charity'";

                    

                    
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

        private void ArmyHelp_MouseDown(object sender, MouseEventArgs e) 
        {
            if (e.Button == MouseButtons.Left) {
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