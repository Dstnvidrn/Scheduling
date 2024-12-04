using Scheduling.Data.Repositories;
using Scheduling.DTOs;
using Scheduling.Interfaces;
using Scheduling.Models;
using Scheduling.Services.Mappers;
using System;
using System.Collections.Generic;

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

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers(); // Fetch all users from repository

        }
    }
}
