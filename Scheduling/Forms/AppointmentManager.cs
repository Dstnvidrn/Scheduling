using Scheduling.DTOs;
using Scheduling.Enums;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Services;
using System;
using System.Data;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace Scheduling.Forms
{
    public partial class AppointmentManager : Form
    {
        private AppointmentService _appointmentService;
        private IDatabaseHelper _databaseHelper;
        private CustomerService _customerService;
        private UserDTO _loggedInUser;
        public AppointmentManager(Mode mode, UserDTO loggedInUser, IDatabaseHelper databaseHelper)
        {
            InitializeComponent();
            AdjustLayout();
            _loggedInUser = loggedInUser;
            if (mode == Mode.Create) { BtnOperation.Text = "Create"; }
            _databaseHelper = databaseHelper;
            _appointmentService = new AppointmentService(databaseHelper);
            _customerService = new CustomerService(databaseHelper, loggedInUser);
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
            if(startEst < DateTime.Now || endEst < DateTime.Now) {
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

        

        private void AppointmentManger_Load(object sender, EventArgs e)
        {
            // Populate Customer ComboBox
            var customers = _customerService.GetCustomerIDAndName();
            cmbCustomer.DataSource = new BindingSource(customers, null);
            cmbCustomer.DisplayMember = "Value";
            cmbCustomer.ValueMember = "Key";

            cmbType.Items.Add("Consultation");
            cmbType.Items.Add("Follow-up");
            cmbType.Items.Add("Meeting");
            cmbType.Items.Add("Review");
        }

        private void BtnOperation_Click(object sender, EventArgs e)
        {
            if (ValidateBusinessHours(dateTimeStart.Value,dateTimeEnd.Value) && ValidateFields()) 
            {
                
                _appointmentService.AddAppointment(CreateCustomer(), _loggedInUser);
                this.Close();

                
            }
        }
        private AppointmentDTO CreateCustomer()

        {
            return new AppointmentDTO
            {
                CustomerId = (int)cmbCustomer.SelectedValue,
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Type = cmbType.SelectedItem.ToString(),
                Start = dateTimeStart.Value,
                End = dateTimeEnd.Value,
                UserId = _loggedInUser.UserId,
                Location = txtLocation.Text,
                URL = txtURL.Text,
                Contact = txtContact.Text,
                
            };
        }


    }
}
