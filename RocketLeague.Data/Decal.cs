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
    public class Decal
    {
        [Key]
        public int DecalID { get; set; }
        public Guid OwnerID { get; set; }
        [Required]
        public string DecalName { get; set; }
        [Required]
        public string DecalColor { get; set; }
        [Required]
        public Rarity DecalRarity { get; set; }
    }
}
