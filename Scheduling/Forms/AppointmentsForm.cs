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
            pnlContainer.BackColor = ColorTranslator.FromHtml(Colors.BaseColor);
            btnCreate.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);
            _loggedinUser = loggedInUser;
            dgvAppointments.Width = this.Width;
            dgvAppointments.Height = this.Height;

            
        }

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
            //RenameColumnHeaders();
            LayoutManager.CenterSingleNestedControlsX(pnlContainer, tlpMenuOptions);
            LayoutManager.CenterSingleNestedControlsX(pnlContainer, tlpLogoutOption);
            LayoutManager.CenterSingleNestedControlsX(pnlContainer, lblAppointments);
            // Set placerholder text in search box
            LayoutManager.SetPlacholderText(txtAppointmentSearch, "Search", Colors.NeutalDarkColor);
            lblLoggedInUser.Text = $"Logged in as: {LayoutManager.Capitalize(_loggedinUser.Username)}";


        }
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
            using (AppointmentManager appointmentManager = new AppointmentManager(Mode.Create, _loggedinUser, _databaseHelper))
            {
                appointmentManager.ShowDialog();
                PopulateDataGridView();
            }
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

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            using (CustomerForm customerForm = new CustomerForm(_databaseHelper, Mode.Delete, _loggedinUser))
            {
                customerForm.ShowDialog();

            }
        }


        

        private void btnCustomers_Click_1(object sender, EventArgs e)
        {
            using (CustomerListForm customerListForm = new CustomerListForm(_databaseHelper, _loggedinUser))
            {
                customerListForm.ShowDialog();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                // Retrieve selected appointment from DataGridView
                var selectedAppointment = GetSelectedAppointmentFromGrid();

                // Open the AppointmentForm for editing
                using (AppointmentManager appointmentForm = new AppointmentManager(Mode.Edit, selectedAppointment, _loggedinUser, _databaseHelper))
                {

                    if (appointmentForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh the appointment list after editing
                        PopulateDataGridView();
                    }
                    PopulateDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to edit.");
            }
        }
        private AppointmentDTO GetSelectedAppointmentFromGrid()
        {
            var selectedRow = dgvAppointments.SelectedRows[0];


            AppointmentDTO appointment = new AppointmentDTO();

                    appointment.AppointmentId = Convert.ToInt32(selectedRow.Cells["AppointmentId"].Value);
                    appointment.CustomerId = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);
                    appointment.CustomerName = selectedRow.Cells["CustomerName"].Value.ToString();
                    appointment.Title = selectedRow.Cells["Title"].Value.ToString();
                    appointment.Description = selectedRow.Cells["Description"].Value.ToString();
                    appointment.Type = selectedRow.Cells["Type"].Value.ToString();
                    appointment.Start = Convert.ToDateTime(selectedRow.Cells["Start"].Value);
                    appointment.End = Convert.ToDateTime(selectedRow.Cells["End"].Value);
                    appointment.Location = selectedRow.Cells["Location"].Value.ToString();
                    appointment.Contact = selectedRow.Cells["Contact"].Value.ToString();
                    appointment.URL = selectedRow.Cells["URL"].Value.ToString();



            return appointment;
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure an appointment is selected
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedAppointment = GetSelectedAppointmentFromGrid();

            // Confirm deletion
            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete the appointment '{selectedAppointment.Title}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _appointmentService.DeleteAppointment(selectedAppointment.AppointmentId);
                    MessageBox.Show("Appointment deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the grid
                    PopulateDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
