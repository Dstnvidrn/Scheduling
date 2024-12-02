using Scheduling.DTOs;
using Scheduling.Enums;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Services;
using System;
using System.Windows.Forms;

namespace Scheduling.Forms
{
    public partial class AppointmentManager : Form
    {
        private AppointmentService _appointmentService;
        private IDatabaseHelper _databaseHelper;
        private CustomerService _customerService;
        private AppointmentDTO _selectedAppointmentDTO;
        private Mode _mode;
        public AppointmentManager(Mode mode, UserDTO loggedInUser, IDatabaseHelper databaseHelper)
        {
            InitializeComponent();
            AdjustLayout();
            _mode = mode;
            _databaseHelper = databaseHelper;
            _appointmentService = new AppointmentService(databaseHelper);
            _customerService = new CustomerService(databaseHelper);
        }
        public AppointmentManager(Mode mode, AppointmentDTO selectedAppointment, UserDTO loggedInUser, IDatabaseHelper databaseHelper)
        {
            InitializeComponent();
            AdjustLayout();
            _mode = mode;
            _selectedAppointmentDTO = selectedAppointment;
            _databaseHelper = databaseHelper;
            _appointmentService = new AppointmentService(databaseHelper);
            _customerService = new CustomerService(databaseHelper);
        }
        private void AdjustLayout()
        {
            LayoutManager.CenterSingleNestedControlsX(pnlMiddle, tblInputs);
        }

