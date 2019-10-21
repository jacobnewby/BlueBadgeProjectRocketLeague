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
    public class CarCreate
    {
        [Display(Name = "Name")]
        public string CarName { get; set; }
        [Display(Name = "Color")]
        public string CarColor { get; set; } 
        [Display(Name = "Rarity")]
        public Rarity CarRarity { get; set; }
    }
}
