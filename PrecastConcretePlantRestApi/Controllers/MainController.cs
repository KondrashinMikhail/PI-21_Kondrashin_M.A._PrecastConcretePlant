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
        private readonly int mailsNum = 5;
        public MainController(IOrderLogic order, IReinforcedLogic reinforced, IMessageInfoLogic message)
        {
            _order = order;
            _reinforced = reinforced;
            _message = message;
        }
        [HttpGet]
        public List<ReinforcedViewModel> GetReinforcedList() => _reinforced.Read(null)?.ToList();
        [HttpGet]
        public ReinforcedViewModel GetReinforced(int reinforcedId) => _reinforced.Read(new ReinforcedBindingModel { Id = reinforcedId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        [HttpGet]
        public (List<MessageInfoViewModel>, bool) GetMessages(int clientId, int page)
        {
            var list = _message.Read(new MessageInfoBindingModel
            {
                ClientId = clientId,
                ToSkip = (page - 1) * mailsNum,
                ToTake = mailsNum + 1
            }).ToList();
            var hasNext = !(list.Count() <= mailsNum);
            return (list.Take(mailsNum).ToList(), hasNext);
        }
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}