        private bool ValidateBusinessHours(DateTime start, DateTime end)
        {
            // Convert to Eastern Standard Time (EST)
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEst = TimeZoneInfo.ConvertTime(start, easternZone);
            DateTime endEst = TimeZoneInfo.ConvertTime(end, easternZone);

            // Check if within business hours
            TimeSpan businessStart = new TimeSpan(9, 0, 0); // 9:00 a.m.
            TimeSpan businessEnd = new TimeSpan(17, 0, 0);  // 5:00 p.m.

            if (startEst.TimeOfDay < businessStart || endEst.TimeOfDay > businessEnd)
            {
                MessageBox.Show("Appointments must be scheduled during business hours: 9:00 a.m. to 5:00 p.m., Monday–Friday.");
                return false;
            }

            // Check if on a weekend
            if (startEst.DayOfWeek == DayOfWeek.Saturday || startEst.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Appointments must be scheduled on weekdays: Monday–Friday.");
                return false;
            }
            // Check the End date is futher then start
            if (endEst < startEst)
            {
                MessageBox.Show("Ending date must be greater than Starting date.");
                return false;
            }
            // Check if Date has not passed
            if (startEst < DateTime.Now || endEst < DateTime.Now)
            {
                MessageBox.Show("Date selection has passed.");
                return false;
            }

            return true;
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                cmbCustomer.SelectedIndex == -1 || cmbType.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtDescription.Text) || string.IsNullOrWhiteSpace(txtLocation.Text) || string.IsNullOrWhiteSpace(txtURL.Text)
                || string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please enter required fields.");
                return false;
            }
            return true;

        }

        private void PopulateFormFromSelected(AppointmentDTO appointmentDTO)
        {
            txtContact.Text = appointmentDTO.Contact;
            txtDescription.Text = appointmentDTO.Description;
            txtTitle.Text = appointmentDTO.Title;
            txtLocation.Text = appointmentDTO.Location;
            txtURL.Text = appointmentDTO.URL;
            cmbCustomer.SelectedValue = appointmentDTO.CustomerName;
            cmbType.SelectedValue = appointmentDTO.Type;
            dateTimeStart.Value = appointmentDTO.Start;
            dateTimeEnd.Value = appointmentDTO.End;
            cmbCustomer.SelectedValue = appointmentDTO.CustomerId;
            cmbType.SelectedItem = appointmentDTO.Type;
        }



        private void AppointmentManger_Load(object sender, EventArgs e)
        {

            // Populate Customer ComboBox
            PopulateCustomerComboBox();

            // Populate Type ComboBox
            PopulateTypeComboBox();


            if (_mode == Mode.Create)
            {
                BtnOperation.Text = "Create";
            }

            else if (_mode == Mode.Edit)
            {
                BtnOperation.Text = "Update";
                PopulateFormFromSelected(_selectedAppointmentDTO);
            }
        }
        private void PopulateCustomerComboBox()
        {
            // Fetch customer data from the service
            var customers = _customerService.GetCustomerIDAndName();
            cmbCustomer.DataSource = new BindingSource(customers, null);
            cmbCustomer.DisplayMember = "Value"; // CustomerName
            cmbCustomer.ValueMember = "Key";    // CustomerId

            // Debug customer data
            foreach (var customer in customers)
            {
                Console.WriteLine($"CustomerId: {customer.Key}, CustomerName: {customer.Value}");
            }



        }
        private void PopulateTypeComboBox()
        {
            // Populate predefined types
            cmbType.Items.Add("Consultation");
            cmbType.Items.Add("Follow-up");
            cmbType.Items.Add("Meeting");
            cmbType.Items.Add("Review");


        }
        private void BtnOperation_Click(object sender, EventArgs e)
        {
            AppointmentDTO appointmentDTO = new AppointmentDTO();
            if (ValidateBusinessHours(DateTime.SpecifyKind(dateTimeStart.Value, DateTimeKind.Local), DateTime.SpecifyKind(dateTimeEnd.Value, DateTimeKind.Local)) && ValidateFields())
            {
                if (_mode == Mode.Create)
                {
                    _appointmentService.AddAppointment(CollectAppointmentDetails());
                    this.Close();

                }
                else if (_mode == Mode.Edit)
                {
                    DateTime startTime = DateTime.SpecifyKind(dateTimeStart.Value, DateTimeKind.Local);
                    DateTime endTime = DateTime.SpecifyKind(dateTimeEnd.Value, DateTimeKind.Local);
                    try
                    {
                        // Update appointment data
                        appointmentDTO.CustomerId = (int)cmbCustomer.SelectedValue;
                        appointmentDTO.Title = txtTitle.Text;
                        appointmentDTO.Description = txtDescription.Text;
                        appointmentDTO.Type = cmbType.SelectedItem.ToString();
                        appointmentDTO.Start = startTime;
                        appointmentDTO.End = endTime;
                        appointmentDTO.CustomerName = cmbCustomer.SelectedItem.ToString();
                        appointmentDTO.Contact = txtContact.Text;
                        appointmentDTO.Location = txtLocation.Text;
                        appointmentDTO.UserId = GlobalUserInfo.CurrentLoggedInUser.UserId;
                        appointmentDTO.AppointmentId = _selectedAppointmentDTO.AppointmentId;
                        appointmentDTO.URL = txtURL.Text;


                        // Send updated data to the service
                        _appointmentService.UpdateAppointment(appointmentDTO);
                        MessageBox.Show("Appointment updated successfully!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Validation Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }


            }
        }


        private AppointmentDTO CollectAppointmentDetails()
        {
            // Retrieve and explicitly specify the kind of DateTime values
            DateTime startTime = DateTime.SpecifyKind(dateTimeStart.Value, DateTimeKind.Local);
            DateTime endTime = DateTime.SpecifyKind(dateTimeEnd.Value, DateTimeKind.Local);

            // Create and return the DTO
            return new AppointmentDTO
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Start = startTime,
                End = endTime,
                CustomerId = (int)cmbCustomer.SelectedValue,
                Type = cmbType.SelectedItem.ToString(),
                Location = txtLocation.Text,
                Contact = txtContact.Text,
                URL = txtURL.Text,
                UserId = GlobalUserInfo.CurrentLoggedInUser.UserId,
            };
        }


        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
