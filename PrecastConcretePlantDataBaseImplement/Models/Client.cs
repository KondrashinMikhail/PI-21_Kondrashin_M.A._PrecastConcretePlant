using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantDatabaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [ForeignKey("ClientId")]
        public List<Order> Orders { get; set; }
    }
}
