using System.Data;

namespace Scheduling.Interfaces
{
    public interface IDatabaseHelper
    {
        IDbDataParameter CreateParameter(string name, object value);
        DataTable ExecuteSelectQuery(string query, IDataParameter[] parameters = null);
        int ExecuteNonQuery(string query, IDataParameter[] parameters = null);
    }
}
