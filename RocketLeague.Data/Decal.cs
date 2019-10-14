using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string DecalRarity { get; set; }
    }
}
