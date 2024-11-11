using Scheduling.Data;
using Scheduling.Data.Repositories;
using Scheduling.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling.Services
{
    public class AuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;


        public AuthenticationService(IDatabaseHelper databaseHelper)
        {
            _authenticationRepository = new AuthenticationRepository(databaseHelper);

        }

        public bool ValidateCredentials(string username, string password)
        {
            try
            {
                return _authenticationRepository.ValidateCredentials(username, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
                return false;
            }
        }
    }

}
