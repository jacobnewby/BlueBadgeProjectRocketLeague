using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RocketLeague.Data.Car;

namespace RocketLeague.Models
{
    public class GoalEdit
    {
        public int GoalID { get; set; }
        public string GoalName { get; set; }
        public string GoalColor { get; set; }
        public Rarity GoalRarity { get; set; }
    }
}
