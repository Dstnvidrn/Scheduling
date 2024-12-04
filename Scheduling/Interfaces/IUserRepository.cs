using Scheduling.Models;
using System.Collections.Generic;

namespace Scheduling.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(string username);

    }

}
