using Scheduling.Data.Repositories;
using Scheduling.DTOs;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using Scheduling.Models;
using Scheduling.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private Appointment MapAndValidateAppointment(AppointmentDTO appointmentDTO)
        {
            try
            {
                // Retrieve the user's time zone
                TimeZoneInfo userTimeZone = GetUserTimeZone();

                // Ensure Start and End times have the correct kind
                appointmentDTO.Start = EnsureDateTimeKind(appointmentDTO.Start, DateTimeKind.Local);
                appointmentDTO.End = EnsureDateTimeKind(appointmentDTO.End, DateTimeKind.Local);

                // Convert Start and End to UTC
                appointmentDTO.Start = ConvertToUtc(appointmentDTO.Start, userTimeZone);
                appointmentDTO.End = ConvertToUtc(appointmentDTO.End, userTimeZone);

                

                // Validate the appointment (overlapping appointments and business hours)
                if (!ValidateAppointment(appointmentDTO))
                {
                    throw new InvalidOperationException("Appointment validation failed.");
                }

                // Map to domain model
                return _appointmentMapper.MapToModel(appointmentDTO, _userMapper.MapToModel(GlobalUserInfo.CurrentLoggedInUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while mapping and validating the appointment: {ex.Message}");
                throw;
            }
        }


        public void AddAppointment(AppointmentDTO appointmentDTO)
        {
            try
            {
                // Retrieve user's time zone
                TimeZoneInfo userTimeZone = GetUserTimeZone();

                // Ensure DateTime.Kind is consistent
                appointmentDTO.Start = EnsureDateTimeKind(appointmentDTO.Start, DateTimeKind.Local);
                appointmentDTO.End = EnsureDateTimeKind(appointmentDTO.End, DateTimeKind.Local);

                // Convert Start and End times to UTC
                appointmentDTO.Start = ConvertToUtc(appointmentDTO.Start, userTimeZone);
                appointmentDTO.End = ConvertToUtc(appointmentDTO.End, userTimeZone);

                // Map and validate
                var appointmentModel = MapAndValidateAppointment(appointmentDTO);

                // Save appointment
                _repository.CreateAppointment(appointmentModel);

                MessageBox.Show("Appointment added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the appointment: {ex.Message}");
            }
        }





        private DateTime EnsureDateTimeKind(DateTime dateTime, DateTimeKind kind)
        {
            return dateTime.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dateTime, kind)
                : dateTime;
        }





        public void UpdateAppointment(AppointmentDTO appointmentDTO)
        {
            try
            {
                // Retrieve user's time zone
                TimeZoneInfo userTimeZone = GetUserTimeZone();

                // Ensure DateTime.Kind is consistent
                appointmentDTO.Start = EnsureDateTimeKind(appointmentDTO.Start, DateTimeKind.Local);
                appointmentDTO.End = EnsureDateTimeKind(appointmentDTO.End, DateTimeKind.Local);

                // Convert Start and End times to UTC
                appointmentDTO.Start = ConvertToUtc(appointmentDTO.Start, userTimeZone);
                appointmentDTO.End = ConvertToUtc(appointmentDTO.End, userTimeZone);

                // Map and validate
                var appointmentModel = MapAndValidateAppointment(appointmentDTO);

                // Update appointment
                _repository.UpdateAppointment(appointmentModel);

                MessageBox.Show("Appointment updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the appointment: {ex.Message}");
            }
        }





        public void DeleteAppointment(int appointmentId) {
            if (appointmentId <= 0)
            {
                throw new ArgumentException("Invalid appointment ID.");
            }

            // Call the repository to delete the appointment
            _repository.DeleteAppointment(appointmentId);
        }

        public bool ValidateAppointment(AppointmentDTO appointment)
        {
            // Check overlapping appointments
            if (_repository.IsOverlappingAppointment(appointment.CustomerId, appointment.Start, appointment.End, appointment.AppointmentId))
            {
                MessageBox.Show("This appointment overlaps with an existing appointment.");
                return false;
            }

            // Validate business hours
            return ValidateBusinessHours(appointment.Start, appointment.End);
        }
        private bool ValidateBusinessHours(DateTime startUtc, DateTime endUtc)
        {
            if (startUtc.Kind != DateTimeKind.Utc || endUtc.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("Start and End times must be in UTC.");
            }

            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEst = TimeZoneInfo.ConvertTimeFromUtc(startUtc, easternZone);
            DateTime endEst = TimeZoneInfo.ConvertTimeFromUtc(endUtc, easternZone);

            // Define business hours
            TimeSpan businessStart = new TimeSpan(9, 0, 0);
            TimeSpan businessEnd = new TimeSpan(17, 0, 0);

            // Check time constraints
            if (startEst.TimeOfDay < businessStart || endEst.TimeOfDay > businessEnd)
            {
                MessageBox.Show("Appointments must be within business hours: 9:00 a.m. to 5:00 p.m., Monday–Friday.");
                return false;
            }

            if (startEst.DayOfWeek == DayOfWeek.Saturday || startEst.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Appointments must be on weekdays.");
                return false;
            }

            return true;
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

        private DateTime ConvertToUserTimeZone(DateTime utcDateTime, string timeZoneId)
        {
            try
            {
                TimeZoneInfo userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, userTimeZone);
            }
            catch (TimeZoneNotFoundException)
            {
                MessageBox.Show($"Invalid time zone: {timeZoneId}. Defaulting to UTC.");
                return utcDateTime; // Return as-is if time zone is invalid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while converting time: {ex.Message}");
                return utcDateTime; // Return as-is on failure
            }
        }

        private DateTime ConvertToUtc(DateTime localDateTime, TimeZoneInfo timeZone)
        {
            if (localDateTime.Kind == DateTimeKind.Utc)
            {
                throw new ArgumentException("DateTime must not be in UTC when converting to UTC.");
            }

            if (localDateTime.Kind == DateTimeKind.Unspecified)
            {
                localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
            }

            return TimeZoneInfo.ConvertTimeToUtc(localDateTime, timeZone);
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
                return _appointmentMapper.MapToDTOs(upcomingAppointments)
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

            return appointments
                .GroupBy(a => a.CustomerName)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        public List<AppointmentDTO> GetAppointmentsForDisplay(int userId)
        {
            // Retrieve appointments from the repository
            var appointments = _appointmentMapper.MapToDTOs(_repository.GetAppointmentsByUser(userId));

            // Get user's time zone
            TimeZoneInfo userTimeZone = GetUserTimeZone();

            // Convert each appointment's times from UTC to user's time zone
            foreach (var appointment in appointments)
            {
                appointment.Start = ConvertFromUtc(appointment.Start, userTimeZone);
                appointment.End = ConvertFromUtc(appointment.End, userTimeZone);
            }

            return appointments;
        }




    }
}
