using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrecastConcretePlantFileImplement.Implements
{
    public class ReinforcedStorage : IReinforcedStorage
    {
        private readonly FileDataListSingleton source;
        public ReinforcedStorage() => source = FileDataListSingleton.GetInstance();
        public List<ImplemenerViewModel> GetFullList()
        {
            return source.Reinforceds
            .Select(CreateModel)
            .ToList();
        }
        public List<ImplemenerViewModel> GetFilteredList(ReinforcedBindingModel model)
        {
            if (model == null) return null;
            return source.Reinforceds
            .Where(rec => rec.ReinforcedName.Contains(model.ReinforcedName))
            .Select(CreateModel)
            .ToList();
        }
        public ImplemenerViewModel GetElement(ReinforcedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var reinforced = source.Reinforceds.FirstOrDefault(rec => rec.ReinforcedName == model.ReinforcedName || rec.Id
           == model.Id);
            return reinforced != null ? CreateModel(reinforced) : null;
        }
        public void Insert(ReinforcedBindingModel model)
        {
            int maxId = source.Reinforceds.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Reinforced
            {
                Id = maxId + 1,
                ReinforcedComponents = new Dictionary<int, int>()
            };
            source.Reinforceds.Add(CreateModel(model, element));
        }
        public void Update(ReinforcedBindingModel model)
        {
            var element = source.Reinforceds.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) throw new Exception("Элемент не найден");
            CreateModel(model, element);
        }
        public void Delete(ReinforcedBindingModel model)
        {
            Reinforced element = source.Reinforceds.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null) source.Reinforceds.Remove(element);
            else throw new Exception("Элемент не найден");
        }
        private static Reinforced CreateModel(ReinforcedBindingModel model, Reinforced reinforced)
        {
            reinforced.ReinforcedName = model.ReinforcedName;
            reinforced.Price = model.Price;
            foreach (var key in reinforced.ReinforcedComponents.Keys.ToList())
            {
                if (!model.ReinforcedComponents.ContainsKey(key)) reinforced.ReinforcedComponents.Remove(key);
            }
            foreach (var component in model.ReinforcedComponents)
            {
                if (reinforced.ReinforcedComponents.ContainsKey(component.Key)) reinforced.ReinforcedComponents[component.Key] = model.ReinforcedComponents[component.Key].Item2;
                else reinforced.ReinforcedComponents.Add(component.Key, model.ReinforcedComponents[component.Key].Item2);
            }
            return reinforced;
        }
        private ImplemenerViewModel CreateModel(Reinforced reinforced)
        {
            return new ImplemenerViewModel
            {
                Id = reinforced.Id,
                ReinforcedName = reinforced.ReinforcedName,
                Price = reinforced.Price,
                ReinforcedComponents = reinforced.ReinforcedComponents.ToDictionary(recPC => recPC.Key, recPC => (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
