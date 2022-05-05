using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.Enums;
using PrecastConcretePlantContracts.ViewModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PrecastConcretePlantBusinessLogic.BusinessLogics
{
    public class WorkModeling : IWorkProcess
    {
        private IOrderLogic _orderLogic;
        private readonly Random random;
        public WorkModeling() => random = new Random(1000);
        public void DoWork(IImplementerLogic implementerLogic, IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
            var implementers = implementerLogic.Read(null);
            ConcurrentBag<OrderViewModel> orders = new (_orderLogic.Read(new OrderBindingModel { SearchStatus = OrderStatus.Принят }));
            foreach (var implementer in implementers) Task.Run(async () => await WorkerWorkAsync(implementer, orders));
        }
        private async Task WorkerWorkAsync(ImplementerViewModel implementer, ConcurrentBag<OrderViewModel> orders)
        {
            var runOrders = await Task.Run(() => _orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id,
                Status = OrderStatus.Выполняется
            }));
            foreach (var order in runOrders)
            {
                Thread.Sleep(implementer.WorkingTime * random.Next(1, 5) * order.Count);
                _orderLogic.FinishOrder(new ChangeStatusBindingModel { OrderId = order.Id, ImplementerId = implementer.Id });
                Thread.Sleep(implementer.PauseTime);
            }
            var needMaterialOrders = await Task.Run(() => _orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id,
                Status = OrderStatus.Требуются_материалы
            }));
            foreach (var order in needMaterialOrders) 
            {
                _orderLogic.TakeOrderInWork(new ChangeStatusBindingModel { OrderId = order.Id });
                var processedOrder = _orderLogic.Read(new OrderBindingModel { Id = order.Id })[0];
                if (processedOrder.Status != OrderStatus.Требуются_материалы)
                {
                    Thread.Sleep(implementer.WorkingTime * random.Next(1, 5) * order.Count);
                    _orderLogic.FinishOrder(new ChangeStatusBindingModel { OrderId = order.Id });
                    Thread.Sleep(implementer.PauseTime);
                }
            }
            await Task.Run(() =>
            {
                while (!orders.IsEmpty)
                {
                    if (orders.TryTake(out OrderViewModel order))
                    {
                        _orderLogic.TakeOrderInWork(new ChangeStatusBindingModel
                        { 
                            OrderId = order.Id, 
                            ImplementerId = implementer.Id 
                        });
                        Thread.Sleep(implementer.WorkingTime * random.Next(1, 5) * order.Count);
                        _orderLogic.FinishOrder(new ChangeStatusBindingModel 
                        {
                            OrderId = order.Id,
                            ImplementerId = implementer.Id
                        });
                        Thread.Sleep(implementer.PauseTime);
                    }
                }
            });
        }
    }
}
