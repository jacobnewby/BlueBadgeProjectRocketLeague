using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RocketLeague.Data.Car;

namespace RocketLeague.Models
{
    public class CarCreate
    {
        public string CarName { get; set; }
        public string CarColor { get; set; }
        public Rarity CarRarity { get; set; }
    }
}
