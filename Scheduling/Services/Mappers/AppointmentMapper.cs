using Scheduling.DTOs;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static Appointment MapFromDataRow(DataRow row)
        {
            User user = new User()
            {
                Username = row["lastUpdateBy"].ToString(),
                UserId = Convert.ToInt32(row["userId"])
            };
            return new Appointment
            {
                AppointmentId = Convert.ToInt32(row["appointmentId"]),
                CustomerId = Convert.ToInt32(row["customerId"]),
                UserId = user.UserId,
                Title = row["title"].ToString(),
                Description = row["description"].ToString(),
                Type = row["type"].ToString(),
                Start = DateTime.SpecifyKind(Convert.ToDateTime(row["start"]), DateTimeKind.Utc),
                End = DateTime.SpecifyKind(Convert.ToDateTime(row["end"]), DateTimeKind.Utc),
                Location = row["location"].ToString(),
                Contact = row["contact"].ToString(),
                URL = row["url"].ToString(),
                CreateDate = DateTime.SpecifyKind(Convert.ToDateTime(row["createDate"]), DateTimeKind.Utc),
                CreatedBy = user,
                LastUpdate = DateTime.SpecifyKind(Convert.ToDateTime(row["lastUpdate"]), DateTimeKind.Utc),
                LastUpdatedBy = user
            };
        }

    }
}
