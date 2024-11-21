using Scheduling.DTOs;
using Scheduling.Enums;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Models;
using Scheduling.Services;
using System;
using System.Windows.Forms;

namespace Scheduling.Forms
{
    public partial class CustomerForm : Form
    {
        private Mode _mode;
        private CustomerService _customerService;
        private UserDTO _loggedInUser;
        private CustomerDTO _selectedCustomerDTO;
        
        public CustomerForm(IDatabaseHelper databaseHelper, Mode mode, UserDTO loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;
            _customerService = new CustomerService(databaseHelper, loggedInUser);
            _mode = mode;
            this.Text = _mode == Mode.Create ? "Add Customer" : "Edit Customer";
            btnCreate.Text = _mode == Mode.Delete ? "Delete" : _mode == Mode.Edit ? "Update" : "Create";
            CenterControls();

        }public CustomerForm(IDatabaseHelper databaseHelper, Mode mode, UserDTO loggedInUser, CustomerDTO selectedCustomerDTO)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;
            _customerService = new CustomerService(databaseHelper, loggedInUser);
            _mode = mode;
            _selectedCustomerDTO = selectedCustomerDTO;
            this.Text = _mode == Mode.Create ? "Add Customer" : "Edit Customer";
            btnCreate.Text = _mode == Mode.Create ? "Create" : "Edit";
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
        
        private CustomerDTO PopulateCustomerDTO()
        {
            return new CustomerDTO
            {
                Name = txtCustomername.Text,
                Street1 = txtStreet1.Text,
                Street2 = txtStreet2.Text,
                PhoneNumber = txtPhoneNo.Text,
                Postal = txtPostal.Text,
                CityName = txtCity.Text,
                Country = txtCountry.Text,


            };
        }
        private void PopulateCustomerForm(CustomerDTO customer)
        {
            txtCity.Text = customer.CityName;
            txtCountry.Text = customer.Country;
            txtStreet1.Text = customer.Street1;
            txtStreet2.Text = customer.Street2;
            txtCustomername.Text = customer.Name;
            txtPhoneNo.Text = customer.PhoneNumber;
            txtPostal.Text = customer.Postal;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {

            if(_mode == Mode.Create)
            {
                _customerService.CreateCustomer(PopulateCustomerDTO());
                this.DialogResult = DialogResult.OK;
                MessageBox.Show($"Customer {LayoutManager.Capitalize(txtCustomername.Text)} created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information );
                this.Close();
            }
            else if (_mode == Mode.Edit)
            {
                if (!ValidateInput())
                {
                    return;
                }
                _selectedCustomerDTO.Name = txtCustomername.Text;
                _selectedCustomerDTO.Postal = txtPostal.Text;
                _selectedCustomerDTO.PhoneNumber = txtPhoneNo.Text == null ? "" : txtPhoneNo.Text;
                _selectedCustomerDTO.CityName = txtCity.Text;
                _selectedCustomerDTO.Country = txtCountry.Text;
                _selectedCustomerDTO.Street1 = txtStreet1.Text;
                _selectedCustomerDTO.Street2 = txtStreet2.Text == null ? "" : txtStreet2.Text;
                _selectedCustomerDTO.LastUpdatedBy = _loggedInUser.Username;
                _selectedCustomerDTO.LastUpdate = DateTime.Now;

                try
                {
                    _customerService.UpdateCustomer(_selectedCustomerDTO);
                    MessageBox.Show($"Customer {LayoutManager.Capitalize(txtCustomername.Text)} updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating the customer: {ex.Message}");
                }


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

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            if (_mode == Mode.Edit)
            {
                
                PopulateCustomerForm(_selectedCustomerDTO);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCustomername.Text) ||
                string.IsNullOrWhiteSpace(txtStreet1.Text) ||
                string.IsNullOrWhiteSpace(txtCity.Text) ||
                string.IsNullOrWhiteSpace(txtCountry.Text) ||
                string.IsNullOrWhiteSpace(txtPostal.Text))
            {
                MessageBox.Show("All fields are required.");
                return false;
            }
            return true;
        }
    }
}
