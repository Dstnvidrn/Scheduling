using Scheduling.DTOs;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
