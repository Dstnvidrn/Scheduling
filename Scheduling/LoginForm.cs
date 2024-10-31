using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using Scheduling.Data;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using Scheduling.Services;
namespace Scheduling
{
    public partial class LoginForm : Form
    {
        private int inputTextWidth = 175;
        private int inputTextHeight = 30;
        private readonly MySqlDatabase _database;
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly string _APIKEY = ConfigurationManager.AppSettings["ApiKey"];
        private static readonly string _URL = $"{ConfigurationManager.AppSettings["URL"]}{_APIKEY}";
        private LocationService _locationService;
        private Task<UserInfo> _userInfo;

        public  LoginForm()
        {
            InitializeComponent();
            this.AutoSize = false;
            dropdownLanguage.SelectedItem = "EN";
            // Set sizing for login form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            pnlLoginLeft.BackColor = Color.FromArgb(63, 72, 87);

            _locationService = new LocationService();
            // Assign color schemes to controls
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml(Colors.PrimaryColor);
            btnLogin.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);

            labelUserState.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor);
            lblUserCity.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor);
            lblUserCountry.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor);

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

            }
            
        }

        

        private bool ValidateCredentials(string username, string password)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM user WHERE userName= @username AND password= @password";


                IDbDataParameter[] parameters = new IDbDataParameter[]
                {
                    _database.CreateParameter("@username", username),
                    _database.CreateParameter("@password", password)
                };

                // Execute query

                DataTable result = _database.ExecuteSelectQuery(query, parameters);

                // check if matching result was found

                if (result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) > 0) {
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Invaild Credentials",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
            return false;
        }
        private async Task<UserInfo> GetUserInfo(string url)
        {
            UserInfo userInfo = null;
            try
            {
                userInfo = await _locationService.GetUserInfo(url);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
            return userInfo;
        }

         
        private void UpdateLocationLabels(UserInfo userInfo)
        {

            if (userInfo != null)
            {
                labelUserState.Text = $"{userInfo.Region},";
                lblUserCity.Text = $"{userInfo.City},";
                lblUserCountry.Text = userInfo.Country;
            }
        }

        private async void LoginForm_Load(object sender, EventArgs e)
        {

            UserInfo userInfo = await GetUserInfo(_URL);
            if (userInfo != null) UpdateLocationLabels(userInfo);
        }

    private void pnlLoginLeft_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void lblUserCity_Click(object sender, EventArgs e)
        {

        }
    }
}
