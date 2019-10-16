using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RocketLeague.Data.Car;

namespace RocketLeague.Models
{
    public class WheelsCreate
    {
        public string WheelsName { get; set; }
        public string WheelsColor { get; set; }
        public Rarity WheelsRarity { get; set; }
    }
}
