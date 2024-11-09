using Scheduling.DTOs;
using Scheduling.Interfaces;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Services.Mappers
{
    public class AppointmentMapper : IAppointmentMapper
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
            };
        }

        public List<AppointmentDTO> MapToDTOs(List<Appointment> appointments)
        {
            return appointments.Select(MapToDTO).ToList();
        }

        public Appointment MapToModel(AppointmentDTO appointmentDTO)
        {
            throw new NotImplementedException();
        }
    }
}
