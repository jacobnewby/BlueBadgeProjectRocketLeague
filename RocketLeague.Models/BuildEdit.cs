using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RocketLeague.Models
{
    public class BuildEdit
    {
        public int BuildID { get; set; }
        public HttpPostedFileBase File { get; set; }
        [Display(Name = "Name")]
        public string BuildName { get; set; }
        [Display(Name = "Car")]
        public int CarID { get; set; }
        [Display(Name = "Decal")]
        public int DecalID { get; set; }
        [Display(Name = "Wheels")]
        public int WheelsID { get; set; }
        [Display(Name = "Goal Explosion")]
        public int GoalID { get; set; }
    }
}
