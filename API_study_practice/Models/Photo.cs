using System;
using System.Collections.Generic;

namespace API_study_practice.Models
{
    public partial class Photo
    {
        public int? UserId { get; set; }
        public int? TripId { get; set; }
        public int PhotoId { get; set; }
        public string? PhotoName { get; set; }
        public DateTime DateOfCreating { get; set; }

        public virtual Trip? Trip { get; set; }
        public virtual User? User { get; set; }
    }
}
