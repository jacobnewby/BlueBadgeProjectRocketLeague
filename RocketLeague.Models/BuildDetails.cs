using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeague.Models
{
    public class BuildDetails
    {
        public int BuildID { get; set; }
        [Display(Name = "Name")]
        public string BuildName { get; set; }
        [Display(Name = "Car")]
        public string CarName { get; set; }
        [Display(Name = "Decal")]
        public string DecalName { get; set; }
        [Display(Name = "Wheels")]
        public string WheelsName { get; set; }
        [Display(Name = "Goal Explosion")]
        public string GoalName { get; set; }
    }
}
