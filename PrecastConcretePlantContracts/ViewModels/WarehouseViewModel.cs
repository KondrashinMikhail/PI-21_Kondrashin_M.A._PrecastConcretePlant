using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }
        [DisplayName("Полное имя ответственного за склад")]
        public string WarehouseManagerFullName { get; set; }
        [DisplayName("Дата создания склада")]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
