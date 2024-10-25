using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using Scheduling.Data;
using System.Data;
namespace Scheduling
{
    public partial class LoginForm : Form
    {
        private int inputTextWidth = 175;
        private int inputTextHeight = 30;
        private readonly MySqlDatabase _database;

        public LoginForm()
        {
            InitializeComponent();
            this.AutoSize = false;
            dropdownLanguage.SelectedItem = "EN";
            // Set sizing for login form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            pnlLoginLeft.BackColor = Color.FromArgb(63, 72, 87);



            // Assign color schemes to controls
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml(Colors.PrimaryColor);
            btnLogin.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);

            labelUserLocation.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor);
            labelDate.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor);
            labelTime.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor);

            // Get connection from Config file
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlDatabaseConnection"].ConnectionString;

            // initialize database connection with connection string
            _database = new MySqlDatabase(connectionString);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbxUsername.Text;
            string password = txtbxPassword.Text;

            // Verify login credentials
            if (ValidateCredentials(username, password))
            {
                MessageBox.Show("Login Successful!");
                this.Hide();

            }
        }

        private bool ValidateCredentials(string username, string password)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM user WHERE userName = @username AND password = @password";


                IDbDataParameter[] parameters = new IDbDataParameter[]
                {
                    _database.CreateParameter("@username", username),
                    _database.CreateParameter("@password", password)
                };

                // Execute query

                DataTable result = _database.ExecuteSelectQuery(query, parameters);

                // check if matching result was found

                if (result.Rows.Count > 0) {
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
            return false;
        }
    }
}
