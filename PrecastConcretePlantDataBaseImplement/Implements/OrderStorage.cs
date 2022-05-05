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
                .Include(rec => rec.Implementer)
                .Select(CreateModel)
                .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null) return null;
            var context = new PrecastConcretePlantDatabase();
            return context.Orders
                .Include(rec => rec.Reinforced)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
               (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
               (model.ClientId.HasValue && rec.ClientId == model.ClientId) || 
               (model.SearchStatus.HasValue && model.SearchStatus.Value == rec.Status) ||
               (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && model.Status == rec.Status))
                .Select(CreateModel)
                .ToList();

        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null) return null;
            var context = new PrecastConcretePlantDatabase();
            var order = context.Orders
                .Include(rec => rec.Reinforced)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                .FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            var context = new PrecastConcretePlantDatabase();
            var order = new Order
            {
                ReinforcedId = model.ReinforcedId,
                ClientId = (int)model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement,
                ImplementerId = model.ImplementerId
            };
            context.Orders.Add(order);
            context.SaveChanges();
            CreateModel(model, order);
            context.SaveChanges();
        }
        public void Update(OrderBindingModel model)
        {
            var context = new PrecastConcretePlantDatabase();
            var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order == null) throw new Exception("Элемент не найден");
            order.ReinforcedId = model.ReinforcedId;
            order.ClientId = (int) model.ClientId;
            order.ImplementerId = model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            CreateModel(model, order);
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
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null) return null;
            var context = new PrecastConcretePlantDatabase();
            var element = context.Reinforceds.FirstOrDefault(rec => rec.Id == model.ReinforcedId);
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
        private OrderViewModel CreateModel(Order order) 
        {
            var context = new PrecastConcretePlantDatabase();
            var reinforced = context.Reinforceds.FirstOrDefault(rec => rec.Id == order.ReinforcedId);
            var implementerName = "";
            if (context.Implementers.FirstOrDefault(rec => rec.Id == order.ImplementerId) != null)
                implementerName = context.Implementers.FirstOrDefault(rec => rec.Id == order.ImplementerId).ImplementerName;
            return new OrderViewModel
            {
                Id = order.Id,
                ReinforcedId = order.ReinforcedId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                ClientName = context.Clients.Include(rec => rec.Orders).FirstOrDefault(rec1 => rec1.Id == order.ClientId).ClientName,
                ReinforcedName = reinforced.ReinforcedName,
                ImplementerName = implementerName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
