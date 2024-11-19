using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public User CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public User LastUpdateBy { get; set; }
    }
}
