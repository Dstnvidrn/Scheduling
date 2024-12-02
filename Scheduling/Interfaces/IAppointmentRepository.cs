using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduling.Interfaces
{
    public interface IAppointmentRepository
    {
        // Retrieve all appointments
        List<Appointment> GetAppointments();

        // Retrieve a appointment by ID


        // Create new appointment
        void CreateAppointment(Appointment appointment);

        // Update existing appointment
        void UpdateAppointment(Appointment appointment);

        // Delete an appointment
        void DeleteAppointment(int id);
        bool IsOverlappingAppointment(int customerId, DateTime start, DateTime end, int? appointmentId = null);
        List<Appointment> GetAppointmentsByUser(int userId);
        Appointment GetAppointmentById(int appointmentId);
    }
}
