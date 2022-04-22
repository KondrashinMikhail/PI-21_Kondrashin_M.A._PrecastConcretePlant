using System.ComponentModel.DataAnnotations;


namespace PrecastConcretePlantDatabaseImplement.Models
{
    public class ReinforcedComponent
    {
        public int Id { get; set; }
        public int ReinforcedId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Reinforced Reinforced { get; set; }
    }
}
