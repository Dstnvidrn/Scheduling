using Scheduling.Data;
using Scheduling.Data.Repositories;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Services;
using Scheduling.Services.Mappers;
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
            var _connectionString = ConfigurationManager.AppSettings["MySqlDatabaseConnection"];
            var _connectionFactory = new DatabaseConnectionFactory(_connectionString);
            var _dataBaseHelper = new DatabaseHelper(_connectionFactory);

            // Repository Setup
            IUserRepository _userRepository = new UserRepository(_dataBaseHelper);
            IUserMapper _userMapper = new UserMapper();
            // Service Setup
            UserService userService = new UserService(_userRepository, _userMapper);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(_));
        }
    }
}
