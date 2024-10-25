using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling.Services
{
    internal class Database
    {
        private string _connectionString = "server=127.0.0.1;port=3306;username=root;password=root;database=client_schedule";

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }
        private void ConnectToDatabase()
        {
            

            MySqlConnection databaseConnection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand("select * from user", databaseConnection);
            command.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();

                MySqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {                           // ID                   // UserName             // Password
                        MessageBox.Show($"ID: {dataReader.GetInt32(0)}\n" +
                            $"Name: {dataReader.GetString(1)}\n" +
                            $"Password: {dataReader.GetString(2)}");
                    }
                }
                else
                {
                    MessageBox.Show("No Data");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Query error: {ex.Message}");
            }
        }
    }
}
