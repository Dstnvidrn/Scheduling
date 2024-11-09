using Scheduling.DTOs;
using Scheduling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UserService(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
        }

        public int GetUserId(string username)
        {
             return _userMapper.MapToDTO(_userRepository.GetUser(username)).UserId;

        }


        
    }
}
