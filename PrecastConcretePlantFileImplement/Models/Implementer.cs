using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantFileImplement.Models
{
    public class Implementer
    {
        public int Id { get; set; }
        public string ImplementerName { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
    }
}
