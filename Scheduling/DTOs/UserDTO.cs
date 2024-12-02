using System;

namespace Scheduling.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
