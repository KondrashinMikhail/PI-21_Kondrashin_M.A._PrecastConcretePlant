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
                .Include(rec => rec.ClientId)
                .Include(rec => rec.ImplementerId)
                .FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            var order = new Order
            {
                ReinforcedId = model.ReinforcedId,
                ClientId = (int)model.ClientId,
                ImplementerId = model.ImplementerId,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement,
                SearchStatus = model.SearchStatus
            };
            context.Orders.Add(order);
            CreateModel(model, order);
        }
        public void Update(OrderBindingModel model)
        {
            var context = new PrecastConcretePlantDatabase();
            var order = context.Orders.FirstOrDefault(recc => recc.Id == model.Id);
            if (order == null) throw new Exception("Элемент не найден");
            order.ReinforcedId = model.ReinforcedId;
            order.ClientId = (int) model.ClientId;
            order.ImplementerId = model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.SearchStatus = model.SearchStatus;
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
            var reinforced = context.Reinforceds.FirstOrDefault(rec => rec.Id == model.ReinforcedId);
            var implementer = context.Implementers.FirstOrDefault(rec => rec.Id == model.ImplementerId);
            if (reinforced != null)
            {
                if (reinforced.Orders == null) reinforced.Orders = new List<Order>();
                if (implementer != null) if (implementer.Orders == null) implementer.Orders = new List<Order>();
                reinforced.Orders.Add(order);
                context.Reinforceds.Update(reinforced);
                context.Implementers.Update(implementer);
                context.SaveChanges();
            }
            else throw new Exception("Элемент не найден");
            return order;
        }
        private OrderViewModel CreateModel(Order order) 
        {
            var context = new PrecastConcretePlantDatabase();
            var reinforced = context.Reinforceds.FirstOrDefault(rec => rec.Id == order.ReinforcedId);
            var implementer = context.Implementers.FirstOrDefault(rec => rec.Id == order.ImplementerId);
            return new OrderViewModel
            {
                Id = order.Id,
                ReinforcedId = order.ReinforcedId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                ClientName = context.Clients.Include(rec => rec.Orders).FirstOrDefault(rec1 => rec1.Id == order.ClientId).ClientName,
                ReinforcedName = reinforced.ReinforcedName,
                ImplementerName = implementer.ImplementerName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                SearchStatus = order.SearchStatus
            };
        }
    }
}
