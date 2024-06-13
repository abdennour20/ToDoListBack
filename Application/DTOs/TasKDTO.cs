using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;
namespace Application.DTOs
{
    public  class TasKDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public TaskSTatus Status { get; set; }

       
        public DateTime dateDed { get; set; }
        public int? assigned_user_id { get; set; }

    }
}
