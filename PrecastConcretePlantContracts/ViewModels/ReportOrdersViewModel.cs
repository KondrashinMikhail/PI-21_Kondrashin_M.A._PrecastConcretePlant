using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string ReinforcedName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
    }
}
