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
            // Convert appointment times to UTC
            appointmentDTO.Start = ConvertToUtc(appointmentDTO.Start);
            appointmentDTO.End = ConvertToUtc(appointmentDTO.End);

            // Validate appointment
            if (!ValidateAppointment(appointmentDTO))
                throw new InvalidOperationException("Invalid appointment.");

            // Map to model
            return _appointmentMapper.MapToModel(appointmentDTO, _userMapper.MapToModel(GlobalUserInfo.CurrentLoggedInUser));
        }

        public void AddAppointment(AppointmentDTO appointmentDTO)
        {
            try
            {
                // Retrieve the user's time zone
                TimeZoneInfo userTimeZone = GetUserTimeZone();

                // Debug initial values
                Console.WriteLine($"Start (Before): {appointmentDTO.Start}, Kind: {appointmentDTO.Start.Kind}");
                Console.WriteLine($"End (Before): {appointmentDTO.End}, Kind: {appointmentDTO.End.Kind}");

                // Ensure the DateTimeKind is Local for DateTimePicker values
                appointmentDTO.Start = EnsureDateTimeKind(appointmentDTO.Start, DateTimeKind.Local);
                appointmentDTO.End = EnsureDateTimeKind(appointmentDTO.End, DateTimeKind.Local);

                // Convert to UTC
                appointmentDTO.Start = TimeZoneInfo.ConvertTimeToUtc(appointmentDTO.Start, userTimeZone);
                appointmentDTO.End = TimeZoneInfo.ConvertTimeToUtc(appointmentDTO.End, userTimeZone);

                // Debug converted values
                Console.WriteLine($"Start (UTC): {appointmentDTO.Start}, Kind: {appointmentDTO.Start.Kind}");
                Console.WriteLine($"End (UTC): {appointmentDTO.End}, Kind: {appointmentDTO.End.Kind}");

                // Validate the appointment
                if (!ValidateAppointment(appointmentDTO))
                {
                    MessageBox.Show("Appointment validation failed.");
                    return;
                }

                // Map and save
                var appointmentModel = MapAndValidateAppointment(appointmentDTO);
                _repository.CreateAppointment(appointmentModel);

                // Notify success
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
                // Step 1: Retrieve the user's time zone
                TimeZoneInfo userTimeZone = GetUserTimeZone();

                // Step 2: Convert Start and End times to UTC
                appointmentDTO.Start = TimeZoneInfo.ConvertTimeToUtc(appointmentDTO.Start, userTimeZone);
                appointmentDTO.End = TimeZoneInfo.ConvertTimeToUtc(appointmentDTO.End, userTimeZone);

                // Step 3: Validate the updated appointment
                if (!ValidateAppointment(appointmentDTO))
                    return;

                // Step 4: Map to model and update the appointment
                var appointmentModel = _appointmentMapper.MapToModel(appointmentDTO, _userMapper.MapToModel(GlobalUserInfo.CurrentLoggedInUser));
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
            try
            {
                // Ensure the inputs are UTC
                if (startUtc.Kind != DateTimeKind.Utc || endUtc.Kind != DateTimeKind.Utc)
                {
                    throw new ArgumentException("Start and End times must be in UTC.");
                }

                // Convert UTC to Eastern Time
                TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime startEst = TimeZoneInfo.ConvertTimeFromUtc(startUtc, easternZone);
                DateTime endEst = TimeZoneInfo.ConvertTimeFromUtc(endUtc, easternZone);

                // Define business hours in EST
                TimeSpan businessStart = new TimeSpan(9, 0, 0); // 9:00 a.m.
                TimeSpan businessEnd = new TimeSpan(17, 0, 0);  // 5:00 p.m.

                // Check if within business hours
                if (startEst.TimeOfDay < businessStart || endEst.TimeOfDay > businessEnd)
                {
                    MessageBox.Show("Appointments must be scheduled during business hours: 9:00 a.m. to 5:00 p.m., Monday–Friday (EST).");
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

        private DateTime ConvertToUtc(DateTime localDateTime)
        {
            var userTimeZone = GetUserTimeZone();
            return TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(localDateTime, DateTimeKind.Local), userTimeZone);
        }
        private DateTime ConvertFromUtc(DateTime utcDateTime)
        {
            var userTimeZone = GetUserTimeZone();
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, userTimeZone);
        }



        public List<AppointmentDTO> GetUpcomingAppointments(int userId)
        {
            try
            {
                // Step 1: Retrieve the user's time zone
                TimeZoneInfo userTimeZone = GetUserTimeZone();

                // Step 2: Get UTC-based appointments
                var appointments = _repository.GetAppointmentsByUser(userId);

                // Step 3: Filter upcoming appointments in UTC
                var upcomingAppointments = appointments
                    .Where(a => a.Start >= DateTime.UtcNow && a.Start <= DateTime.UtcNow.AddMinutes(15))
                    .ToList();

                // Step 4: Map and convert times to user's time zone
                return _appointmentMapper.MapToDTOs(upcomingAppointments)
                    .Select(a =>
                    {
                        a.Start = TimeZoneInfo.ConvertTimeFromUtc(a.Start, userTimeZone);
                        a.End = TimeZoneInfo.ConvertTimeFromUtc(a.End, userTimeZone);
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
            var appointments = _appointmentMapper.MapToDTOs(_repository.GetAppointmentsByUser(userId));
            TimeZoneInfo userTimeZone = GetUserTimeZone();

            foreach (var appointment in appointments)
            {
                // Convert UTC times to user's local time
                appointment.Start = TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, userTimeZone);
                appointment.End = TimeZoneInfo.ConvertTimeFromUtc(appointment.End, userTimeZone);
            }

            return appointments;
        }



    }
}
