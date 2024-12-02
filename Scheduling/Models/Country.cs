using System;

namespace Scheduling.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public User CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public User LastUpdateBy { get; set; }
    }
}
