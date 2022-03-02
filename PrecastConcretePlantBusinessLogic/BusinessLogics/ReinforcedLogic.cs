using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using System;
using System.Collections.Generic;


namespace PrecastConcretePlantBusinessLogic.BusinessLogics
{
    public class ReinforcedLogic : IReinforcedLogic
    {
        private readonly IReinforcedStorage _reinforcedStorage;
        public ReinforcedLogic(IReinforcedStorage reinforcedStorage) => _reinforcedStorage = reinforcedStorage;
        public List<ReinforcedViewModel> Read(ReinforcedBindingModel model)
        {
            if (model == null) return _reinforcedStorage.GetFullList();
            if (model.Id.HasValue) return new List<ReinforcedViewModel> { _reinforcedStorage.GetElement(model) };
            return _reinforcedStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ReinforcedBindingModel model)
        {
            var element = _reinforcedStorage.GetElement(new ReinforcedBindingModel { ReinforcedName = model.ReinforcedName });
            if (element != null && element.Id != model.Id) throw new Exception("Уже есть пицца с таким названием");
            if (model.Id.HasValue) _reinforcedStorage.Update(model);
            else _reinforcedStorage.Insert(model);
        }
        public void Delete(ReinforcedBindingModel model)
        {
            var element = _reinforcedStorage.GetElement(new ReinforcedBindingModel { Id = model.Id });
            if (element == null) throw new Exception("Элемент не найден");
            _reinforcedStorage.Delete(model);
        }
    }
}
