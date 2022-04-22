using Microsoft.EntityFrameworkCore;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantDatabaseImplement.Models;
using PrecastConcretePlantDataBaseImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecastConcretePlantDatabaseImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null) return null;
            using var context = new PrecastConcretePlantDatabase();
            return context.Warehouses
                .Include(rec => rec.WarehouseComponents)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }
        public List<WarehouseViewModel> GetFullList()
        {
            using var context = new PrecastConcretePlantDatabase();
            return context.Warehouses
                .Include(rec => rec.WarehouseComponents)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }
        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null) return null;
            var context = new PrecastConcretePlantDatabase();
            var warehouse = context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);

            return warehouse != null ? CreateModel(warehouse) : null;
        }
        public void Insert(WarehouseBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                CreateModel(model, new Warehouse(), context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(WarehouseBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null) throw new Exception("Элемент не найден");
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(WarehouseBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            var element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Warehouses.Remove(element);
                context.SaveChanges();
            }
            else throw new Exception("Элемент не найден");
        }
        public bool CheckComponents(Dictionary<int, (string, int)> components, int orderCount)
        {
            var context = new PrecastConcretePlantDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var warehouseComponent in components)
                {
                    int count = warehouseComponent.Value.Item2 * orderCount;
                    var warehouseComponents = context.WarehouseComponents.Where(warehouse => warehouse.ComponentId == warehouseComponent.Key);
                    int totalCount = warehouseComponents.Sum(warehouse => warehouse.Count);
                    foreach (var component in warehouseComponents)
                    {
                        if (component.Count <= count)
                        {
                            count -= component.Count;
                            context.WarehouseComponents.Remove(component);
                            context.SaveChanges();
                        }
                        else
                        {
                            component.Count -= count;
                            context.SaveChanges();
                            count = 0;
                        }
                        if (count == 0) break;
                    }
                    if (count != 0) throw new Exception("Недостаточно компонентов на складе");
                }
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        private static Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, PrecastConcretePlantDatabase context)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.WarehouseManagerFullName = model.WarehouseManagerFullName;

            if (warehouse.Id == 0)
            {
                warehouse.DateCreate = DateTime.Now;
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                var warehouseComponent = context.WarehouseComponents
                    .Where(rec => rec.WarehouseId == model.Id.Value)
                    .ToList();

                context.WarehouseComponents.RemoveRange(warehouseComponent
                    .Where(rec => !model.WarehouseComponents.ContainsKey(rec.ComponentId))
                    .ToList());
                context.SaveChanges();
                foreach (var updateComponent in warehouseComponent)
                {
                    updateComponent.Count = model.WarehouseComponents[updateComponent.ComponentId].Item2;
                    model.WarehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            foreach (var warehouseComponent in model.WarehouseComponents)
            {
                context.WarehouseComponents.Add(new WarehouseComponent
                {
                    WarehouseId = warehouse.Id,
                    ComponentId = warehouseComponent.Key,
                    Count = warehouseComponent.Value.Item2
                });
                context.SaveChanges();
            }
            return warehouse;
        }
        private static WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                WarehouseManagerFullName = warehouse.WarehouseManagerFullName,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }
    }
}
