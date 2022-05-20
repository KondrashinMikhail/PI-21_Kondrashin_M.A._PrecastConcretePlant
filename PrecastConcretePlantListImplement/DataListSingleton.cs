using PrecastConcretePlantListImplement.Models;
using System.Collections.Generic;

namespace PrecastConcretePlantListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Reinforced> Reinforceds { get; set; }
        public List<Client> Clients { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessagesInfo { get;set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Reinforceds = new List<Reinforced>();
            Warehouses = new List<Warehouse>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessagesInfo = new List<MessageInfo>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null) instance = new DataListSingleton();
            return instance;
        }
    }
}
