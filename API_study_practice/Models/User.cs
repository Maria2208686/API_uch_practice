using System;
using System.Collections.Generic;

namespace API_study_practice.Models
{
    public partial class User
    {
        public User()
        {
            Photos = new HashSet<Photo>();
            Reviews = new HashSet<Review>();
            ToDoLists = new HashSet<ToDoList>();
        }

        public int UserId { get; set; } 
        public string UserName { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public string? UserPatronymic { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ToDoList> ToDoLists { get; set; }
    }
}
