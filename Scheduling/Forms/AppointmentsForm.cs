using Scheduling.Data;
using System;
using Scheduling.Helpers;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Scheduling.Data.Repositories;
using Scheduling.Interfaces;
using System.Collections.Generic;
using Scheduling.DTOs;
using Scheduling.Forms;
using Scheduling.Enums;
using Scheduling.Services;

namespace Scheduling
{
    public partial class AppointmentsForm : Form
    {
        private int? _userId;
        private readonly IDatabase _database;
        private readonly AppointmentService _appointmentService;
        private readonly IDatabaseHelper _databaseHelper;
        private UserDTO _loggedinUser;
        public AppointmentsForm()
        {
            InitializeComponent();
        }
        public AppointmentsForm(IDatabaseHelper databaseHelper, UserDTO loggedInUser)
        {
            InitializeComponent();
            _databaseHelper = databaseHelper;
            _appointmentService = new AppointmentService(databaseHelper);
            dgvAppointments.Width = this.Width;
            dgvAppointments.Height = this.Height;
            pnlContainer.BackColor = ColorTranslator.FromHtml(Colors.BaseColor);
            btnCreate.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);
            _loggedinUser = loggedInUser;

            
        }

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
            //RenameColumnHeaders();
            LayoutManager.CenterSingleNestedControlsX(pnlContainer, tlpMenuOptions);
            LayoutManager.CenterSingleNestedControlsX(pnlContainer, tlpLogoutOption);
            LayoutManager.CenterSingleNestedControlsX(pnlContainer, lblAppointments);
            LayoutManager.CenterSingleNestedControlsX(pnlContainer, lblCustomers);
            // Set placerholder text in search box
            LayoutManager.SetPlacholderText(txtAppointmentSearch, "Search", Colors.NeutalDarkColor);
            lblLoggedInUser.Text = $"Logged in as: {LayoutManager.Capitalize(_loggedinUser.Username)}";


        }
        
        
       // private void RenameColumnHeaders()
        //{
        //    dgvAppointments.AutoGenerateColumns = false;
        //    //Rename table headers for greater readability
            
        //    dgvAppointments.Columns["customerName"].HeaderText = "Customer";
        //    dgvAppointments.Columns["title"].HeaderText = "Title";
        //    dgvAppointments.Columns["description"].HeaderText = "Description";
        //    dgvAppointments.Columns["location"].HeaderText = "Location";
        //    dgvAppointments.Columns["contact"].HeaderText = "Contact";
        //    dgvAppointments.Columns["type"].HeaderText = "Type";
        //    dgvAppointments.Columns["createDate"].HeaderText = "Created Date";
        //    dgvAppointments.Columns["createdBy"].HeaderText = "Created By";
        //    dgvAppointments.Columns["lastUpdate"].HeaderText = "Last Update";
        //    dgvAppointments.Columns["updatedBy"].HeaderText = "Updated By";
        //}
        private void PopulateDataGridView()
        {
            try
            {
                List<AppointmentDTO> appointments = _appointmentService.GetAllAppointments();

                dgvAppointments.DataSource = appointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void txtAppointmentSearch_Enter(object sender, EventArgs e)
        {
            TextBox searchTxt = sender as TextBox;
            if (searchTxt != null && searchTxt.ForeColor == ColorTranslator.FromHtml(Colors.NeutalDarkColor))
            {
                LayoutManager.SetPlacholderText((sender as TextBox), "", "#000000");
            }
        }
        private void txtAppointmentSearch_Exit(object sender, EventArgs e)
        {
            TextBox searchTxt = sender as TextBox;
            if (searchTxt != null && string.IsNullOrEmpty(searchTxt.Text))
            {
                LayoutManager.SetPlacholderText((sender as TextBox), "Search", Colors.NeutalDarkColor);
            }
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using(CustomerForm customerForm = new CustomerForm(_databaseHelper, Mode.Create, _loggedinUser))
            {
                customerForm.ShowDialog();

                if (customerForm.DialogResult == DialogResult.OK)
                {
                    
                }
            }
        }
    }
}
