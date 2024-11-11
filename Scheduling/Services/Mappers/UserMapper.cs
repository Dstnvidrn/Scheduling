using Scheduling.DTOs;
using Scheduling.Interfaces;
using Scheduling.Models;

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
