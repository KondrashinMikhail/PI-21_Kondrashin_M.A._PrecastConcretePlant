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
        [Column(title: "Отправитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SenderName { get; set; }
        [Column(title: "Дата письма", gridViewAutoSize: GridViewAutoSize.Fill, dateFormat: "d")]
        public DateTime DateDelivery { get; set; }
        [Column(title: "Заголовок", width: 100)]
        public string Subject { get; set; }
        [Column(title: "Текст", width: 100)]
        public string Body { get; set; }
        [Column(title: "Просмотрено", width: 200)]
        public bool Viewed { get; set; }
        [Column(title: "Ответ", width: 200)]
        public string Reply { get; set; }
    }
}
