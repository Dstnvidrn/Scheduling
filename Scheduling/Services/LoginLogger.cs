using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling.Logging
{
    public static class LoginLogger
    {
        private static readonly string _logDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static readonly string _logFilePath = Path.Combine(_logDirectoryPath, "Login_History.txt");


        public static void LogLoginAttempt(string username, bool IsSuccess)
        {
            // Check if `Logs` folder exists
            if (!Directory.Exists(_logDirectoryPath))
            {
                Directory.CreateDirectory(_logDirectoryPath);
            }
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string status = IsSuccess ? "Success" : "Failure";
            string logEntry = $"{timestamp} - User: {username} - Status: {status}";

            try
            {
                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging attempt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
