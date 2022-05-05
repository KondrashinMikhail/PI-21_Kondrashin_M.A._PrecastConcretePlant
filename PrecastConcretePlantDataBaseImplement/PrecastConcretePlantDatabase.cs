using PrecastConcretePlantDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace PrecastConcretePlantDataBaseImplement
{
    public class PrecastConcretePlantDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (optionsBuilder.IsConfigured == false) optionsBuilder.UseSqlServer(
                @"Data Source=LAPTOP-87RD5TMK\SQLEXPRESS1;Initial Catalog=PrecastConcretePlantDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Reinforced> Reinforceds { get; set; }
        public virtual DbSet<ReinforcedComponent> ReinforcedComponents { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseComponent> WarehouseComponents { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Implementer> Implementers { get; set; }
    }
}
