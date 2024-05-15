using PrecastConcretePlantContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class ClientViewModel
    {
        [Column(title: "Номер", width:100)]
        public int Id { get; set; }
        [Column(title: "ФИО клиента", width: 100)]
        public string ClientName { get; set; }
        [Column(title: "Логин", width: 100)]
        public string Login { get; set; }
        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }
    }
}
