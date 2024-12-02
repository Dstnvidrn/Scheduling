using System;

namespace Scheduling.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public User CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public User UpdatedBy { get; set; }
    }
}
