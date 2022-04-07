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
        public MainController(IOrderLogic order, IReinforcedLogic reinforced)
        {
            _order = order;
            _reinforced = reinforced;
        }
        [HttpGet]
        public List<ReinforcedViewModel> GetReinforcedList() => _reinforced.Read(null)?.ToList();
        [HttpGet]
        public ReinforcedViewModel GetReinforced(int reinforcedId) => _reinforced.Read(new ReinforcedBindingModel
        { Id = reinforcedId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _order.CreateOrder(model);
    }
}
