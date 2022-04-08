using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PrecastConcretePlantDataBaseImplement;

namespace PrecastConcretePlantDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new PrecastConcretePlantDatabase();
            return context.Orders
                .Include(rec => rec.Reinforced)
                .Select(rec => new OrderViewModel 
                {
                    Id = rec.Id,
                    ReinforcedId = rec.ReinforcedId,
                    ReinforcedName = context.Reinforceds.FirstOrDefault(tc => tc.Id == rec.ReinforcedId).ReinforcedName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                })
                .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null) return null;
            var context = new PrecastConcretePlantDatabase();
            return context.Orders.Include(rec => rec.Reinforced)
                .Where(rec => rec.Id == model.Id
                || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) 
                || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date))
                .Select(CreateModel)
                .ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null) return null;
            var context = new PrecastConcretePlantDatabase();
            var order = context.Orders.Include(rec => rec.Reinforced).FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            var order = new Order
            {
                ReinforcedId = model.ReinforcedId,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement
            };
            context.Orders.Add(order);
            CreateModel(order);
            context.SaveChanges();
        }
        public void Update(OrderBindingModel model)
        {
            var context = new PrecastConcretePlantDatabase();
            var order = context.Orders.FirstOrDefault(recc => recc.Id == model.Id);
            if (order == null) throw new Exception("Элемент не найден");
            order.ReinforcedId = model.ReinforcedId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            CreateModel(order);
            context.SaveChanges();
        }
        public void Delete(OrderBindingModel model)
        {
            var context = new PrecastConcretePlantDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else throw new Exception("Элемент не найден");
        }
        private OrderViewModel CreateModel(Order order) 
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ReinforcedId = order.ReinforcedId,
                ReinforcedName = order.Reinforced.ReinforcedName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
            };
        }
    }
}
