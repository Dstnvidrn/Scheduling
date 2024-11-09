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
    public class UserMapper : IUserMapper
    {
        public UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username
            };
        }
    }
}
