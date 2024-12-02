using System;

namespace Scheduling.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public User CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public User UpdatedBy { get; set; }
    }
}
