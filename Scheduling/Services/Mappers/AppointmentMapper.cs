using Scheduling.DTOs;
using Scheduling.Models;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling.Services.Mappers
{
    public class AppointmentMapper
    {
        public AppointmentDTO MapToDTO(Appointment appointment)
        {
            return new AppointmentDTO
            {
                CustomerName = appointment.CustomerName,
                Title = appointment.Title,
                Description = appointment.Description,
                Location = appointment.Location,
                CreateDate = appointment.CreateDate,
                CreatedBy = appointment.CreatedBy.Username,
                Start = appointment.Start,
                End = appointment.End,
                LastUpdate = appointment.LastUpdate,
                UpdatedBy = appointment.LastUpdatedBy.Username,
                CustomerId = appointment.CustomerId,
                Contact = appointment.Contact,
                Type = appointment.Type,
                URL = appointment.URL,
                AppointmentId = appointment.AppointmentId,
                //UserId = appointment.UserId,


            };
        }

        public List<AppointmentDTO> MapToDTOs(List<Appointment> appointments)
        {
            return appointments.Select(MapToDTO).ToList();
        }

        public Appointment MapToModel(AppointmentDTO appointmentDTO, User loggedInUser)
        {
            return new Appointment
            {
                AppointmentId = appointmentDTO.AppointmentId,
                CustomerName = appointmentDTO.CustomerName,
                Title = appointmentDTO.Title,
                Description = appointmentDTO.Description,
                Location = appointmentDTO.Location,
                CreateDate = appointmentDTO.CreateDate,
                Start = appointmentDTO.Start,
                End = appointmentDTO.End,
                LastUpdate = appointmentDTO.LastUpdate,
                LastUpdatedBy = loggedInUser,
                Contact = appointmentDTO.Contact,
                Type = appointmentDTO.Type,
                CustomerId = appointmentDTO.CustomerId,
                CreatedBy = loggedInUser,
                URL = appointmentDTO.URL,
                UserId = loggedInUser.UserId,


            };
        }
    }
}
