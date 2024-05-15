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
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            var context = new PrecastConcretePlantDatabase();
            return context.Clients.Select(CreateModel).ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null) return null;
            var context = new PrecastConcretePlantDatabase();
            return context.Clients.Include(x => x.Orders)
                .Where(rec => rec.Login == model.Login && rec.Password == model.Password)
                .Select(CreateModel)
                .ToList();
        }
        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null) return null;
            var context = new PrecastConcretePlantDatabase();
            var client = context.Clients
                .Include(x => x.Orders)
                .FirstOrDefault(rec => rec.Login == model.Login || rec.Id == model.Id);
            return client != null ? CreateModel(client) : null;
        }
        public void Insert(ClientBindingModel model)
        {
            var context = new PrecastConcretePlantDatabase();
            context.Clients.Add(CreateModel(model, new Client()));
            context.SaveChanges();
        }
        public void Update(ClientBindingModel model)
        {
            var context = new PrecastConcretePlantDatabase();
            var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) throw new Exception("Клиент не найден");
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(ClientBindingModel model)
        {
            var context = new PrecastConcretePlantDatabase();
            Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
            }
            else throw new Exception("Клиент не найден");
        }
        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientName = model.ClientName;
            client.Login = model.Login;
            client.Password = model.Password;
            return client;
        }
        private ClientViewModel CreateModel(Client model)
        {
            return new ClientViewModel
            {
                Id = model.Id,
                ClientName = model.ClientName,
                Login = model.Login,
                Password = model.Password
            };
        }
    }
}
