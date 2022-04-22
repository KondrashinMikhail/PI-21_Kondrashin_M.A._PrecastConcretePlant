using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using System;
using System.Collections.Generic;
using PrecastConcretePlantContracts.Enums;
namespace PrecastConcretePlantBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IWarehouseStorage _warehouseStorage;
        private readonly IReinforcedStorage _reinforcedStorage;
        private readonly IOrderStorage _orderStorage;
        public OrderLogic(IOrderStorage orderStorage, IReinforcedStorage reinforcedStorage, IWarehouseStorage warehouseStorage)
        {
            _orderStorage = orderStorage;
            _reinforcedStorage = reinforcedStorage;
            _warehouseStorage = warehouseStorage;
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null) return _orderStorage.GetFullList();
            if (model.Id.HasValue) return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            return _orderStorage.GetFilteredList(model);
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                ReinforcedId = model.ReinforcedId,
                Count = model.Count,
                Sum = model.Sum,
                Status = 0,
                DateCreate = DateTime.Now
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order.Status == OrderStatus.Принят)
            {
                if (!_warehouseStorage.CheckComponents(_reinforcedStorage.GetElement(new ReinforcedBindingModel { Id = order.ReinforcedId }).ReinforcedComponents, order.Count))
                    throw new Exception("На складах недостаточно компонентов");
                _orderStorage.Update(new OrderBindingModel
                {
                    Id = order.Id,
                    ReinforcedId = order.ReinforcedId,
                    Sum = order.Sum,
                    Status = OrderStatus.Выполняется,
                    Count = order.Count,
                    DateCreate = order.DateCreate,
                    DateImplement = DateTime.Now
                });
            }
            else throw new Exception("Заказ должен находиться в состоянии 'Принят'");
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            if (_orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId }).Status == OrderStatus.Выполняется)
            {
                var tempModel = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
                _orderStorage.Update(new OrderBindingModel
                {
                    Id = tempModel.Id,
                    ReinforcedId = tempModel.ReinforcedId,
                    Sum = tempModel.Sum,
                    Status = OrderStatus.Готов,
                    Count = tempModel.Count,
                    DateCreate = tempModel.DateCreate,
                    DateImplement = tempModel.DateImplement
                });
            }
            else throw new Exception("Заказ должен находиться в состоянии 'Выполняется'");
        }
        public void DeliveryOrder(ChangeStatusBindingModel model)
        {
            if (_orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId }).Status == OrderStatus.Готов)
            {
                var tempModel = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
                _orderStorage.Update(new OrderBindingModel
                {
                    Id = tempModel.Id,
                    ReinforcedId = tempModel.ReinforcedId,
                    Sum = tempModel.Sum,
                    Status = OrderStatus.Выдан,
                    Count = tempModel.Count,
                    DateCreate = tempModel.DateCreate,
                    DateImplement = tempModel.DateImplement
                });
            }
            else throw new Exception("Заказ должен находиться в состоянии 'Готов'");
        }
    }
}
