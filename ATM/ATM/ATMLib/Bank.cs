using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLib
{
    public class Bank
    {
        DataBaseConnection database = new DataBaseConnection();
        public int Id;
        public Bank() { }
        public Bank(int id)
        {
            this.Id = id;
        }
       
        public string GetBankName()
        {
            string result = "";
            var bankNameQuery = $"select bank_name from AutomatedTellerMachine join bank on bank.id_bank = AutomatedTellerMachine.id_atm where id_atm = {Id}";
            SqlCommand command = new SqlCommand(bankNameQuery, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result += Convert.ToString(reader[0]);
            }
            reader.Close();
            return result;
        }
        public string GetAdress()
        {
            string result = "";
            var bankNameQuery = $"select atm_adress_country,atm_adress_city, atm_adress_street from AutomatedTellerMachine join bank on bank.id_bank = AutomatedTellerMachine.id_atm where id_atm = {Id}";
            SqlCommand command = new SqlCommand(bankNameQuery, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result += $"{Convert.ToString(reader[0])}, {Convert.ToString(reader[1])}, {Convert.ToString(reader[2])}";

            }
            reader.Close();


            return result;
        }
        
    }
}
