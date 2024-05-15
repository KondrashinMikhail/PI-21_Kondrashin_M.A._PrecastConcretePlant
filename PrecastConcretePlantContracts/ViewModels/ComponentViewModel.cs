using PrecastConcretePlantContracts.Attributes;
using System.ComponentModel;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }
        [Column(title: "Название компонента", width: 100)]
        public string ComponentName { get; set; }
    }
}
