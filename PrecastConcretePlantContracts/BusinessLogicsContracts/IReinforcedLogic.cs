using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.ViewModels;
using System.Collections.Generic;

namespace PrecastConcretePlantContracts.BusinessLogicsContracts
{
    public interface IReinforcedLogic
    {
        List<ReinforcedViewModel> Read(ReinforcedBindingModel model);
        void CreateOrUpdate(ReinforcedBindingModel model);
        void Delete(ReinforcedBindingModel model);
    }
}
