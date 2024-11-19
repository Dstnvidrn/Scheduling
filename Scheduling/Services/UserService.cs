using Scheduling.Data.Repositories;
using Scheduling.DTOs;
using Scheduling.Interfaces;
using Scheduling.Models;
using Scheduling.Services.Mappers;
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

        public UserService(IDatabaseHelper databaseHelper)
        {
            _userRepository = new UserRepository(databaseHelper);
            _userMapper = new UserMapper();

        }

        public int GetUserId(string username)
        {
             return _userMapper.MapToDTO(_userRepository.GetUser(username)).UserId;

        }
        public UserDTO GetUser(string username) 
        {
            return _userMapper.MapToDTO(_userRepository.GetUser(username));
        }


        
    }
}
