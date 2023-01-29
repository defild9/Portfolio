using System;
using MobileBank.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobileBank.Forms
{
    public partial class History : Form
    {
        DataBaseConnection database = new DataBaseConnection();

        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            var querySelectTransactions = $"select transaction_type, transaction_destination, transaction_date, transaction_number, transaction_value from transactions inner join bank_card on transactions.id_bank_card = bank_card.id_bank_card inner join client on client.id_client = bank_card.id_client where client.id_client = '{DataStorage.idClient}'";
            SqlCommand command = new SqlCommand(querySelectTransactions, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvitem = new ListViewItem(reader[0].ToString());
                lvitem.SubItems.Add(reader[1].ToString());
                lvitem.SubItems.Add(reader[2].ToString());
                lvitem.SubItems.Add(reader[3].ToString());
                lvitem.SubItems.Add(reader[4].ToString());
                listView1.Items.Add(lvitem);
            }
            reader.Close();

            listView1.Sort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}