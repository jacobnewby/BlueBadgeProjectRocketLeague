using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RocketLeague.Data.Car;

namespace RocketLeague.Models
{
    public class GoalCreate
    {
        [Display(Name = "Name")]
        public string GoalName { get; set; }
        [Display(Name = "Color")]
        public string GoalColor { get; set; }
        [Display(Name = "Rarity")]
        public Rarity GoalRarity { get; set; }
    }
}
