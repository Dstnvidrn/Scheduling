using Scheduling.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Data.Repositories
{
    internal class AuthenticationRepository : IAuthenticationRepository
    {

        private readonly IDatabaseHelper _databaseHelper;

        public AuthenticationRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public bool ValidateCredentials(string username, string password)
        {
            string query = "SELECT userId FROM user WHERE userName= @username AND password= @password";


            IDbDataParameter[] parameters = new IDbDataParameter[]
            {
                    _databaseHelper.CreateParameter("@username", username),
                    _databaseHelper.CreateParameter("@password", password)
            };

            // Execute query

            DataTable result = _databaseHelper.ExecuteSelectQuery(query, parameters);

            // check if matching result was found

            return result.Rows.Count > 0;
        }
    }
}
