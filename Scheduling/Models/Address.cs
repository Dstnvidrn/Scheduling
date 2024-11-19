using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public City City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public User CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public User LastUpdatedBy { get; set; } 

    }
}
