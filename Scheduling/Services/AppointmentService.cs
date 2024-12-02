using Scheduling.Data.Repositories;
using Scheduling.DTOs;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Models;
using Scheduling.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Scheduling.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly AppointmentMapper _appointmentMapper;
        private readonly UserMapper _userMapper;

        public AppointmentService(IDatabaseHelper databaseHelper)

        {
            _repository = new AppointmentRepository(databaseHelper);
            _appointmentMapper = new AppointmentMapper();
            _userMapper = new UserMapper();
        }

        public List<AppointmentDTO> GetAllAppointments()
        {
            var appointments = _repository.GetAppointments();

            return _appointmentMapper.MapToDTOs(appointments);
        }


        private DateTime EnsureDateTimeKind(DateTime dateTime, DateTimeKind kind)
        {
            return dateTime.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dateTime, kind)
                : dateTime;
        }

        public void AddAppointment(AppointmentDTO appointmentDTO)
        {
            try
            {

                // Ensure times are local before conversion
                appointmentDTO.Start = EnsureDateTimeKind(appointmentDTO.Start, DateTimeKind.Local);
                appointmentDTO.End = EnsureDateTimeKind(appointmentDTO.End, DateTimeKind.Local);
                // Convert Start and End times to UTC
                appointmentDTO.Start = ConvertToUtc(appointmentDTO.Start);
                appointmentDTO.End = ConvertToUtc(appointmentDTO.End);

                // Validate appointment
                if (!ValidateAppointment(appointmentDTO))
                    return;

                // Map to model and save
                var appointmentModel = _appointmentMapper.MapToModel(appointmentDTO, _userMapper.MapToModel(GlobalUserInfo.CurrentLoggedInUser));
                _repository.CreateAppointment(appointmentModel);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the appointment: {ex.Message}");
            }
        }

        public void UpdateAppointment(AppointmentDTO appointmentDTO)
        {
            try
            {

                // Ensure times are local before conversion
                appointmentDTO.Start = EnsureDateTimeKind(appointmentDTO.Start, DateTimeKind.Local);
                appointmentDTO.End = EnsureDateTimeKind(appointmentDTO.End, DateTimeKind.Local);
                appointmentDTO.LastUpdate = EnsureDateTimeKind(appointmentDTO.LastUpdate, DateTimeKind.Local);
                // Ensure the times are in UTC
                appointmentDTO.Start = ConvertToUtc(appointmentDTO.Start);
                appointmentDTO.End = ConvertToUtc(appointmentDTO.End);
                appointmentDTO.LastUpdate = ConvertToUtc(appointmentDTO.LastUpdate);

                // Fetch existing appointment to preserve createDate
                var existingAppointment = _repository.GetAppointmentById(appointmentDTO.AppointmentId);

                if (existingAppointment == null)
                {
                    throw new Exception("Appointment not found.");
                }

                // Map DTO to Appointment model
                var appointment = _appointmentMapper.MapToModel(appointmentDTO, _userMapper.MapToModel(GlobalUserInfo.CurrentLoggedInUser));

                // Preserve original createDate from the existing appointment
                appointment.CreateDate = existingAppointment.CreateDate;

                // Update the appointment
                _repository.UpdateAppointment(appointment);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the appointment: {ex.Message}");
            }
        }








        public void DeleteAppointment(int appointmentId)
        {
            if (appointmentId <= 0)
            {
                MessageBox.Show("Invalid appointment ID.");
                return;
            }

            _repository.DeleteAppointment(appointmentId);
        }

        // Get appointments for display (converted to user's local time)
        public List<AppointmentDTO> GetAppointmentsForDisplay(int userId)
        {

            // Get user's time zone
            TimeZoneInfo userTimeZone = GetUserTimeZone();
            var appointments = _repository.GetAppointmentsByUser(userId);
            return _appointmentMapper.MapToDTOs(appointments).Select(appointment =>
            {
                appointment.Start = ConvertFromUtc(appointment.Start, userTimeZone);
                appointment.End = ConvertFromUtc(appointment.End, userTimeZone);
                appointment.LastUpdate = ConvertFromUtc(appointment.LastUpdate, userTimeZone);
                return appointment;
            }).ToList();
        }

        // Validate an appointment
        private bool ValidateAppointment(AppointmentDTO appointment)
        {
            // Ensure no overlapping appointments
            if (_repository.IsOverlappingAppointment(appointment.CustomerId, appointment.Start, appointment.End, appointment.AppointmentId))
            {
                MessageBox.Show("This appointment overlaps with an existing appointment.");
                return false;
            }

            // Validate business hours
            return ValidateBusinessHours(appointment.Start, appointment.End);
        }

        // Check if an appointment is within business hours (9 AM - 5 PM EST, Monday-Friday)
        private bool ValidateBusinessHours(DateTime startUtc, DateTime endUtc)
        {
            try
            {
                // Convert UTC to Eastern Time
                TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime startEst = TimeZoneInfo.ConvertTimeFromUtc(startUtc, easternZone);
                DateTime endEst = TimeZoneInfo.ConvertTimeFromUtc(endUtc, easternZone);

                // Define business hours
                TimeSpan businessStart = new TimeSpan(9, 0, 0); // 9:00 a.m.
                TimeSpan businessEnd = new TimeSpan(17, 0, 0);  // 5:00 p.m.

                // Validate if within business hours
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

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while validating business hours: {ex.Message}");
                return false;
            }
        }

        // Convert local time to UTC
        private DateTime ConvertToUtc(DateTime localDateTime)
        {
            if (localDateTime.Kind == DateTimeKind.Unspecified)
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);

            return localDateTime.ToUniversalTime();
        }

        // Convert UTC time to local time
        private DateTime ConvertFromUtc(DateTime utcDateTime)
        {
            return utcDateTime.ToLocalTime();
        }


        private TimeZoneInfo GetUserTimeZone()
        {
            try
            {
                if (GlobalUserInfo.CurrentUserInfo != null && !string.IsNullOrEmpty(GlobalUserInfo.CurrentUserInfo.Timezone))
                {
                    // Map IANA to Windows if necessary
                    string timeZoneId = MapTimeZoneToWindows(GlobalUserInfo.CurrentUserInfo.Timezone)
                                        ?? GlobalUserInfo.CurrentUserInfo.Timezone;

                    return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                }
                else
                {
                    MessageBox.Show("User time zone is not set. Defaulting to UTC.");
                    return TimeZoneInfo.Utc; // Fallback to UTC
                }
            }
            catch (TimeZoneNotFoundException)
            {
                MessageBox.Show($"Invalid time zone: {GlobalUserInfo.CurrentUserInfo.Timezone}. Defaulting to UTC.");
                return TimeZoneInfo.Utc; // Fallback to UTC
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving the user's time zone: {ex.Message}");
                return TimeZoneInfo.Utc; // Fallback to UTC
            }
        }


        private string MapTimeZoneToWindows(string ianaTimeZone)
        {
            var timeZoneMap = new Dictionary<string, string>
            {
                { "America/Chicago", "Central Standard Time" },
                { "America/New_York", "Eastern Standard Time" },
                { "America/Los_Angeles", "Pacific Standard Time" },
                { "UTC", "UTC" }
            };

            return timeZoneMap.TryGetValue(ianaTimeZone, out var windowsTimeZone)
                ? windowsTimeZone
                : null; // Return null if not found
        }




        private DateTime ConvertFromUtc(DateTime utcDateTime, TimeZoneInfo timeZone)
        {
            if (utcDateTime.Kind == DateTimeKind.Local)
            {
                throw new ArgumentException("DateTime must not be Local when converting from UTC.");
            }

            if (utcDateTime.Kind == DateTimeKind.Unspecified)
            {
                utcDateTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);
            }

            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
        }





        public List<AppointmentDTO> GetUpcomingAppointments(int userId)
        {
            try
            {
                // Retrieve the user's time zone
                TimeZoneInfo userTimeZone = GetUserTimeZone();

                // Get UTC-based appointments
                var appointments = _repository.GetAppointmentsByUser(userId);

                // Filter upcoming appointments in UTC
                var upcomingAppointments = appointments
                    .Where(a => a.Start >= DateTime.UtcNow && a.Start <= DateTime.UtcNow.AddMinutes(15))
                    .ToList();

                // Convert times to user's time zone
                return _appointmentMapper.MapToDTOs(upcomingAppointments)  // Lambda used here to map appointments to DTO object more streamline
                    .Select(a =>
                    {
                        a.Start = ConvertFromUtc(a.Start, userTimeZone);
                        a.End = ConvertFromUtc(a.End, userTimeZone);
                        return a;
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching upcoming appointments: {ex.Message}");
                return new List<AppointmentDTO>();
            }
        }






        public Dictionary<string, int> GetAppointmentTypesByMonth()
        {
            var appointments = _repository.GetAppointments();

            return appointments
                .GroupBy(a => new { a.Type, Month = a.Start.Month })
                .ToDictionary(g => $"{g.Key.Type} - Month: {g.Key.Month}", g => g.Count());
        }

        public Dictionary<int, List<AppointmentDTO>> GetScheduleForUsers()
        {
            var appointments = _appointmentMapper.MapToDTOs(_repository.GetAppointments());

            return appointments
                .GroupBy(a => a.UserId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public Dictionary<string, int> GetTotalAppointmentsByCustomer()
        {
            var appointments = _repository.GetAppointments();

            return appointments // Lambda used here to make getting and grouping appointments more streamline
                .GroupBy(a => a.CustomerName)
                .ToDictionary(g => g.Key, g => g.Count());
        }




    }
}
