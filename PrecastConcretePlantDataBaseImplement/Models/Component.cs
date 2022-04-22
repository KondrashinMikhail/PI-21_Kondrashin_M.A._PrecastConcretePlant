using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecastConcretePlantDatabaseImplement.Models
{
    public class Component
    {
        public int Id { get; set; }
        [Required]
        public string ComponentName { get; set; }
        [ForeignKey("ComponentId")]
        public virtual List<ReinforcedComponent> ReinforcedComponents { get; set; }
        [ForeignKey("ComponentId")]
        public virtual List<WarehouseComponent> WarehouseComponents { get; set; }
    }
}
