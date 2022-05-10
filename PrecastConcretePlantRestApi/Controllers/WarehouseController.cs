using Microsoft.AspNetCore.Mvc;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.ViewModels;

namespace PrecastConcretePlantRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseLogic _warehouseLogic;
        private readonly IComponentLogic _componentLogic;
        public WarehouseController(IWarehouseLogic warehouseLogic, IComponentLogic componentLogic) 
        { 
            _warehouseLogic = warehouseLogic;
            _componentLogic = componentLogic;
        }
        [HttpGet]
        public List<WarehouseViewModel> GetWarehouseList() => _warehouseLogic.Read(null)?.ToList();
        [HttpGet]
        public WarehouseViewModel GetWarehouse(int warehouseId) => _warehouseLogic.Read(new WarehouseBindingModel { Id = warehouseId })?[0];
        [HttpPost]
        public void CreateOrUpdateWarehouse(WarehouseBindingModel model) => _warehouseLogic.CreateOrUpdate(model);
        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => _warehouseLogic.Delete(model);
        [HttpPost]
        public void AddComponentToWarehouse(WarehouseComponentBindingModel model)
            => _warehouseLogic.AddComponent(new WarehouseBindingModel { Id = model.Id }, model.ComponentId, model.Count);
        [HttpGet]
        public List<ComponentViewModel> GetComponentList() => _componentLogic.Read(null)?.ToList();
    }
}
