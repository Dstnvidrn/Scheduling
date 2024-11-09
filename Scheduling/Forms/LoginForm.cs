using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using Scheduling.Data;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using Scheduling.Services;
using System.Collections.Generic;
using Scheduling.Logging;
using Scheduling.Helpers;
using Scheduling.Data.Repositories;
namespace Scheduling
{
    public partial class LoginForm : Form
    {
        private static readonly string _APIKEY = ConfigurationManager.AppSettings["ApiKey"];
        private static readonly string _URL = $"{ConfigurationManager.AppSettings["URL"]}{_APIKEY}";
        private LocationService _locationService;
        private AuthenticationService _authenticationService;
        private UserService _userService;
        

        public  LoginForm(UserService userService)
        {
            InitializeComponent();
            LoadColors();           
            dropdownLanguage.SelectedItem = "EN";

            _locationService = new LocationService();
            
            LocalizationService.SetCulture(dropdownLanguage.SelectedItem.ToString());            
            // initialize database connection with connection string
            _authenticationService = new AuthenticationService(_database);
           
        }
        private void LoadColors()
        {
            this.BackColor = ColorTranslator.FromHtml(Colors.PrimaryColor);
            btnLogin.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);
            pnlLoginLeft.BackColor = Color.FromArgb(63, 72, 87);


            lblState.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor);
            lblUserCity.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor);
            lblUserCountry.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor);
        }

       private void CenterControls()
        {
            // Center Login icon
            LayoutManager.CenterDuoNestedControlsX(pnlLoginImage, passwordIcon, pbLoginIcon, 10);
            // Center Username icon and textbox
            LayoutManager.CenterDuoNestedControlsX(pnlLoginControls, usernameIcon, txtUsername, 10);
            // Center password icon and textbox
            LayoutManager.CenterDuoNestedControlsX(pnlLoginControls,passwordIcon, txtPassword, 10);
            
            // Center login button to allign with text boxes
            LayoutManager.CenterDuoNestedControlsX(pnlLoginControls, passwordIcon, btnLogin,10);
            // Center cancel link label
            LayoutManager.CenterSingleNestedControlsXMargins(pnlLoginControls, lnklblCancel, passwordIcon.Width + 10, 0);

            // Center Location Icon
            LayoutManager.CenterSingleNestedControlsX(pnlLoginLeft, pbLocationIcon);

            //Center city label 
            LayoutManager.CenterSingleNestedControlsX(pnlLoginLeft, lblUserCity);

            // Center State/region label
            LayoutManager.CenterSingleNestedControlsX(pnlLoginLeft, lblState);
            // Center Country label
            LayoutManager.CenterSingleNestedControlsX(pnlLoginLeft, lblUserCountry);
           

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int? userId = _userRepository.GetUserId(username);
            string selectedLanguage = dropdownLanguage.SelectedItem.ToString();
            // Verify login credentials
            if (_authenticationService.ValidateCredentials(username, password) && userId != null)
            {
                // Log login attempt - SUCCESS
                LoginLogger.LogLoginAttempt(username, true);
                SetLabelMessage(tsslLoginStatus, true);

                await Task.Delay(1200);
                this.Hide();

                using (Form appointmentForm = new AppointmentsForm(_database,userId))
                {
                    appointmentForm.ShowDialog();
                    if (appointmentForm.DialogResult != DialogResult.OK)
                    {
                        this.Close();                
                    }
                    this.Show();
                }

            }
            else
            {
                // Log login attempt - FAIL
                LoginLogger.LogLoginAttempt(username, false);
                SetLabelMessage(tsslLoginStatus, false);
            }
            
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
                lblState.Text = userInfo.Region;
                lblUserCity.Text = userInfo.City;
                lblUserCountry.Text = userInfo.Country;
            }
        }

        private async void LoginForm_Load(object sender, EventArgs e)
        {
            // Adjust centering of items on form
            UserInfo userInfo = await GetUserInfo(_URL);
            if (userInfo != null) UpdateLocationLabels(userInfo);
            CenterControls();
        }
        private void dropdownLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocalizationService.SetCulture(dropdownLanguage.SelectedItem.ToString().ToLower());
            tsslLoginStatus.Text = LocalizationService.GetMessage("Standby");
        }
        private void SetLabelMessage(ToolStripLabel label, bool isSuccess)
        {
            // Retrieve the message based on the selected language
            string message = isSuccess ? LocalizationService.GetMessage("LoginSuccess") : LocalizationService.GetMessage("LoginError");// Default to English if language is not found
            string backgroundColorHex = isSuccess ? "#D4EDDA" : "#F8D7DA";
            string textColorHex = isSuccess ? "#155724" : "#721C24";
            int xLocation = isSuccess ? 423 : 345;
            // Set label properties
            label.Text = message;
            label.BackColor = ColorTranslator.FromHtml(backgroundColorHex);
            label.ForeColor = ColorTranslator.FromHtml(textColorHex);
            label.Visible = true;
        }

        private void lnklblCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void passwordIcon_Click(object sender, EventArgs e)
        {

        }
    }

}
