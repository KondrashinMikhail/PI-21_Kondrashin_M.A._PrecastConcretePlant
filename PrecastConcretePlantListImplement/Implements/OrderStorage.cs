﻿using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.Enums;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantListImplement.Models;

namespace PrecastConcretePlantListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;
        public OrderStorage() => source = DataListSingleton.GetInstance();
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null) return null;
            foreach (var order in source.Orders)
                if (order.Id == model.Id) return CreateModel(order);
            return null;
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null) return null;
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (order.Id.Equals(model.Id) || (!model.DateFrom.HasValue && !model.DateTo.HasValue && order.DateCreate.Date == model.DateCreate.Date) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate.Date >= model.DateFrom.Value.Date && order.DateCreate.Date <= model.DateTo.Value.Date) ||
                    (model.ClientId.HasValue && order.ClientId == model.ClientId) ||
                    (model.SearchStatus.HasValue && model.SearchStatus.Value == order.Status) || 
                    (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && model.Status == OrderStatus.Выполняется))
                    result.Add(CreateModel(order));
            }
            return result;
        }
        public List<OrderViewModel> GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders) result.Add(CreateModel(order));
            return result;
        }
        public void Insert(OrderBindingModel model)
        {
            Order tempOrder = new Order { Id = 1 };
            foreach (var order in source.Orders)
                if (order.Id >= tempOrder.Id) tempOrder.Id = order.Id + 1;
            source.Orders.Add(CreateModel(model, tempOrder));
        }
        public void Update(OrderBindingModel model)
        {
            Order tempOrder = null;
            foreach (var order in source.Orders)
                if (order.Id == model.Id) tempOrder = order;
            if (tempOrder == null) throw new Exception("Элемент не найден");
            CreateModel(model, tempOrder);
        }
        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
                if (source.Orders[i].Id == model.Id)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            throw new Exception("Элемент не найден");
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ReinforcedId = model.ReinforcedId;
            order.ClientId = (int) model.ClientId;
            order.ImplementerId = (int) model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private OrderViewModel CreateModel(Order order)
        {
            string reinforcedName = null;
            foreach (var reinforced in source.Reinforceds)
                if (reinforced.Id == order.ReinforcedId)
                {
                    reinforcedName = reinforced.ReinforcedName;
                    break;
                }
            string clientName = null;
            foreach (var client in source.Clients)
                if (client.Id == order.ReinforcedId) clientName = client.ClientName;
            string implementerName = null;
            foreach (var implementer in source.Implementers)
                if (implementer.Id == order.ImplementerId) implementerName = implementer.ImplementerName;
            return new OrderViewModel
            {
                Id = order.Id,
                ReinforcedId = order.ReinforcedId,
                ReinforcedName = reinforcedName,
                ClientId = order.ClientId,
                ClientName = clientName,
                ImplementerId = order.ImplementerId,
                ImplementerName = implementerName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
            };
        }
    }
}
