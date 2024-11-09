using Scheduling.DTOs;
using Scheduling.Interfaces;
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

        public AppointmentService(IAppointmentRepository repository, IAppointmentMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<AppointmentDTO> GetAllAppointments()
        { 
            var appointments = _repository.GetAppointments();

            return _mapper.MapToDTOs(appointments);
        }



    }
}
