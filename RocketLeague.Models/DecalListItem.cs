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
    public class DecalListItem
    {
        public int DecalID { get; set; }
        [Display(Name = "Name")]
        public string DecalName { get; set; }
        [Display(Name = "Color")]
        public string DecalColor { get; set; }
        [Display(Name = "Rarity")]
        public Rarity DecalRarity { get; set; }
    }
}
