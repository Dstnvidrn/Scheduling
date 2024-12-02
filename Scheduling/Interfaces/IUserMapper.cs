using Scheduling.DTOs;
using Scheduling.Models;

namespace Scheduling.Interfaces
{
    public interface IUserMapper
    {
        UserDTO MapToDTO(User user);
        User MapToModel(UserDTO userDTO);
    }
}
