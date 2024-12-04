using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Scheduling.DTOs;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Services;

namespace Scheduling
{
    public partial class ReportForm : Form
    {
        private readonly ReportService _reportService;

        public ReportForm(IDatabaseHelper databaseHelper)
        {
            InitializeComponent();
            _reportService = new ReportService(databaseHelper);

            //Populate dropdown for report selection

            comboBoxReportType.Items.Add("Appointment Types by Month");
            comboBoxReportType.Items.Add("User Schedule");
            comboBoxReportType.Items.Add("Appointments by Customer");
            comboBoxReportType.SelectedIndex = 0; // Default selection
        }
        
        private void DisplayAppointmentTypesByMonth()
        {
            var report = _reportService.GetAppointmentTypesByMonth();
            dataGridViewReport.DataSource = report.Select(r => new { TypeAndMonth = r.Key, Count = r.Value }).ToList();
        }

        private void DisplayScheduleForUsers()
        {
            var report = _reportService.GetScheduleForUsers();
            var flattened = report.SelectMany(r => r.Value.Select(a => new
            {
                UserId = r.Key,
                AppointmentId = a.AppointmentId,
                
                Start = a.Start,
                End = a.End,
                Title = a.Title,

            })).ToList();
            dataGridViewReport.DataSource = flattened;           
            dataGridViewReport.Columns["UserId"].HeaderText = "Username";

        }

        private void DisplayTotalAppointmentsByCustomer()
        {
            var report = _reportService.GetTotalAppointmentsByCustomer();
            dataGridViewReport.DataSource = report.Select(r => new { Customer = r.Key, Count = r.Value }).ToList();
        }

        private void comboBoxReportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            LayoutManager.CenterSingleNestedControlsX(pnlReports, comboBoxReportType);
            LayoutManager.CenterSingleNestedControlsX(pnlReports, btnGenerate);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string selectedReport = comboBoxReportType.SelectedItem.ToString();

            switch (selectedReport)
            {
                case "Appointment Types by Month":
                    DisplayAppointmentTypesByMonth();
                    break;
                case "User Schedule":
                    DisplayScheduleForUsers();
                    break;
                case "Appointments by Customer":
                    DisplayTotalAppointmentsByCustomer();
                    break;
                default:
                    MessageBox.Show("Invalid report selected.");
                    break;
            }
        }
    }
}
