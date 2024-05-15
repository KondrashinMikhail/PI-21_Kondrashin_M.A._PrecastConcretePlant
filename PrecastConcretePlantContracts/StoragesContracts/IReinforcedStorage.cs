using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.ViewModels;
using System.Collections.Generic;

namespace PrecastConcretePlantContracts.StoragesContracts
{
    public interface IReinforcedStorage
    {
        List<ImplemenerViewModel> GetFullList();
        List<ImplemenerViewModel> GetFilteredList(ReinforcedBindingModel model);
        ImplemenerViewModel GetElement(ReinforcedBindingModel model);
        void Insert(ReinforcedBindingModel model);
        void Update(ReinforcedBindingModel model);
        void Delete(ReinforcedBindingModel model);
    }
}
