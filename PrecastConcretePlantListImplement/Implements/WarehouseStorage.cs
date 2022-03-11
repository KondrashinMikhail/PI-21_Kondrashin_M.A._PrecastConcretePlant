using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantListImplement.Models;

namespace PrecastConcretePlantListImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly DataListSingleton source;
        public WarehouseStorage() => source = DataListSingleton.GetInstance();
        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null) return null;
            var result = new List<WarehouseViewModel>();
            foreach (var warehouse in source.Warehouses) if (warehouse.Id > model.Id) result.Add(CreateModel(warehouse));
            return result;
        }
        public List<WarehouseViewModel> GetFullList()
        {
            var result = new List<WarehouseViewModel>();
            foreach (var warehouse in source.Warehouses) result.Add(CreateModel(warehouse));
            return result;
        }
        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null) return null;
            foreach (var warehouse in source.Warehouses) if (warehouse.Id == model.Id) return CreateModel(warehouse);
            return null;
        }

        public void Insert(WarehouseBindingModel model)
        {
            var tempWarehouse = new Warehouse { Id = 1, WarehouseComponents =new  Dictionary<int, int>() };
            foreach (var warehouse in source.Warehouses) if (warehouse.Id >= tempWarehouse.Id) tempWarehouse.Id = warehouse.Id + 1;
            source.Warehouses.Add(CreateModel(model, tempWarehouse));
        }
        public void Update(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = null;
            foreach (var warehouse in source.Warehouses) if (warehouse.Id == model.Id) tempWarehouse = warehouse;
            if (tempWarehouse == null) throw new Exception("Элемента не найлен");
            CreateModel(model, tempWarehouse);
        }
        public void Delete(WarehouseBindingModel model)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private WarehouseViewModel CreateModel(Warehouse warehouse) 
        {
            var warehouseComponents = new Dictionary<int, (string, int)>();
            foreach (var warehouseComponent in warehouse.WarehouseComponents)
            {
                string componentName = "";
                foreach (var component in source.Components)
                {
                    if (warehouseComponent.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                warehouseComponents.Add(warehouseComponent.Key, (componentName, warehouseComponent.Value));
            }
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                WarehouseManagerFullName = warehouse.WarehoiuseManagerFullName,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouseComponents
            };
        }
        private static Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.WarehoiuseManagerFullName = model.WarehouseManagerFullName;  
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

        public bool CheckCcomponents(Dictionary<int, (string, int)> components, int count)
        {
            throw new NotImplementedException();
        }
    }
}