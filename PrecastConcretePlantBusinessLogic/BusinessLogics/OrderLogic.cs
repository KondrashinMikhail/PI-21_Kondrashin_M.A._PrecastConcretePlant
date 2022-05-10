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
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят,
                DateCreate = DateTime.Now
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            OrderViewModel order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order.Status == OrderStatus.Принят || order.Status == OrderStatus.Требуются_материалы)
            {
                var orderBinding = new OrderBindingModel
                {
                    Id = order.Id,
                    ReinforcedId = order.ReinforcedId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    ClientId = order.ClientId
                };
                if (!_warehouseStorage.CheckComponents(_reinforcedStorage.GetElement(new ReinforcedBindingModel { Id = order.ReinforcedId }).ReinforcedComponents, order.Count))
                    orderBinding.Status = OrderStatus.Требуются_материалы;
                else
                {
                    orderBinding.DateImplement = DateTime.Now;
                    orderBinding.Status = OrderStatus.Выполняется;
                    orderBinding.ImplementerId = model.ImplementerId;
                }
                _orderStorage.Update(orderBinding);
            }
            else throw new Exception("Заказ еще не принят");
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order.Status == OrderStatus.Выполняется)
                _orderStorage.Update(new OrderBindingModel
                {
                    Id = order.Id,
                    ReinforcedId = order.ReinforcedId,
                    ClientId = order.ClientId,
                    ImplementerId = order.ImplementerId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    Status = OrderStatus.Готов
                });
            else throw new Exception("Заказ не в статусе 'Выполняется'");
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
                    ClientId = tempModel.ClientId,
                    ImplementerId = model.ImplementerId,
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
