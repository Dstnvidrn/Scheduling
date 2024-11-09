using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.DTOs
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public int AddressId { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public string LastUpdatedBy { get; set; }

    }
}
