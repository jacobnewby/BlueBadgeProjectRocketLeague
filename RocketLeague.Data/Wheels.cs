using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RocketLeague.Data.Car;

namespace RocketLeague.Data
{
    public class Wheels
    {
        [Key]
        public int WheelsID { get; set; }
        public Guid OwnerID { get; set; }
        [Required]
        public string WheelsName { get; set; }
        [Required]
        public string WheelsColor { get; set; }
        [Required]
        public Rarity WheelsRarity { get; set; }
    }
}
