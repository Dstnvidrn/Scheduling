using Scheduling.DTOs;
using Scheduling.Enums;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Services;
using System;
using System.Windows.Forms;

namespace Scheduling.Forms
{
    public partial class CustomerForm : Form
    {
        private Mode _mode;
        private CustomerService _customerService;
        private IDatabaseHelper _databaseHelper;
        private UserDTO _loggedInUser;
        
        public CustomerForm(IDatabaseHelper databaseHelper, Mode mode, UserDTO loggedInUser)
        {
            InitializeComponent();
            _databaseHelper = databaseHelper;
            _loggedInUser = loggedInUser;
            _customerService = new CustomerService(databaseHelper, loggedInUser);
            _mode = mode;
            this.Text = _mode == Mode.Create ? "Add Customer" : "Edit Customer";
            CenterControls();

        }

        private void CenterControls()
        {
            // Center Input controls vertically
            LayoutManager.CenterSingleNestedControlYMargins(pnlCustomerMain, pnlCustomerControls, 30, 30);
            // Center input control horizontially
            LayoutManager.CenterSingleNestedControlsX(pnlCustomerMain, pnlCustomerControls);

            // Center button controls
            LayoutManager.CenterSingleNestedControlsX(pnlCustomerMain, tplBtnControls);
        }
        
        private CustomerDTO PopulateCustomer()
        {
            return new CustomerDTO
            {
                Name = txtCustomername.Text,
                Street1 = txtStreet1.Text,
                Street2 = txtStreet2.Text,
                PhoneNumber = txtPhoneNo.Text,
                Postal = txtPostal.Text,
                CityName = txtCity.Text,
                CountryName = txtCountry.Text,


            };
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(_customerService.CreateCustomer(PopulateCustomer()))
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show($"Customer {LayoutManager.Capitalize(txtCustomername.Text)} created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information );
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
