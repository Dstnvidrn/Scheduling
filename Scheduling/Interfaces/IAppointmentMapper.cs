using Scheduling.DTOs;
using Scheduling.Models;
using System.Collections.Generic;

namespace Scheduling.Interfaces
{
    public interface IAppointmentMapper
    {
        // Map a list of appointment object to a list of AppointmentDTOs
        List<AppointmentDTO> MapToDTOs(List<Appointment> appointments);

        // Map a single appointment to a appointmentDTO
        AppointmentDTO MapToDTO(Appointment appointment);

        // Map an appointmentDTO to an appointment model
        Appointment MapToModel(AppointmentDTO appointmentDTO);
    }
}
