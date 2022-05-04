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
        public int Id { get; set; }
        [DisplayName("ФИО клиента")]
        public string ClientName { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
