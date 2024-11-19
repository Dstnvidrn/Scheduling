using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
