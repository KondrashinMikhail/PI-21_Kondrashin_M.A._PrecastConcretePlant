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
    public class ImplementerStorage : IImplementerStorage
    {
        public List<ImplementerViewModel> GetFullList()
        {
            using var context = new PrecastConcretePlantDatabase();
            return context.Implementers
                .Select(CreateModel)
                .ToList();
        }
        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null) return null;
            using var context = new PrecastConcretePlantDatabase();
            return context.Implementers
            .Where(rec => rec.ImplementerName.Contains(model.ImplementerName))
            .Select(CreateModel)
            .ToList();
        }
        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null) return null;
            var context = new PrecastConcretePlantDatabase();
            var implementer = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            return implementer != null ? CreateModel(implementer) : null;
        }
        public void Insert(ImplementerBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            context.Implementers.Add(CreateModel(model, new Implementer()));
            context.SaveChanges();
        }
        public void Update(ImplementerBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            var element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) throw new Exception("Элемент не найден");
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(ImplementerBindingModel model)
        {
            using var context = new PrecastConcretePlantDatabase();
            var element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Implementers.Remove(element);
                context.SaveChanges();
            }
            else throw new Exception("Элемент не найден");
        }
        private static Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.ImplementerName = model.ImplementerName;
            implementer.WorkingTime = model.WorkingTime;
            implementer.PauseTime = model.PauseTime;
            return implementer;
        }
        private static ImplementerViewModel CreateModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                ImplementerName = implementer.ImplementerName,
                WorkingTime = implementer.WorkingTime,
                PauseTime = implementer.PauseTime
            };
        }
    }
}
