using System.Collections.Generic;
using System.ComponentModel;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class ImplemenerViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название железобетонного изделия")]
        public string ReinforcedName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ReinforcedComponents { get; set; }
    }
}
