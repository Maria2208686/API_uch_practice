using System;
using System.Collections.Generic;

namespace API_study_practice.Models
{
    public partial class Trip
    {
        public Trip()
        {
            Expenses = new HashSet<Expense>();
            Photos = new HashSet<Photo>();
        }

        public int TripId { get; set; }
        public string TripName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DestinationPlace { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
