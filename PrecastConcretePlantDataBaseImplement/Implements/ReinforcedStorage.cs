using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.StoragesContracts;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PrecastConcretePlantDataBaseImplement;

namespace PrecastConcretePlantDatabaseImplement.Implements
{
    public class ReinforcedStorage : IReinforcedStorage
    {
        public List<ReinforcedViewModel> GetFullList()
        {
            using var context = new PrecastConcretePlantDatabase();
            return context.Reinforceds
            .Include(rec => rec.ReinforcedComponents)
            .ThenInclude(rec => rec.Component)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<ReinforcedViewModel> GetFilteredList(ReinforcedBindingModel model)
        {
            if (model == null) return null;
            using var context = new PrecastConcretePlantDatabase();
            return context.Reinforceds
            .Include(rec => rec.ReinforcedComponents)
            .ThenInclude(rec => rec.Component)
            .Where(rec => rec.ReinforcedName.Contains(model.ReinforcedName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public ReinforcedViewModel GetElement(ReinforcedBindingModel model)
        {
            if (model == null) return null;
            using var context = new PrecastConcretePlantDatabase();
            var reinforced = context.Reinforceds
            .Include(rec => rec.ReinforcedComponents)
            .ThenInclude(rec => rec.Component)
            .FirstOrDefault(rec => rec.ReinforcedName == model.ReinforcedName || rec.Id == model.Id);
            return reinforced != null ? CreateModel(reinforced) : null;
        }
        public void Insert(ReinforcedBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Reinforced reinforced = new Reinforced 
                {
                    ReinforcedName = model.ReinforcedName,
                    Price = model.Price
                };
                context.Reinforceds.Add(reinforced);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(ReinforcedBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Reinforceds.FirstOrDefault(rec => rec.Id == model.Id);
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
        public void Delete(ReinforcedBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            Reinforced element = context.Reinforceds.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Reinforceds.Remove(element);
                context.SaveChanges();
            }
            else throw new Exception("Элемент не найден");
        }
        private static Reinforced CreateModel(ReinforcedBindingModel model, Reinforced reinforced, PrecastConcretePlantDatabase context)
        {
            reinforced.ReinforcedName = model.ReinforcedName;
            reinforced.Price = model.Price;
            if (model.Id.HasValue)
            {
                var reinforcedComponents = context.ReinforcedComponents.Where(rec => rec.ReinforcedId == model.Id.Value).ToList();
                context.ReinforcedComponents.RemoveRange(reinforcedComponents.Where(rec => !model.ReinforcedComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                foreach (var updateComponent in reinforcedComponents)
                {
                    updateComponent.Count = model.ReinforcedComponents[updateComponent.ComponentId].Item2;
                    model.ReinforcedComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            foreach (var pc in model.ReinforcedComponents)
            {
                context.ReinforcedComponents.Add(new ReinforcedComponent
                {
                    ReinforcedId = reinforced.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return reinforced;
        }
        private static ReinforcedViewModel CreateModel(Reinforced reinforced)
        {
            return new ReinforcedViewModel
            {
                Id = reinforced.Id,
                ReinforcedName = reinforced.ReinforcedName,
                Price = reinforced.Price,
                ReinforcedComponents = reinforced.ReinforcedComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }
    }
}
