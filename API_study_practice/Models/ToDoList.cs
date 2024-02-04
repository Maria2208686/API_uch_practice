using System;
using System.Collections.Generic;

namespace API_study_practice.Models
{
    public partial class ToDoList
    {
        public int? UserId { get; set; }
        public int ToDoId { get; set; }
        public string NameOfTask { get; set; } = null!;
        public string? Description { get; set; }

        public virtual User? User { get; set; }
    }
}
