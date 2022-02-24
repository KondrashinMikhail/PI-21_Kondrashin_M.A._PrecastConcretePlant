using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantListImplement.Models;

namespace PrecastConcretePlantListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;
        public OrderStorage() => source = DataListSingleton.GetInstance();
        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();
            foreach (var order in source.Orders) result.Add(CreateModel(order));
            return result;
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null) return null;
            var result = new List<OrderViewModel>();
            foreach (var order in source.Orders) if (order.Id > model.Id) result.Add(CreateModel(order));
            return result;
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null) return null;
            foreach (var order in source.Orders) if (order.Id == model.Id) return CreateModel(order);
            return null;
        }
        public void Insert(OrderBindingModel model)
        {
            var tempOrder = new Order { Id = 1, Status = 0 };
            foreach (var order in source.Orders) if (order.Id >= tempOrder.Id) tempOrder.Id = order.Id + 1;
            source.Orders.Add(CreateModel(model, tempOrder));
        }
        public void Update(OrderBindingModel model)
        {
            Order tempOrder = null;
            foreach (var order in source.Orders) if (order.Id == model.Id) tempOrder = order;
            if (tempOrder == null) throw new Exception("Элемента не найлен");
            CreateModel(model, tempOrder);
        }
        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private OrderViewModel CreateModel(Order order)
        {
            string reinforcedName = "";
            foreach (var reinforced in source.Reinforceds)
            {
                if (order.ReinforcedId == reinforced.Id)
                {
                    reinforcedName = reinforced.ReinforcedName;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                ReinforcedId = order.ReinforcedId,
                ReinforcedName = reinforcedName,
                Count = order.Count,
                Status = order.Status.ToString(),
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
            };
        }
        private static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ReinforcedId = model.ReinforcedId;
            order.Status = model.Status;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
