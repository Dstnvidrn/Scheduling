using Scheduling.Models;

namespace Scheduling.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username);

    }

}
