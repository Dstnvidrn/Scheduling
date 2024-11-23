using Scheduling.DTOs;
using Scheduling.Enums;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using System;
using System.Data;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace Scheduling.Forms
{
    public partial class AppointmentManager : Form
    {
        public AppointmentManager(Mode mode, UserDTO loggedInUser)
        {
            InitializeComponent();
            AdjustLayout();
            if (mode == Mode.Create) { BtnOperation.Text = "Create"; }

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
                string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter required fields.");
                return false;
            }
            return true;
                
        }

        

        private void AppointmentManger_Load(object sender, EventArgs e)
        {

        }

        private void BtnOperation_Click(object sender, EventArgs e)
        {
            if (ValidateBusinessHours(dateTimeStart.Value,dateTimeEnd.Value) && ValidateFields()) 
            {
                MessageBox.Show("Success");
            }
        }


    }
}
