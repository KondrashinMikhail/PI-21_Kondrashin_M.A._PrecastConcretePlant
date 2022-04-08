using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class ReportReinforcedComponentViewModel
    {
        public List<Tuple<string, int>> Components { get; set; }
        public int TotalCount { get; set; }
        public string ReinforcedName { get; set; }
    }
}
