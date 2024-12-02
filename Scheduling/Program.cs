using Scheduling.Data;
using Scheduling.Helpers;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Scheduling
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Database connection
            var _connectionString = ConfigurationManager.ConnectionStrings["MySqlDatabaseConnection"].ConnectionString;
            var _connectionFactory = new DatabaseConnectionFactory(_connectionString);
            var _dataBaseHelper = new DatabaseHelper(_connectionFactory);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(_dataBaseHelper));
        }
    }
}
