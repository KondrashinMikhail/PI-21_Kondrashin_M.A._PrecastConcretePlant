using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrecastConcretePlantFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton source;
        public OrderStorage() => source = FileDataListSingleton.GetInstance();
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null) return null;
            return source.Orders
               .Where(rec => rec.ReinforcedId.ToString().Contains(model.ReinforcedId.ToString()) || ((!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
               (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date
               && rec.DateCreate.Date <= model.DateTo.Value.Date)))
               .Select(CreateModel)
               .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null) return null;
            return source.Orders
                .Where(rec => rec.ReinforcedId.ToString().Contains(model.ReinforcedId.ToString()) || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date
                && rec.DateCreate.Date <= model.DateTo.Value.Date) || (model.ClientId.HasValue && rec.ClientId == model.ClientId))
                .Select(CreateModel)
                .ToList();
        }
        public List<OrderViewModel> GetFullList() => source.Orders.Select(CreateModel).ToList();
        public void Insert(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            Order element = new Order { Id = maxId + 1 };
            source.Orders.Add(CreateModel(model, element));
        }
        public void Update(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) throw new Exception("Заказ не найден");
            CreateModel(model, element);
        }
        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null) source.Orders.Remove(element);
            else throw new Exception("Элемент не найден");
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ReinforcedId = model.ReinforcedId;
            order.ClientId = (int)model.ClientId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ClientName = source.Clients.FirstOrDefault(rec => rec.Id == order.ClientId)?.ClientName,
                ReinforcedId = order.ReinforcedId,
                ReinforcedName = source.Reinforceds.FirstOrDefault(x => x.Id == order.ReinforcedId)?.ReinforcedName,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                Status = order.Status,
                DateImplement = order.DateImplement
            };
        }
    }
}
