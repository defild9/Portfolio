using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using ATMLib;

namespace ATMLib
{
    public class AutomatedTellerMachine
    {
        DataBaseConnection database = new DataBaseConnection();
        Account account = new Account();
        public delegate void Email (string emailText);
        public delegate void MessageHendler(object sender, Event e);
        public event Email EmailEvent;
        public event MessageHendler BalaceEvent;
        public event MessageHendler SendMoneyEvent;
        public event MessageHendler AddMoneyEvent;
        public event MessageHendler AuthentificatinEvent;
        public event MessageHendler WithdrawMoneyEvent;
        public string UserCardNum;
        public int atmId;
        

        public double GetBalance(string cardNum)
        {
            double result = 0;
            var balanceQuery = $"select bank_card_balance from bank_card where bank_card_number = '{cardNum}'";
            SqlCommand command = new SqlCommand(balanceQuery, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result += Convert.ToDouble(reader.GetDecimal(0));
            }
            reader.Close();

            return result;
        }
        public void CheckBalance()
        {
            double balance = GetBalance(UserCardNum);
            if (BalaceEvent != null)
                BalaceEvent(this, new Event($"Your balance:{balance}"));
        }
        public void AddMoney(int countOfMoney)
        {
            string notice = $"The card has been successfully filled for the amount of {countOfMoney}";
            string error = $"Error of card replenishment :((";
            var addMoneyBalance = $"update bank_card set bank_card_balance +={countOfMoney} where bank_card_number = {UserCardNum}";
            var atmOperationQuery = $"update AutomatedTellerMachine set atm_balance -={countOfMoney} where id_atm = {atmId}";
            try
            {
                SqlCommand commandAddMoney = new SqlCommand(addMoneyBalance, database.getConnection());
                SqlCommand operate = new SqlCommand(atmOperationQuery, database.getConnection());
                database.openConnection();
                commandAddMoney.ExecuteNonQuery();
                operate.ExecuteNonQuery();
                database.closeConnection();

                if (AddMoneyEvent != null)
                    AddMoneyEvent(this, new Event(notice));
            }
            catch
            {
                if (AddMoneyEvent != null)
                    AddMoneyEvent(this, new Event(error));
            }
            
        }
        public void EmailNotice(string textOfEmail)
        {
            string senderEmail = "biletskijzena@gmail.com";
            string senderPassword = "fanr spki cdqi wyha";
            string emailUser = Convert.ToString(account.GetEmail(UserCardNum));
            string themeOfEmail = "Bank Info";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(senderEmail, emailUser, themeOfEmail, textOfEmail);
        }

        public bool Login(string cardNum, string cardPin)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            bool login = false;

            if (!string.IsNullOrEmpty(cardNum) && !string.IsNullOrEmpty(cardPin))
            {
                var checkClientDataQuery = $"select * from bank_card where bank_card_number = {cardNum} and bank_card_pin = {cardPin}";


                SqlCommand commandCheckData = new SqlCommand(checkClientDataQuery, database.getConnection());
                database.openConnection();
                adapter.SelectCommand = commandCheckData;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    if (AuthentificatinEvent != null)
                        AuthentificatinEvent(this, new Event($"Hi,{account.GetFullName(cardNum)}! Authentication is successful:)"));
                    login = true;
                }
                else
                {
                    if (AuthentificatinEvent != null)
                        AuthentificatinEvent(this, new Event("The password is incorrect:("));
                    login = false;
                }
            }
            return login;
        }
        public void SendMoneyTo(double sum, string destinationCard)
        {
            bool errorCheker = false;
            string errorNoCard = "There is no such card";
            string errorThisSameCard = "You cannot transfer funds to your card";
            string errorSumLessThenOne = "Minimum transfer amount 1.00 UAH";
            string errorSumMoreThenBalance = "Insufficient funds for the operation.";
            string succesTransfer = $"{account.GetFullName(UserCardNum)}, {sum} withdrawn from your account and transfer to {destinationCard}";
            var checkCardNumberQuery = $"select bank_card_number from bank_card where bank_card_number = {destinationCard}";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand commandCheckDestinationCard = new SqlCommand(checkCardNumberQuery, database.getConnection());
            database.openConnection();
            adapter.SelectCommand = commandCheckDestinationCard;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                if(sum < 1.00)
                {
                    if (SendMoneyEvent != null)
                        SendMoneyEvent(this, new Event(errorSumLessThenOne));
                    errorCheker = true;
                }
                if(UserCardNum == destinationCard)
                {
                    if(SendMoneyEvent != null)
                        SendMoneyEvent(this,new Event(errorThisSameCard));
                    errorCheker = true;
                }
                if (sum > GetBalance(UserCardNum))
                {
                    if (SendMoneyEvent != null)
                        SendMoneyEvent(this, new Event(errorSumMoreThenBalance));
                    errorCheker = true;
                }
                if(errorCheker == false)
                {
                    var transactionQueryOne = $"update bank_card set bank_card_balance -={sum} where bank_card_number = {UserCardNum}";
                    var transactionQuerySecond = $"update bank_card set bank_card_balance +={sum} where bank_card_number = {destinationCard}";
                    SqlCommand commandForTransactionOne = new SqlCommand(transactionQueryOne, database.getConnection());
                    SqlCommand commandForTransactionSecond = new SqlCommand(transactionQuerySecond, database.getConnection());
                    database.openConnection();
                    commandForTransactionOne.ExecuteNonQuery();
                    commandForTransactionSecond.ExecuteNonQuery();
                    database.closeConnection();

                    if (SendMoneyEvent != null)
                        SendMoneyEvent(this, new Event(succesTransfer));
                }
                
            }
            else
            {
                if (SendMoneyEvent != null)
                    SendMoneyEvent(this, new Event(errorNoCard));
            }

        }
        public void WithdrawMoney(int sumForWithdraw)
        {
            string errorBalance = "Withdaraw can't because not enough money";
            string errorAtm = "Withdaraw can't because not enough money at atm";
            string successe = $"All is good take your {sumForWithdraw} UAH";
            double balance = GetBalance(UserCardNum);
            if (balance < sumForWithdraw)
            {
                if (WithdrawMoneyEvent != null)
                    WithdrawMoneyEvent(this, new Event(errorBalance));
            }
            else if (sumForWithdraw > GetAtmBalance())
            {
                if (WithdrawMoneyEvent != null)
                    WithdrawMoneyEvent(this, new Event(errorAtm));
            }
            else
            {
                var widhdrawMoneyQurery = $"update bank_card set bank_card_balance -={sumForWithdraw} where bank_card_number = {UserCardNum}";
                var atmOperationQuery = $"update AutomatedTellerMachine set atm_balance -={sumForWithdraw} where id_atm = {atmId}";
                SqlCommand commandAddMoney = new SqlCommand(widhdrawMoneyQurery, database.getConnection());
                SqlCommand commandOperation = new SqlCommand(atmOperationQuery, database.getConnection());
                database.openConnection();
                commandAddMoney.ExecuteNonQuery();
                commandOperation.ExecuteNonQuery();
                database.closeConnection();
              

                if (WithdrawMoneyEvent != null)
                    WithdrawMoneyEvent(this, new Event(successe));
            }
        }
        public int GetAtmBalance()
        {
            int result = 0;
            var balanceAtmQuery = $"select atm_balance from AutomatedTellerMachine join bank on bank.id_bank = AutomatedTellerMachine.id_atm where id_atm = {atmId}";
            SqlCommand command = new SqlCommand(balanceAtmQuery, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result += Convert.ToInt32(reader[0]);
            }
            reader.Close();

            return result;
        }
    }
}
