using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using PrecastConcretePlantContracts.Attributes;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class WarehouseViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Название склада", width: 100)]
        public string WarehouseName { get; set; }
        [DataMember]
        [Column(title: "Полное имя ответственного за склад", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string WarehouseManagerFullName { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 100, dateFormat: "d")]
        public DateTime DateCreate { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
