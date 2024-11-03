using Scheduling.Data;
using Scheduling.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling.Services
{
    public class AuthenticationService
    {
        private readonly MySqlDatabase _database;
        public AuthenticationService(MySqlDatabase database)
        {
            _database = database;

        }

        public  bool ValidateCredentials(string username, string password)
        {
            try
            {
                string query = "SELECT userId FROM user WHERE userName= @username AND password= @password";


                IDbDataParameter[] parameters = new IDbDataParameter[]
                {
                    _database.CreateParameter("@username", username),
                    _database.CreateParameter("@password", password)
                };

                // Execute query

                DataTable result = _database.ExecuteSelectQuery(query, parameters);

                // check if matching result was found

                return result.Rows.Count > 0;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
            return false;
        }

    }
}
