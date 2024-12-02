using Scheduling.DTOs;
using Scheduling.Services;

namespace Scheduling.Helpers
{
    static class GlobalUserInfo
    {
        public static UserInfo CurrentUserInfo { get; set; }
        public static UserDTO CurrentLoggedInUser { get; set; }
    }
}
