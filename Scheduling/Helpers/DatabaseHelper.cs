using MySql.Data.MySqlClient;
using Scheduling.Data;
using Scheduling.Interfaces;
using System;
using System.Data;
using System.Windows.Forms;

namespace Scheduling.Helpers
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly DatabaseConnectionFactory _connectionFactory;

        public DatabaseHelper(DatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IDbDataParameter CreateParameter(string name, object value)
        {
            return new MySqlParameter(name, value);
        }

        public int ExecuteNonQuery(string query, IDataParameter[] parameters = null)
        {
            int rowsAffected = 0;
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error executing query.", ex);
                    }
                }
            }
            return rowsAffected;
        }

        public DataTable ExecuteSelectQuery(string query, IDataParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    try
                    {
                        connection.Open();
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Query error: {ex.Message}");
                    }
                }
            }
            return dataTable;
        }
    }
}
