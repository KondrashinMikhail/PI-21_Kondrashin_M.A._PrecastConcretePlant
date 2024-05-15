using System.Collections.Generic;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.ViewModels;

namespace PrecastConcretePlantContracts.BusinessLogicsContracts
{
    public interface IWarehouseLogic
    {
        List<WarehouseViewModel> Read(WarehouseBindingModel model);
        void CreateOrUpdate(WarehouseBindingModel model);
        void AddComponent(WarehouseBindingModel model, int componentId, int count);
        void Delete(WarehouseBindingModel model);
    }
}
