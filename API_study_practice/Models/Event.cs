using System;
using System.Collections.Generic;

namespace API_study_practice.Models
{
    public partial class Event
    {
        public Event()
        {
            Reviews = new HashSet<Review>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public DateTime Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string? Place { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
