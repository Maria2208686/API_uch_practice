using System;
using System.Collections.Generic;

namespace API_study_practice.Models
{
    public partial class Expense
    {
        public int? TripId { get; set; }
        public int ExpenseId { get; set; }
        public decimal Sum { get; set; }
        public string Currency { get; set; } = null!;

        public virtual Trip? Trip { get; set; }
    }
}
