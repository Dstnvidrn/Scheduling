using Scheduling.Data.Repositories;
using Scheduling.DTOs;
using Scheduling.Interfaces;
using Scheduling.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IAppointmentMapper _mapper;

        public AppointmentService(IDatabaseHelper databaseHelper)

        {
            _repository = new AppointmentRepository(databaseHelper);
            _mapper = new AppointmentMapper();
        }

        public List<AppointmentDTO> GetAllAppointments()
        { 
            var appointments = _repository.GetAppointments();

            return _mapper.MapToDTOs(appointments);
        }



    }
}
