using System;
using System.Collections.Generic;

namespace API_study_practice.Models
{
    public partial class Review
    {
        public int? UserId { get; set; }
        public int? EventId { get; set; }
        public int ReviewId { get; set; }
        public string? TitleOfReview { get; set; }
        public string? ReviewText { get; set; }
        public int Estimation { get; set; }

        public virtual Event? Event { get; set; }
        public virtual User? User { get; set; }
    }
}
