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
    public class WheelsEdit
    {
        public int WheelsID { get; set; }
        [Display(Name = "Name")]
        public string WheelsName { get; set; }
        [Display(Name = "Color")]
        public string WheelsColor { get; set; }
        [Display(Name = "Rarity")]
        public Rarity WheelsRarity { get; set; }
    }
}
