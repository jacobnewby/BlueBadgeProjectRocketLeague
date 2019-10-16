using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RocketLeague.Data.Car;

namespace RocketLeague.Models
{
    public class DecalEdit
    {
        public int DecalID { get; set; }
        public string DecalName { get; set; }
        public string DecalColor { get; set; }
        public Rarity DecalRarity { get; set; }
    }
}
