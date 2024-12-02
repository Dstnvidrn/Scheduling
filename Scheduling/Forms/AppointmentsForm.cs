using Scheduling.DTOs;
using Scheduling.Enums;
using Scheduling.Forms;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Scheduling
{
    public partial class AppointmentsForm : Form
    {

        private readonly AppointmentService _appointmentService;
        private readonly IDatabaseHelper _databaseHelper;
        public AppointmentsForm()
        {
            InitializeComponent();
        }
        public AppointmentsForm(IDatabaseHelper databaseHelper)
        {
            InitializeComponent();
            _databaseHelper = databaseHelper;
            _appointmentService = new AppointmentService(databaseHelper);
            pnlContainer.BackColor = ColorTranslator.FromHtml(Colors.BaseColor);
            btnCreate.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);
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
            lblLoggedInUser.Text = $"Logged in as: {LayoutManager.Capitalize(GlobalUserInfo.CurrentLoggedInUser.Username)}";
            CheckUpcomingAppointments(GlobalUserInfo.CurrentLoggedInUser.UserId);
            LoadMonthlyAppointments();
            LoadWeeklyAppointments();
        }

        private void PopulateDataGridView()
        {
            try
            {
                List<AppointmentDTO> appointments = _appointmentService.GetAppointmentsForDisplay(GlobalUserInfo.CurrentLoggedInUser.UserId);

                dgvAppointments.DataSource = appointments;
                dgvAppointments.Columns["userId"].Visible = false;
                dgvAppointments.Columns["appointmentId"].Visible = false;
                dgvAppointments.Columns["customerId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }
        private void LoadMonthlyAppointments()
        {
            var appointments = _appointmentService.GetAppointmentsForDisplay(GlobalUserInfo.CurrentLoggedInUser.UserId)
                .Where(a => a.Start.Month == DateTime.Now.Month && a.Start.Year == DateTime.Now.Year)
                .ToList();
            dgvMonthAppoint.DataSource = appointments;
        }

        private void LoadWeeklyAppointments()
        {
            var currentWeekStart = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
            var currentWeekEnd = currentWeekStart.AddDays(7);

            var appointments = _appointmentService.GetAppointmentsForDisplay(GlobalUserInfo.CurrentLoggedInUser.UserId)
                .Where(a => a.Start >= currentWeekStart && a.Start < currentWeekEnd)
                .ToList();
            dgvWeekAppoint.DataSource = appointments;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (AppointmentManager appointmentManager = new AppointmentManager(Mode.Create, GlobalUserInfo.CurrentLoggedInUser, _databaseHelper))
            {
                appointmentManager.ShowDialog();
                PopulateDataGridView();
            }
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

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            using (CustomerForm customerForm = new CustomerForm(_databaseHelper, Mode.Delete))
            {
                customerForm.ShowDialog();

            }
        }




        private void btnCustomers_Click_1(object sender, EventArgs e)
        {
            using (CustomerListForm customerListForm = new CustomerListForm(_databaseHelper))
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
                using (AppointmentManager appointmentForm = new AppointmentManager(Mode.Edit, selectedAppointment, GlobalUserInfo.CurrentLoggedInUser, _databaseHelper))
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

        private void CheckUpcomingAppointments(int userId)
        {
            var upcomingAppointments = _appointmentService.GetUpcomingAppointments(userId);

            if (upcomingAppointments.Any())
            {
                MessageBox.Show($"You have an upcoming appointment: {upcomingAppointments[0].Title} at {upcomingAppointments[0].Start}.",
                    "Upcoming Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
