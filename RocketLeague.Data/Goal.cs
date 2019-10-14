using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeague.Data
{
    public class Goal
    {
        [Key]
        public int GoalID { get; set; }
        public Guid OwnerID { get; set; }
        [Required]
        public string GoalName { get; set; }
        [Required]
        public string GoalColor { get; set; }
        [Required]
        public string GoalRarity { get; set; }
                        
    }
}
