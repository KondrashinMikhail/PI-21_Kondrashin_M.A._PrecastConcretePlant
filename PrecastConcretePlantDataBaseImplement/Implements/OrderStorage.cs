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
            PrecastConcretePlantDatabase context = new PrecastConcretePlantDatabase();
            return context.Orders.Include(rec => rec.Reinforced)
                .Where(rec => rec.ReinforcedId == model.ReinforcedId)
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
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null) return null;
            PrecastConcretePlantDatabase context = new PrecastConcretePlantDatabase();
            Order order = context.Orders
                .Include(rec => rec.Reinforced)
                .FirstOrDefault(rec => rec.ReinforcedId == model.ReinforcedId || rec.Id == model.Id);
            return order != null ? new OrderViewModel
            {
                Id = order.Id,
                ReinforcedId = order.ReinforcedId,
                ReinforcedName = context.Reinforceds.FirstOrDefault(rec => rec.Id == order.ReinforcedId)?.ReinforcedName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            } : null;
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
            CreateModel(order, context);
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
            CreateModel(order, context);
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
        private OrderViewModel CreateModel(Order order, PrecastConcretePlantDatabase context) 
        {
            return new OrderViewModel 
            {
                Id = order.Id,
                ReinforcedId = order.ReinforcedId,
                ReinforcedName = context.Reinforceds.FirstOrDefault(rec => rec.Id == order.ReinforcedId)?.ReinforcedName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null) return null;
            var context = new PrecastConcretePlantDatabase();
            Reinforced element = context.Reinforceds.FirstOrDefault(rec => rec.Id == model.ReinforcedId);
            if (element != null)
            {
                if (element.Orders == null) element.Orders = new List<Order>();
                element.Orders.Add(order);
                context.Reinforceds.Update(element);
                context.SaveChanges();
            }
            else throw new Exception("Элемент не найден");
            return order;
        }
    }
}
