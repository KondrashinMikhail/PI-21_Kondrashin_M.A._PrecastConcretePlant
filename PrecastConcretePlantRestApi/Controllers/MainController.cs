using Microsoft.AspNetCore.Mvc;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.ViewModels;

namespace PrecastConcretePlantRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IReinforcedLogic _reinforced;
        private readonly IMessageInfoLogic _message;
        public MainController(IOrderLogic order, IReinforcedLogic reinforced, IMessageInfoLogic message)
        {
            _order = order;
            _reinforced = reinforced;
            _message = message;
        }
        [HttpGet]
        public List<ImplemenerViewModel> GetReinforcedList() => _reinforced.Read(null)?.ToList();
        [HttpGet]
        public ImplemenerViewModel GetReinforced(int reinforcedId) => _reinforced.Read(new ReinforcedBindingModel { Id = reinforcedId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) => _message.Read(new MessageInfoBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}
