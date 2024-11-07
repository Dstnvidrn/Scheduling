using Scheduling.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Interfaces
{
    public interface IDatabase
    {
        IDbConnection GetConnection();

        DataTable ExecuteSelectQuery(string query, IDataParameter[] parameters = null);
        int ExecuteNonQuery(string query, IDataParameter[] parameters = null);
        IDbDataParameter CreateParameter(string name, object value);
    }
}
