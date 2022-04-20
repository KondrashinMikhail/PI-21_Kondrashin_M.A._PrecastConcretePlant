using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantListImplement.Models;

namespace PrecastConcretePlantListImplement.Implements
{
    public class ReinforcedStorage : IReinforcedStorage
    {
        private readonly DataListSingleton source;
        public ReinforcedStorage() => source = DataListSingleton.GetInstance();
        public List<ImplemenerViewModel> GetFullList()
        {
            var result = new List<ImplemenerViewModel>();
            foreach (var component in source.Reinforceds) result.Add(CreateModel(component));
            return result;
        }
        public List<ImplemenerViewModel> GetFilteredList(ReinforcedBindingModel model)
        {
            if (model == null) return null;
            var result = new List<ImplemenerViewModel>();
            foreach (var reinforced in source.Reinforceds) if (reinforced.ReinforcedName.Contains(model.ReinforcedName)) result.Add(CreateModel(reinforced));
            return result;
        }
        public ImplemenerViewModel GetElement(ReinforcedBindingModel model)
        {
            if (model == null) return null;
            foreach (var reinforced in source.Reinforceds) if (reinforced.Id == model.Id || reinforced.ReinforcedName == model.ReinforcedName) return CreateModel(reinforced);
            return null;
        }
        public void Insert(ReinforcedBindingModel model)
        {
            var tempReinforced = new Reinforced { Id = 1, ReinforcedComponents = new Dictionary<int, int>() };
            foreach (var reinforced in source.Reinforceds) if (reinforced.Id >= tempReinforced.Id) tempReinforced.Id = reinforced.Id + 1;
            source.Reinforceds.Add(CreateModel(model, tempReinforced));
        }
        public void Update(ReinforcedBindingModel model)
        {
            Reinforced tempReinforced = null;
            foreach (var reinforced in source.Reinforceds) if (reinforced.Id == model.Id) tempReinforced = reinforced;
            if (tempReinforced == null) throw new Exception("Элемент не найден");
            CreateModel(model, tempReinforced);
        }
        public void Delete(ReinforcedBindingModel model)
        {
            for (int i = 0; i < source.Reinforceds.Count; ++i)
            {
                if (source.Reinforceds[i].Id == model.Id)
                {
                    source.Reinforceds.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Reinforced CreateModel(ReinforcedBindingModel model, Reinforced reinforced)
        {
            reinforced.ReinforcedName = model.ReinforcedName;
            reinforced.Price = model.Price;
            foreach (var key in reinforced.ReinforcedComponents.Keys.ToList()) if (!model.ReinforcedComponents.ContainsKey(key)) reinforced.ReinforcedComponents.Remove(key);
            foreach (var component in model.ReinforcedComponents)
            {
                if (reinforced.ReinforcedComponents.ContainsKey(component.Key)) reinforced.ReinforcedComponents[component.Key]
                        = model.ReinforcedComponents[component.Key].Item2;
                else reinforced.ReinforcedComponents.Add(component.Key, model.ReinforcedComponents[component.Key].Item2);
            }
            return reinforced;
        }
        private ImplemenerViewModel CreateModel(Reinforced reinforced)
        {
            var reinforcedComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in reinforced.ReinforcedComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                reinforcedComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new ImplemenerViewModel
            {
                Id = reinforced.Id,
                ReinforcedName = reinforced.ReinforcedName,
                Price = reinforced.Price,
                ReinforcedComponents = reinforcedComponents
            };
        }
    }
}
