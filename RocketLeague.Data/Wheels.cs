using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string WheelsRarity { get; set; }
    }
}
