using PrecastConcretePlantContracts.ViewModels;

namespace PrecastConcretePlantWarehouseApp
{
    public class Program
    {
        public static WarehouseViewModel Warehouse { get; set; }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}