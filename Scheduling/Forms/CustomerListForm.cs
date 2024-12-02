using Scheduling.DTOs;
using Scheduling.Enums;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduling.Forms
{
    public partial class CustomerListForm : Form
    {

        private readonly CustomerService _customerService;
        private readonly IDatabaseHelper _databaseHelper;
        private Mode _mode;
        public CustomerListForm()
        {
            InitializeComponent();
        }
        public CustomerListForm(IDatabaseHelper databaseHelper)
        {
            InitializeComponent();
            _databaseHelper = databaseHelper;
            _customerService = new CustomerService(databaseHelper);
            pnlContainer.BackColor = ColorTranslator.FromHtml(Colors.BaseColor);
            btnAddCustomer.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);
        }

        private void PopulateDataGridView()
        {
            try
            {
                List<CustomerDTO> customers = _customerService.GetAllCustomers();

                dgvCustomers.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using (CustomerForm customerForm = new CustomerForm(_databaseHelper, Mode.Create))
            {
                customerForm.ShowDialog();
                LoadCustomers();

            }
        }



        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
            //RenameColumnHeaders();
            LayoutManager.CenterSingleNestedControlsX(pnlContainer, tlpCustomerOptions);
            LayoutManager.CenterSingleNestedControlsX(pnlContainer, tlpLogoutOption);
            LayoutManager.CenterSingleNestedControlsX(pnlContainer, lblCustomers);
            // Set placerholder text in search box
            LayoutManager.SetPlacholderText(txtAppointmentSearch, "Search", Colors.NeutalDarkColor);
        }
        private void LoadCustomers()
        {
            dgvCustomers.DataSource = _customerService.GetAllCustomers();
        }
        private CustomerDTO GetSelectedCustomerDTO()
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCustomers.SelectedRows[0];

                // Map the DataGridView row to a CustomerDTO
                var customerDTO = new CustomerDTO
                {
                    Id = Convert.ToInt32(selectedRow.Cells["Id"].Value),
                    Name = selectedRow.Cells["Name"].Value?.ToString(),
                    Street1 = selectedRow.Cells["Street1"].Value?.ToString(),
                    Street2 = selectedRow.Cells["Street2"].Value?.ToString(),
                    CityName = selectedRow.Cells["CityName"].Value?.ToString(),
                    Country = selectedRow.Cells["Country"].Value?.ToString(),
                    Active = Convert.ToBoolean(selectedRow.Cells["Active"].Value),
                    Postal = selectedRow.Cells["Postal"].Value?.ToString(),
                    PhoneNumber = selectedRow.Cells["PhoneNumber"].Value?.ToString()
                };

                return customerDTO;
            }

            return null;
        }

        private void btnDeleteCustomer_Click_1(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                // Get the CustomerId from the selected row (assuming it’s stored in the first column)
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);

                // Confirm deletion
                var confirmResult = MessageBox.Show("Are you sure you want to delete this customer?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Call the delete method
                    _customerService.DeleteCustomer(GetSelectedCustomerDTO());

                    // Refresh the grid (re-fetch data from the database)
                    LoadCustomers();

                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            CustomerDTO customerDTO = GetSelectedCustomerDTO();
            using (CustomerForm customerForm = new CustomerForm(_databaseHelper, Mode.Edit, GlobalUserInfo.CurrentLoggedInUser, customerDTO))
            {
                customerForm.ShowDialog();
                LoadCustomers();
            }
        }

        private void btnCustomerListCnl_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
