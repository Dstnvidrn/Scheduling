using System.Data;

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
