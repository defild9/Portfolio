using System;
using System.Data;
using MobileBank.Classes;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MobileBank.Forms
{
    public partial class Credit : Form
    {
        DataBaseConnection database = new DataBaseConnection(); 
        Random rand = new Random(); 
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        Validation validation = new Validation();

        public Credit()
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

        private void Credit_Load(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            textBox2.Text = trackBar2.Value.ToString();
            panel3.Visible = false;
            buttonPay.Visible = false;

            var totalSum = "";
            var sum = "";
            DateTime date = new DateTime();
            var idCredit = "";

            double creditTotalSumToCheck = 0;
            double creditSumToCheck = 0;

            var querycheckCreditStatus = $"select credit_total_sum, credit_sum from credits where id_bank_card = (select id_bank_card from bank_card where bank_card_number = '{DataStorage.cardNumber}')";
            SqlCommand commandCheckCreditStatus = new SqlCommand(querycheckCreditStatus, database.getConnection());
            database.openConnection();
            SqlDataReader reader3 = commandCheckCreditStatus.ExecuteReader();
            while (reader3.Read()) {
                creditTotalSumToCheck = Convert.ToDouble(reader3[0]);
                creditSumToCheck = Convert.ToDouble(reader3[1]);
            }
            reader3.Close();

            if (creditSumToCheck >= creditTotalSumToCheck) {
                var queryDeleteCredit = $"delete from credits where id_bank_card = (select id_bank_card from bank_card where bank_card_number = '{DataStorage.cardNumber}')";
                SqlCommand commandDeleteCredit = new SqlCommand(queryDeleteCredit, database.getConnection());
                commandDeleteCredit.ExecuteNonQuery();
            }

            var querySelectIdCard = $"select credits.id_bank_card, credits.credit_total_sum, credits.credit_sum, credits.credit_date, credits.id_credit from credits inner join bank_card on credits.id_bank_card = bank_card.id_bank_card where bank_card.bank_card_number = '{DataStorage.cardNumber}'";
            SqlCommand commandSelectCredit = new SqlCommand(querySelectIdCard, database.getConnection());
            SqlDataReader reader = commandSelectCredit.ExecuteReader();
            while (reader.Read()) {
                totalSum = reader[1].ToString();
                sum = reader[2].ToString();
                date = Convert.ToDateTime(reader[3].ToString());
                idCredit = reader[4].ToString();
            }
            reader.Close();

            SqlCommand commandSelectIdCard = new SqlCommand(querySelectIdCard, database.getConnection());
            adapter.SelectCommand = commandSelectIdCard;
            adapter.Fill(table);
            if (table.Rows.Count > 0) {
                panel3.Visible = true;
                buttonPay.Visible = true;
                
                labelSum.Text = Math.Round(Convert.ToDouble(sum), 2).ToString();
                labelTotalSum.Text = Math.Round(Convert.ToDouble(totalSum), 2).ToString();
                labelDate.Text = date.ToShortDateString();

                double toPaySum = 0;
                DateTime dateRepay = new DateTime();

                var querySelectRepayment = $"select repayment_date, repayment_sum from credits where id_credit = '{idCredit}'";
                SqlCommand commandSelectRepayment = new SqlCommand(querySelectRepayment, database.getConnection());
                SqlDataReader reader1 = commandSelectRepayment.ExecuteReader();
                while (reader1.Read())
                {
                    dateRepay = Convert.ToDateTime(reader1[0].ToString());
                    toPaySum = Convert.ToDouble(reader1[1].ToString());
                }
                reader1.Close();
                database.closeConnection();

                labelToPay.Text = Math.Round(toPaySum, 2).ToString();
                labelDateToPay.Text = dateRepay.ToShortDateString();
            }
        }

        private void calculateCredit()
        {
            double monthlyRate = 0.01;
            double sum = Convert.ToDouble(textBox1.Text);
            int numberOfMonths = Convert.ToInt32(textBox2.Text);
            double result = sum * (monthlyRate + (monthlyRate / (Math.Pow(1 + monthlyRate, numberOfMonths) - 1)));
            monthlyPaymentLabel.Text = Math.Round(result, 2).ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(textBox1.Text);
            calculateCredit();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            trackBar2.Value = Convert.ToInt32(textBox2.Text);
            calculateCredit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(textBox1.Text);
            trackBar2.Value = Convert.ToInt32(textBox2.Text);
            calculateCredit();

            DataStorage.bankCard = DataStorage.cardNumber;
            validation.ShowDialog();

            if (DataStorage.attempts > 0) {
                var totalSum = Convert.ToDouble(monthlyPaymentLabel.Text) * Convert.ToDouble(textBox2.Text);
                DateTime creditDate = DateTime.Now;
                var repaymentDate = creditDate.AddMonths(1);
                var payment = monthlyPaymentLabel.Text;

                database.openConnection();
                var queryCredit = $"insert into credits(credit_total_sum, credit_sum, credit_date, id_bank_card) values ('{totalSum}', 0, '{creditDate}', (select id_bank_card from bank_card where bank_card_number = '{DataStorage.cardNumber}'))";
                var command1 = new SqlCommand(queryCredit, database.getConnection());
                command1.ExecuteNonQuery();

                var idCredit = "";
                var querySelectId = $"select id_credit from credits where id_bank_card = (select id_bank_card from bank_card where bank_card_number = '{DataStorage.cardNumber}')";
                SqlCommand command3 = new SqlCommand(querySelectId, database.getConnection());
                SqlDataReader reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    idCredit = reader[0].ToString();
                }
                reader.Close();

                var sum1 = textBox1.Text;
                var queryRepayment = $"update credits set repayment_date = '{repaymentDate}', repayment_sum =  '{payment}' where id_credit = '{idCredit}'";
                var queryCardUpdate = $"update bank_card set bank_card_balance = bank_card_balance + '{sum1}' where bank_card_number = '{DataStorage.cardNumber}'";

                var command4 = new SqlCommand(queryCardUpdate, database.getConnection());
                var command2 = new SqlCommand(queryRepayment, database.getConnection());

                command4.ExecuteNonQuery();
                command2.ExecuteNonQuery();

                MessageBox.Show("Кредит оформлено!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);


                DateTime toPayDate = new DateTime();
                DateTime creditTakeDate = new DateTime();
                double creditSum = 0;
                double creditTotalSum = 0;
                double creditToPaySum = 0;

                var querySelectRepayment = $"select credit_date, credit_sum, credit_total_sum, repayment_date, repayment_sum from credits where id_bank_card = (select id_bank_card from bank_card where bank_card_number = '{DataStorage.cardNumber}')";
                SqlCommand commandSelectRepayment = new SqlCommand(querySelectRepayment, database.getConnection());
                SqlDataReader readerUpdate = commandSelectRepayment.ExecuteReader();
                while (readerUpdate.Read()) {
                    creditTakeDate = Convert.ToDateTime(readerUpdate[0].ToString());
                    creditSum = Convert.ToDouble(readerUpdate[1].ToString());
                    creditTotalSum = Convert.ToDouble(readerUpdate[2].ToString());
                    toPayDate = Convert.ToDateTime(readerUpdate[3].ToString());
                    creditToPaySum = Convert.ToDouble(readerUpdate[4].ToString());
                }
                readerUpdate.Close();
                database.closeConnection();

                labelDate.Text = creditTakeDate.ToShortDateString();
                labelSum.Text = Math.Round(creditSum, 2).ToString();
                labelTotalSum.Text = Math.Round(creditTotalSum, 2).ToString();
                labelDateToPay.Text = toPayDate.ToShortDateString();
                labelToPay.Text = Math.Round(creditToPaySum, 2).ToString();

                buttonPay.Visible = true;
                panel3.Visible = true;
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            DateTime toPayDate = Convert.ToDateTime(labelDateToPay.Text);
            toPayDate = toPayDate.AddMonths(1);
            var sumToPay = labelToPay.Text;
            double toPaySum = 0;
            DateTime dateRepay = new DateTime();
            bool error = false;

            database.openConnection();

            double cardBalanceCheck = 0;
            var queryCheckCard = $"select bank_card_balance from bank_card where bank_card_number = '{DataStorage.cardNumber}'";
            SqlCommand commandCheckCard = new SqlCommand(queryCheckCard, database.getConnection());
            database.openConnection();
            SqlDataReader reader = commandCheckCard.ExecuteReader();
            while (reader.Read())
            {
                cardBalanceCheck = Convert.ToDouble(reader[0].ToString());
            }
            reader.Close();
            database.closeConnection();

            double checkSum = Convert.ToDouble(labelSum.Text);
            double checkTotalSum = Convert.ToDouble(labelTotalSum.Text);
            bool checkStatus = false;

            if (checkSum >= checkTotalSum) {
                MessageBox.Show("Кредит погашено!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                checkStatus = true;
            }

            if (checkStatus == false) {
                double paymentSum = Convert.ToDouble(labelToPay.Text);

                if (paymentSum > cardBalanceCheck) {
                    MessageBox.Show("Помилка. Недостатньо коштів для здійснення операції.", "Відміна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true;
                }

                if (error == false) {
                    database.openConnection();
                    var queryPayCredit = $"update credits set repayment_date = '{toPayDate}', credit_sum = credit_sum + repayment_sum where id_bank_card = (select id_bank_card from bank_card where bank_card_number = '{DataStorage.cardNumber}')";
                    var queryPay = $"update bank_card set bank_card_balance = bank_card_balance - '{sumToPay}' where bank_card_number = '{DataStorage.cardNumber}'";
                    
                    DateTime transactionDate = DateTime.Now;
                    var transactionNumber = "P";
                    for (int i = 0; i < 10; i++) {
                        transactionNumber += Convert.ToString(rand.Next(0, 10));
                    }
                    var queryTransaction = $"insert into transactions(transaction_type, transaction_destination, transaction_date, transaction_number, transaction_value, id_bank_card) values('Кредит', 'Погашення кредиту', '{transactionDate}', '{transactionNumber}', '{sumToPay}', (select id_bank_card from bank_card where bank_card_number = '{DataStorage.cardNumber}'))";

                    var command = new SqlCommand(queryPayCredit, database.getConnection());
                    var command1 = new SqlCommand(queryPay, database.getConnection());
                    var command2 = new SqlCommand(queryTransaction, database.getConnection());

                    command.ExecuteNonQuery();
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();

                    var querySelectRepayment = $"select repayment_date, credit_sum from credits where id_bank_card = (select id_bank_card from bank_card where bank_card_number = '{DataStorage.cardNumber}')";
                    SqlCommand commandSelectRepayment = new SqlCommand(querySelectRepayment, database.getConnection());
                    SqlDataReader reader1 = commandSelectRepayment.ExecuteReader();
                    while (reader1.Read())
                    {
                        dateRepay = Convert.ToDateTime(reader1[0].ToString());
                        toPaySum = Convert.ToDouble(reader1[1].ToString());
                    }
                    reader1.Close();
                    database.closeConnection();

                    labelSum.Text = Math.Round(toPaySum, 2).ToString();
                    labelDateToPay.Text = dateRepay.ToShortDateString();
                }
            }
        }

        private void Credit_MouseDown(object sender, MouseEventArgs e)
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