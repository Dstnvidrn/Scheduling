using System;

namespace Scheduling.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; }
        public User CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public User LastUpdatedBy { get; set; }
    }
}
