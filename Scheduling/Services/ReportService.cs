using System;
using System.Collections.Generic;
using System.Linq;
using Scheduling.DTOs;
using Scheduling.Data.Repositories;
using Scheduling.Interfaces;
using Scheduling.Helpers;
using Scheduling.Models;

namespace Scheduling.Services
{
    public class ReportService
    {
        private readonly AppointmentService _appointmentService;
        private readonly IDatabaseHelper _databaseHelper;
        private readonly UserService _userService;

        public ReportService(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;                                           
            _appointmentService = new AppointmentService(databaseHelper);
            _userService = new UserService(databaseHelper);
        }

        // Report 1: Number of Appointment Types by Month
        public Dictionary<string, int> GetAppointmentTypesByMonth()
        {
            var appointments = _appointmentService.GetAllAppointments();
            return appointments
                .GroupBy(a => $"{a.Type} - {a.Start.ToString("MMMM")}") // Group by type and month name
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // Report 2: Schedule for Each User
        public Dictionary<string, List<AppointmentDTO>> GetScheduleForUsers()
        {
            // Step 1: Get all appointments
            var appointments = _appointmentService.GetAllAppointments();

            // Step 2: Get all users
            var users = _userService.GetAllUsers();

            // Step 3: Create a dictionary to map UserId to Username
            var userIdToUsername = users.ToDictionary(user => user.UserId, user => user.Username);

            // Step 4: Group appointments by UserId and use Username as the key
            return appointments
                .GroupBy(a => a.UserId) // Group by UserId
                .ToDictionary(
                    g => userIdToUsername.ContainsKey(g.Key) ? userIdToUsername[g.Key] : "Unknown User", // Use Username if available
                    g => g.Select(a => new AppointmentDTO
                    {
                        AppointmentId = a.AppointmentId,
                        Start = a.Start,
                        End = a.End,
                        Title = a.Title,
                        UserId = a.UserId,
                        
                    }).ToList()
                );
        }


        // Report 3: Custom Report - Total Appointments by Customer
        public Dictionary<string, int> GetTotalAppointmentsByCustomer()
        {
            var appointments = _appointmentService.GetAllAppointments();
            return appointments
                .GroupBy(a => a.CustomerName) // Group by CustomerName
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
