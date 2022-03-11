﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrecastConcretePlantContracts.Enums;

namespace PrecastConcretePlantDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ReinforcedId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Reinforced Reinforced { get; set; }
    }
}