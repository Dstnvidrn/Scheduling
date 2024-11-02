using MySql.Data.MySqlClient;
using Scheduling.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Scheduling.Data
{

    public class MySqlDatabase : IDataParameterFactory
    {
        
        // Get connection from Config file
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MySqlDatabaseConnection"].ConnectionString;

        public MySqlDatabase()
        {
            
        }

        public IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        

        public IDbDataParameter CreateParameter(string name, object value)
        {
            return new MySqlParameter(name, value);
        }


        public DataTable ExecuteSelectQuery(string query, IDataParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (IDbConnection connection = GetConnection())
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

        public int ExecuteNonQuery(string query, IDataParameter[] parameters = null)
        {
            int rowsAffected = 0;
            using (IDbConnection connection = GetConnection())
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    if (parameters != null)
                    {
                        command.CommandText = query;
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
                        MessageBox.Show($"Query error: {ex.Message}");
                    }
                }
            }

            return rowsAffected;
        }

        public DataTable GetAppointments()
        {
            
                string query = @"
                    SELECT
                        customer.customerName,
                        appointment.title,
                        appointment.description,
                        appointment.location,
                        appointment.contact,
                        appointment.type,
                        appointment.createDate,
                        appointment.createdBy,
                        appointment.lastUpdate,
                        appointment.lastUpdateBy                        
                    FROM
                        appointment
                    INNER JOIN
                        customer ON appointment.customerId = customer.customerId
                    
                    ";
            return ExecuteSelectQuery(query);
        }
    }
}
