using System;

namespace Scheduling.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int AddressId { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
        public string LastUpdatedBy { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string Postal { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string PhoneNumber { get; set; }


    }
}
