using Scheduling.DTOs;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Interfaces
{
    public interface IUserMapper
    {
        UserDTO MapToDTO(User user);
    }
}
