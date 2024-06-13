using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;
namespace Domain.Entites
{
    public class TasK
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public TaskSTatus Status { get; set; }

        public DateTime dateDed { get; set; }

        [ForeignKey(nameof(assigned_user_id))]
        public int assigned_user_id { get; set; }

          public User? AssignedUser { get; set; }
       // public ICollection<TaskAssignet>? AssignedUsers { get; set; } 

    }

}
