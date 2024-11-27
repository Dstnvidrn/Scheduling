using Scheduling.DTOs;
using Scheduling.Models;
using Scheduling.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Helpers
{
    static class GlobalUserInfo
    {
        public static UserInfo CurrentUserInfo { get; set; }
        public static UserDTO CurrentLoggedInUser { get; set; }
    }
}
