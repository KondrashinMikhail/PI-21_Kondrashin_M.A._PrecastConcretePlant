using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecastConcretePlantDatabaseImplement.Models
{
    public class Reinforced
    {
        public int Id { get; set; }
        [Required]
        public string ReinforcedName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("ReinforcedId")]
        public virtual List<ReinforcedComponent> ReinforcedComponents { get; set; }
        [ForeignKey("ReinforcedId")]
        public virtual List<Order> Orders { get; set; }
    }
}
