using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantContracts.BindingModels
{
    public class MessageInfoBindingModel
    {
        public int? ClientId { get; set; }
        public string MessageId { get; set; }
        public string FromMailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateDelivery { get; set; }
        public bool Viewed { get; set; }
        public string Reply { get; set; }
        public int? ToSkip { get; set; }
        public int? ToTake { get; set; }
    }
}
