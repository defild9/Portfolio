using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MobileBank.Classes
{
    class DataBaseConnection
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = ADMIN; Initial Catalog = MobileBank; Integrated Security = True");


        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}