using System.Collections.Generic;

namespace PrecastConcretePlantListImplement.Models
{
    public class Reinforced
    {
        public int Id { get; set; }
        public string ReinforcedName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> ReinforcedComponents { get; set; }
    }
}
