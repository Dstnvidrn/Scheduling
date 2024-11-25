using Scheduling.Data.Repositories;
using Scheduling.DTOs;
using Scheduling.Interfaces;
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
        
        public void AddAppointment(AppointmentDTO appointment, UserDTO loggedInUser)
        {
            try
            {
                if (!ValidateAppointment(appointment))
                    return;

                _repository.CreateAppointment(_appointmentMapper.MapToModel(appointment, _userMapper.MapToModel(loggedInUser)));
                MessageBox.Show("Appointment added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the appointment: {ex.Message}");
            }
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

            return true;
        }


    }
}
