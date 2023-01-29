using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Globalization;
using System.Net.WebSockets;

namespace ATMLib
{

    public class Account
    {
        DataBaseConnection database = new DataBaseConnection();
        public string client;
        public string email;
        public string phoneNum;
        public string CardNum;
        public double balance;

        public Account()
        {

        }
        public Account(string cardNumber)
        {
            CardNum = cardNumber;
        }

       public string GetFullName(string cardNum)
        {
            string result = "";
            var fullNameQuery = $"select client_last_name,client_first_name,client_middle_name from client join bank_card on client.id_client = bank_card.id_bank_card where bank_card_number = '{cardNum}'";
               
            SqlCommand command = new SqlCommand(fullNameQuery, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result += $"{Convert.ToString(reader[0])} {Convert.ToString(reader[1])} {Convert.ToString(reader[2])}";
                
            }
            reader.Close();


            return result;
        }
        public string GetEmail(string cardNum)
        {
            string result = "";
            var emailQuery = $"select client_email from client join bank_card on client.id_client = bank_card.id_bank_card where bank_card_number = '{cardNum}'";
            SqlCommand command = new SqlCommand(emailQuery, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result += Convert.ToString(reader[0]);
            }
            reader.Close();
            return result;
        }
        public string GetPhoneNumber(string cardNum)
        {
            string result = "";
            string phoneQuery = $"select client_phone_number from client join bank_card on client.id_client = bank_card.id_bank_card where bank_card_number = '{cardNum}'";
            SqlCommand command = new SqlCommand(phoneQuery, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result += Convert.ToString(reader[0]);
            }
            reader.Close();
            return result;
        }
       
    }
}