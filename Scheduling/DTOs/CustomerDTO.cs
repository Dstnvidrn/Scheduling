using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int AddressId { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public string LastUpdatedBy { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string Postal { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string PhoneNumber { get; set; }


    }
}
