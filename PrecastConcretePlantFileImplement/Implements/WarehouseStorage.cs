using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantFileImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;
        public WarehouseStorage() => source = FileDataListSingleton.GetInstance();
        public List<WarehouseViewModel> GetFullList()
        {
            return source.Warehouses
                .Select(CreateModel)
                .ToList();
        }
        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null) return null;
            return source.Warehouses
                .Where(rec => rec.WarehouseName.Contains(model.WarehouseManagerFullName))
                .Select(CreateModel)
                .ToList();
        }
        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null) return null;
            var warehouse = source.Warehouses.FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);
            return warehouse != null ? CreateModel(warehouse) : null;
        }
        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Warehouse
            {
                Id = maxId + 1,
                WarehouseComponents = new Dictionary<int, int>()
            };
            source.Warehouses.Add(CreateModel(model, element));
        }
        public void Update(WarehouseBindingModel model)
        {
            var element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) throw new Exception("Элемент не найден");
            CreateModel(model, element);
        }
        public void Delete(WarehouseBindingModel model)
        {
            Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null) source.Warehouses.Remove(element);
            else throw new Exception("Элемент не найден");
        }
        public bool CheckComponents(Dictionary<int, (string, int)> components, int counter)
        {
            foreach (var component in components)
            {
                int count = source.Warehouses
                    .Where(rec => rec.WarehouseComponents.ContainsKey(component.Key))
                    .Sum(rec => rec.WarehouseComponents[component.Key]);
                if (count < component.Value.Item2 * counter) return false;
            }
            foreach (var component in components) 
            {
                int requiredNumber = component.Value.Item2 * counter;
                foreach (var warehouse in source.Warehouses)
                {
                    var warehouseComponent = warehouse.WarehouseComponents;
                    if (!warehouseComponent.ContainsKey(component.Key)) continue;
                    if (warehouseComponent[component.Key] > requiredNumber)
                    {
                        warehouseComponent[component.Key] -= requiredNumber;
                        break;
                    }
                    else if (warehouseComponent[component.Key] <= requiredNumber)
                    {
                        requiredNumber -= warehouseComponent[component.Key];
                        warehouseComponent.Remove(component.Key);
                    }
                    if (requiredNumber == 0) break;
                }
            }
            return true;
        }
        private static Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.WarehouseManagerFullName = model.WarehouseManagerFullName;
            warehouse.DateCreate = model.DateCreate;
            foreach (var key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key)) warehouse.WarehouseComponents.Remove(key);
            }
            foreach (var component in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(component.Key)) warehouse.WarehouseComponents[component.Key] = model.WarehouseComponents[component.Key].Item2;
                else warehouse.WarehouseComponents.Add(component.Key, model.WarehouseComponents[component.Key].Item2);
            }
            return warehouse;
        }
        private WarehouseViewModel CreateModel(Warehouse waerhouse)
        {
            return new WarehouseViewModel
            {
                Id = waerhouse.Id,
                WarehouseName = waerhouse.WarehouseName,
                WarehouseManagerFullName = waerhouse.WarehouseManagerFullName,
                DateCreate = waerhouse.DateCreate,
                WarehouseComponents = waerhouse.WarehouseComponents.ToDictionary(recPC => recPC.Key, recPC => (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
