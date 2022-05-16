using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecastConcretePlantContracts.Attributes;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class MessageInfoViewModel
    {
        [Column(title: "Номер", width: 100)]
        public string MessageId { get; set; }
        [Column(title: "Отправитель", width: 100)]
        public string SenderName { get; set; }
        [Column(title: "Дата письма", width: 100)]
        public DateTime DateDelivery { get; set; }
        [Column(title: "Заголовок", width: 100)]
        public string Subject { get; set; }
        [Column(title: "Текст", width: 100)]
        public string Body { get; set; }
        [DisplayName("Просмотрено")]
        public bool Viewed { get; set; }
        [DisplayName("Ответ")]
        public string Reply { get; set; }
    }
}
