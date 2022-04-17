using System;
using PrecastConcretePlantContracts.Enums;
using System.ComponentModel;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ReinforcedId { get; set; }
        [DisplayName("Железобетонные изделия")]
        public string ReinforcedName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
