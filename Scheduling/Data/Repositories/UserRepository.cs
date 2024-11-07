using Scheduling.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Data.Repositories
{
    public class UserRepository
    {
        private IDatabase _database;


        public UserRepository(IDatabase database)
        {
            _database = database;
        }
        public int? GetUserId(string username)
        {
            string query = "SELECT userId FROM user WHERE userName = @username";
            
            IDataParameter[] parameters = new IDataParameter[]
            {
                _database.CreateParameter("@username", username)
            };
            DataTable result = _database.ExecuteSelectQuery(query, parameters);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["userId"]);
            }
            return null;

        }
    }
}
