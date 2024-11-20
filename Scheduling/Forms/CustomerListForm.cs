using Scheduling.DTOs;
using Scheduling.Enums;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling.Forms
{
    public partial class CustomerListForm : Form
    {

        private readonly CustomerService _customerService;
        private readonly IDatabaseHelper _databaseHelper;
        private UserDTO _loggedinUser;
        private Mode _mode;
        public CustomerListForm()
        {
            InitializeComponent();
        }
        public CustomerListForm(IDatabaseHelper databaseHelper, UserDTO loggedInUser)
        {
            InitializeComponent();
            _databaseHelper = databaseHelper;
            _customerService = new CustomerService(databaseHelper, loggedInUser);
            pnlContainer.BackColor = ColorTranslator.FromHtml(Colors.BaseColor);
            btnAddCustomer.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);
            _loggedinUser = loggedInUser;
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
            using (CustomerForm customerForm = new CustomerForm(_databaseHelper, Mode.Create, _loggedinUser))
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

        private void btnCustomerListCnl_Click(object sender, EventArgs e)
        {

        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    Name= selectedRow.Cells["Name"].Value?.ToString(),
                    Street1 = selectedRow.Cells["Street1"].Value?.ToString(),
                    Street2 = selectedRow.Cells["Street2"].Value?.ToString(),
                    CityName = selectedRow.Cells["CityName"].Value?.ToString(),
                    CountryName = selectedRow.Cells["CountryName"].Value?.ToString(),
                    Active = Convert.ToBoolean(selectedRow.Cells["Active"].Value)
                };

                return customerDTO;
            }

            return null; // No row selected
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
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
    }
}
