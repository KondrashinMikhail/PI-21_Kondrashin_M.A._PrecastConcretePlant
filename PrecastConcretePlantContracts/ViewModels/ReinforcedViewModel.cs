using PrecastConcretePlantContracts.Attributes;
using System.Collections.Generic;
using System.ComponentModel;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class ImplemenerViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }
        [Column(title: "Название железобетонного изделия", width: 100)]
        public string ReinforcedName { get; set; }
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ReinforcedComponents { get; set; }
    }
}
