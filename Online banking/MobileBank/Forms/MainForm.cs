 using System;
using System.Data;
using MobileBank.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobileBank.Forms
{
    public partial class MainForm : Form
    {
        DataBaseConnection database = new DataBaseConnection();
        DateTime cartDate = new DateTime();

        public MainForm()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();

        private void MainForm_Load(object sender, EventArgs e)
        {
            label_cardNumber.BringToFront();
            label_cardNumber.Text = "";
            label3.BringToFront();
            label_cardTo.BringToFront();
            label6.BringToFront();
            label_cardCvv.BringToFront();
            pictureBoxMastercard.Visible = false;
            pictureBoxVisa.Visible = false;

            var queryMyCards = $"select id_bank_card, bank_card_number from bank_card where id_client = '{DataStorage.idClient}'";
            SqlDataAdapter commandMyCards = new SqlDataAdapter(queryMyCards, database.getConnection());
            database.openConnection();
            DataTable cards = new DataTable();
            commandMyCards.Fill(cards);
            cardsComboBox.DataSource = cards;
            cardsComboBox.ValueMember = "id_bank_card";
            cardsComboBox.DisplayMember = "bank_card_number";
            database.closeConnection();

            selectBankCard();
            
           
           
        }

        private void selectBankCard()
        {
            bool checkIf = false;
            label_cardNumber.Text = "";
            string paymentSystem = "";
            string querySelectCard = $"select bank_card_number, bank_card_cvv_code, CONCAT(FORMAT(bank_card_date, '%M'), '/', FORMAT(bank_card_date, '%y')), bank_card_paymentSystem, bank_card_balance, bank_card_currency, bank_card_date from bank_card where bank_card_number = '{cardsComboBox.GetItemText(cardsComboBox.SelectedItem)}'"; 
            SqlCommand command = new SqlCommand(querySelectCard, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cardNumber = reader[0].ToString();

                int tmp = 0;
                int tmp1 = 4;
                for (int m = 0; m < 4; m++)
                {
                    for (int n = tmp; n < tmp1; n++)
                    {
                        label_cardNumber.Text += cardNumber[n].ToString();
                    }
                    label_cardNumber.Text += " ";
                    tmp += 4;
                    tmp1 += 4;
                }

                label_cardCvv.Text = reader[1].ToString();
                label_cardTo.Text = reader[2].ToString();
                paymentSystem = reader[3].ToString();
                balanceLabel.Text = Math.Round(Convert.ToDouble(reader[4]), 2).ToString();
                currencyLabel.Text = reader[5].ToString();
                DataStorage.cardCVV = label_cardCvv.Text;
                label_cardCvv.Text = "***";
                DataStorage.cardNumber = reader[0].ToString();
                
                cartDate = Convert.ToDateTime(reader[6].ToString());

                DateTime dateNow = DateTime.Now;
                if (dateNow > cartDate)
                {
                    checkIf = true;
                }
            }
            reader.Close();
            if (checkIf == true)
            {
                MessageBox.Show("Термін дії картки закінчився, срок буде продовжено на 4 роки", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var queryUpdateDate = $"update bank_card set bank_card_date = DATEADD(year, 4, bank_card_date) where bank_card_number = '{DataStorage.cardNumber}'";
                SqlCommand commandUpdateDate = new SqlCommand(queryUpdateDate, database.getConnection());
                commandUpdateDate.ExecuteNonQuery();
            }



            if (paymentSystem == "Visa")
            {
                pictureBoxVisa.Visible = true;
                pictureBoxMastercard.Visible = false;
            }
            else
            {
                pictureBoxMastercard.Visible = true;
                pictureBoxVisa.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBankCard addBankCard = new AddBankCard();
            addBankCard.ShowDialog();
        }

        private void cardsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_cardNumber.Text = "";
            selectBankCard();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SendToForm sendToForm = new SendToForm();
            sendToForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            SendToForm sendToForm = new SendToForm();
            DataStorage.bankCard = CardTextBox.Text;
            DataStorage.cardNumber = cardsComboBox.GetItemText(cardsComboBox.SelectedItem);
            cardsComboBox.Text = "";
            sendToForm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            UserForm userform = new UserForm();
            userform.Show();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PhoneForm phoneForm = new PhoneForm();
            DataStorage.cardNumber = cardsComboBox.GetItemText(cardsComboBox.SelectedItem);
            DataStorage.phoneNumber = textBox1.Text;
            textBox1.Text = "";
            phoneForm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();
        }

        private void buttonComunal_Click(object sender, EventArgs e)
        {
            CommunalPayments communalPayments = new CommunalPayments();
            DataStorage.cardNumber = cardsComboBox.GetItemText(cardsComboBox.SelectedItem);
            communalPayments.Show();
        }

        private void buttonInternet_Click(object sender, EventArgs e)
        {
            InternetAndTvPayments internetAndTvPayments = new InternetAndTvPayments();
            DataStorage.cardNumber = cardsComboBox.GetItemText(cardsComboBox.SelectedItem);
            internetAndTvPayments.Show();
        }

        private void buttonArmy_Click(object sender, EventArgs e)
        {
            ArmyHelp armyHelp = new ArmyHelp();
            DataStorage.cardNumber = cardsComboBox.GetItemText(cardsComboBox.SelectedItem);
            armyHelp.Show();
        }

        private void buttonCredit_Click(object sender, EventArgs e)
        {
            DataStorage.cardNumber = cardsComboBox.GetItemText(cardsComboBox.SelectedItem);
            var cardCurrency = "";
            var queryCheckCurrency = $"select bank_card_currency from bank_card where bank_card_number = '{DataStorage.cardNumber}'";
            SqlCommand commandCheckCurrency = new SqlCommand(queryCheckCurrency, database.getConnection());
            SqlDataReader reader = commandCheckCurrency.ExecuteReader();
            while (reader.Read())
            {
                cardCurrency = reader[0].ToString();
            }
            reader.Close();

            if (cardCurrency == "UAH")
            {
                Credit credit = new Credit();
                credit.Show();
            }
            else
                MessageBox.Show("Операції з кредитом можуть відбуватися лише в гривнях!", "Відмова", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var queryMyCards = $"select id_bank_card, bank_card_number from bank_card where id_client = '{DataStorage.idClient}'";
            SqlDataAdapter commandMyCards = new SqlDataAdapter(queryMyCards, database.getConnection());
            database.openConnection();
            DataTable cards = new DataTable();
            commandMyCards.Fill(cards);
            cardsComboBox.DataSource = cards;
            cardsComboBox.ValueMember = "id_bank_card";
            cardsComboBox.DisplayMember = "bank_card_number";

            database.closeConnection();

            selectBankCard();
        }

        private void label_cardCvv_Click(object sender, EventArgs e)
        {
            if (label_cardCvv.Text == "***")
            {
                label_cardCvv.Text = DataStorage.cardCVV;
            }
            else
                label_cardCvv.Text = "***";

        }

       
    }
}