using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeague.Data
{
    public class Car
    {
        public enum Rarity
        {
            Rare,
            [Description("Very Rare")]
            VeryRare,
            Import,
            Exotic,
            [Description("Black Market")]
            BlackMarket,
        }

        [Key]
        public int CarID { get; set; }
        public Guid OwnerID { get; set; }
        [Required]
        public string CarName { get; set; }
        [Required]
        public string CarColor { get; set; }
        [Required]
        public Rarity CarRarity { get; set; }
    }
}
