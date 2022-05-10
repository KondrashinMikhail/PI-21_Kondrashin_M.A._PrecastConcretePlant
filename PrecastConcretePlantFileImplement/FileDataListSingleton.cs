using PrecastConcretePlantContracts.Enums;
using PrecastConcretePlantFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace PrecastConcretePlantFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "C:/Users/user/source/repos/XML/Component.xml";
        private readonly string OrderFileName = "C:/Users/user/source/repos/XML/Order.xml";
        private readonly string ReinforcedFileName = "C:/Users/user/source/repos/XML/Reinforced.xml";
        private readonly string ClientFileName = "C:/Users/user/source/repos/XML/Client.xml";
        private readonly string ImplementerFileName = "C:/Users/user/source/repos/XML/Implemeter.xml";
        private readonly string WarehouseFileName = "C:/Users/user/source/repos/XML/Warehouse.xml";



        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Reinforced> Reinforceds { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Reinforceds = LoadReinforceds();
            Orders = LoadOrders();
            Warehouses = LoadWarehouses();
            Clients = LoadClients();
            Implementers = LoadImplementers();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null) instance = new FileDataListSingleton();
            return instance;
        }
        public void Save()
        {
            SaveComponents();
            SaveOrders();
            SaveReinforceds();
            SaveClients();
            SaveWarehouse();
            SaveImplementers();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                var xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ReinforcedId = Convert.ToInt32(elem.Element("ReinforcedId").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        ImplementerId = Convert.ToInt32(elem.Element("ImplementerId")?.Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Reinforced> LoadReinforceds()
        {
            var list = new List<Reinforced>();
            if (File.Exists(ReinforcedFileName))
            {
                var xDocument = XDocument.Load(ReinforcedFileName);
                var xElements = xDocument.Root.Elements("Reinforced").ToList();
                foreach (var elem in xElements)
                {
                    var reinfComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("ReinforcedComponents").Elements("ReinforcedComponent").ToList())
                    {
                        reinfComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Reinforced
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ReinforcedName = elem.Element("ReinforcedName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        ReinforcedComponents = reinfComp
                    });
                }
            }
            return list;
        }
        private List<Warehouse> LoadWarehouses() 
        {
            var list = new List<Warehouse>();
            if (File.Exists(WarehouseFileName))
            {
                var xDocument = XDocument.Load (WarehouseFileName);
                var xElements = xDocument.Root.Elements("Warehouse").ToList();
                foreach (var elem in xElements) 
                {
                    var warehouseComponent = new Dictionary<int, int>();
                    foreach (var component in elem.Element("WarehouseComponents").Elements("WarehouseComponent").ToList()) 
                    {
                        warehouseComponent.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Warehouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseName = elem.Element("WarehouseName").Value,
                        WarehouseManagerFullName = elem.Element("WarehouseManagerFullName").Value,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        WarehouseComponents = warehouseComponent
                    });
                }
            }
            return list;
        }
        private List<Client> LoadClients() 
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                var xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientName = elem.Attribute("ClientName").Value,
                        Login = elem.Attribute("Login").Value,
                        Password = elem.Attribute("Password").Value
                    });
                }
            }
            return list;
        }
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                var xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerName = Convert.ToString(elem.Attribute("ImplementerName").Value),
                        WorkingTime = Convert.ToInt32(elem.Attribute("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Attribute("PauseTime").Value)
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("ReinforcedId", order.ReinforcedId),
                    new XElement("ClientId", order.ClientId),
                    new XElement("ImplementerId", order.ImplementerId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveReinforceds()
        {
            if (Reinforceds != null)
            {
                var xElement = new XElement("Reinforceds");
                foreach (var reinforced in Reinforceds)
                {
                    var compElement = new XElement("ReinforcedComponents");
                    foreach (var component in reinforced.ReinforcedComponents)
                    {
                        compElement.Add(new XElement("ReinforcedComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Reinforced",
                     new XAttribute("Id", reinforced.Id),
                     new XElement("ReinforcedName", reinforced.ReinforcedName),
                     new XElement("Price", reinforced.Price), compElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ReinforcedFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientName", client.ClientName),
                    new XElement("Login", client.Login),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private void SaveImplementers() 
        {
            if (Implementers != null) 
            {
                var xElement = new XElement("Implementers");
                foreach (var implementer in Implementers) 
                {
                    xElement.Add(new XElement("Implementer",
                        new XAttribute("Id", implementer.Id),
                        new XElement("ImplementerName", implementer.ImplementerName),
                        new XElement("WorkingTime", implementer.WorkingTime),
                        new XElement("PauseTime", implementer.PauseTime)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
        private void SaveWarehouse() 
        {
            if (Warehouses != null)
            {
                var xElement = new XElement("Warehouses");
                foreach (var warehouse in Warehouses)
                {
                    var compElement = new XElement("WarehouseComponents");
                    foreach (var component in warehouse.WarehouseComponents)
                    {
                        compElement.Add(new XElement("WarehouseComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Warehouse",
                     new XAttribute("Id", warehouse.Id),
                     new XElement("WarehouseName", warehouse.WarehouseName),
                     new XElement("WarehouseManagerFullName", warehouse.WarehouseManagerFullName),
                     new XElement("DateCreate", warehouse.DateCreate), compElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }
    }
}
