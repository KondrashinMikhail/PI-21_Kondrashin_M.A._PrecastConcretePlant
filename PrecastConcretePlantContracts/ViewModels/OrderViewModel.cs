using System;
using PrecastConcretePlantContracts.Enums;
using System.ComponentModel;
using PrecastConcretePlantContracts.Attributes;

namespace PrecastConcretePlantContracts.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ReinforcedId { get; set; }
        public int? ImplementerId { get; set; }
        [Column(title: "ФИО клиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientName { get; set; }
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerName { get; set; }
        [Column(title: "Название железобетонного изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ReinforcedName { get; set; }
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [Column(title: "Сумма", width: 100)]
        public decimal Sum { get; set; }
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }
        [Column(title: "Дата создани", width: 100)]
        public DateTime DateCreate { get; set; }
        [Column(title: "Дата исполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
    }
}
