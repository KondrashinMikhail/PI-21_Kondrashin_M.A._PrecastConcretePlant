using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantBusinessLogic.BusinessLogics
{
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly IImplementerStorage _implementerStorage;
        public ImplementerLogic(IImplementerStorage implementerStorage) => _implementerStorage = implementerStorage;
        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            if (model == null) return _implementerStorage.GetFullList();
            if (model.Id != null) return new List<ImplementerViewModel> { _implementerStorage.GetElement(model) };
            return _implementerStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            var element = _implementerStorage.GetElement(new ImplementerBindingModel { ImplementerName = model.ImplementerName });
            if (element != null && element.Id != model.Id) throw new Exception("Уже есть исполнитель с таким названием");
            if (model.Id != null) _implementerStorage.Update(model);
            else _implementerStorage.Insert(model);
        }
        public void Delete(ImplementerBindingModel model)
        {
            var element = _implementerStorage.GetElement(new ImplementerBindingModel { Id = model.Id });
            if (element == null) throw new Exception("Элемент не найден");
            _implementerStorage.Delete(model);
        }
    }
}
