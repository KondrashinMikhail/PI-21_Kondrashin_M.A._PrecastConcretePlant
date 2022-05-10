using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class WarehouseViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]

        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }
        [DataMember]

        [DisplayName("Полное имя ответственного за склад")]
        public string WarehouseManagerFullName { get; set; }
        [DataMember]

        [DisplayName("Дата создания склада")]
        public DateTime DateCreate { get; set; }
        [DataMember]

        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
