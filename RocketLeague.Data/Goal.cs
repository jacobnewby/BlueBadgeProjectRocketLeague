using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RocketLeague.Data.Car;

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
        public Rarity GoalRarity { get; set; }
                        
    }
}
