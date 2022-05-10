using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantDatabaseImplement.Models
{
    public class Implementer
    {
        public int Id { get; set; }
        public string ImplementerName { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
        [ForeignKey("ImplementerId")] 
        public virtual List<Order> Orders { get; set; }
    }
}
