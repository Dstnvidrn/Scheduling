using MySql.Data.MySqlClient;
using System.Data;

namespace Scheduling.Data
{
    public class DatabaseConnectionFactory
    {
        private readonly string _connectionString;

        public DatabaseConnectionFactory(string connectionString) => _connectionString = connectionString;

        public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
    }
}
