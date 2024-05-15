using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantFileImplement.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseManagerFullName { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, int> WarehouseComponents { get; set; }
    }
}
