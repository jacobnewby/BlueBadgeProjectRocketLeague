using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeague.Data
{
    public class Build
    {
        [Key]
        public int BuildID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        [Required]
        public string BuildName { get; set; }
        [ForeignKey("Car")]
        public int CarID { get; set; }
        public virtual Car Car { get; set; }
        [ForeignKey("Decal")]
        public int DecalID { get; set; }
        public virtual Decal Decal { get; set; }
        [ForeignKey("Wheels")]
        public int WheelsID { get; set; }
        public virtual Wheels Wheels { get; set; }
        [ForeignKey("Goal")]
        public int GoalID { get; set; }
        public virtual Goal Goal { get; set; }
        
    }
}
