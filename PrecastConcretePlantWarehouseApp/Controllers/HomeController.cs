using Microsoft.AspNetCore.Mvc;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.ViewModels;
using PrecastConcretePlantWarehouseApp.Models;
using System.Diagnostics;

namespace PrecastConcretePlantWarehouseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            if (Program.Entered == false) return Redirect("~/Home/Enter");
            return View(APIClient.GetRequest<List<WarehouseViewModel>>($"api/Warehouse/GetWarehouseList"));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public void Enter(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (_configuration["Password"] != password) throw new Exception("Неверный пароль");
                Program.Entered = true;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите пароль");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (Program.Entered == false) return Redirect("~Home/Enter");
            return View();
        }
        [HttpPost]
        public void Create(string warehouseName, string warehouseManagerFullName)
        {
            if (String.IsNullOrEmpty(warehouseName) || String.IsNullOrEmpty(warehouseManagerFullName)) return;
            APIClient.PostRequest("api/Warehouse/CreateOrUpdateWarehouse", new WarehouseBindingModel
            {
                WarehouseName = warehouseName,
                WarehouseManagerFullName = warehouseManagerFullName,
                DateCreate = DateTime.Now,
                WarehouseComponents = new Dictionary<int, (string, int)>()
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult AddComponent() 
        {
            if (Program.Entered == false) return Redirect("~Home/Enter");
            ViewBag.Warehouses = APIClient.GetRequest<List<WarehouseBindingModel>>("api/Warehouse/getwarehouselist");
            ViewBag.Components = APIClient.GetRequest<List<ComponentBindingModel>>("api/Warehouse/getcomponentlist");
            return View();
        }
        [HttpPost]
        public void AddComponent(int warehouse, int component, int count) 
        {
            APIClient.PostRequest("api/Warehouse/AddComponentToWarehouse", new WarehouseComponentBindingModel
            {
                Id = warehouse,
                ComponentId = component,
                Count = count
            });
            Response.Redirect("AddComponent");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            if (Program.Entered == false)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Warehouses = APIClient.GetRequest<List<WarehouseViewModel>>("api/Warehouse/GetWarehouseList");
            return View();
        }
        [HttpPost]
        public void Delete(int warehouse)
        {
            var model = APIClient.GetRequest<WarehouseViewModel>($"api/Warehouse/getwarehouse?warehouseId={warehouse}");
            APIClient.PostRequest("api/Warehouse/DeleteWarehouse", new WarehouseBindingModel
            {
                Id = warehouse,
                WarehouseManagerFullName = model.WarehouseManagerFullName,
                WarehouseName = model.WarehouseName, 
                WarehouseComponents = model.WarehouseComponents,
            });
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult Update(int warehouseId)
        {
            if (Program.Entered == false) return Redirect("~/Home/Enter");
            var warehouse = APIClient.GetRequest<WarehouseViewModel>($"api/Warehouse/getwarehouse?warehouseId={warehouseId}");
            ViewBag.WarehouseName = warehouse.WarehouseName;
            ViewBag.WarehouseManagerFullName = warehouse.WarehouseManagerFullName;
            ViewBag.WarehouseComponents = warehouse.WarehouseComponents;
            return View();
        }
        [HttpPost]
        public void Update(int warehouseId, string warehouseName, string warehouseManagerFullName)
        {
            if (String.IsNullOrEmpty(warehouseName) || String.IsNullOrEmpty(warehouseManagerFullName)) return;
            var warehouse = APIClient.GetRequest<WarehouseViewModel>($"api/Warehouse/getwarehouse?warehouseId={warehouseId}");
            APIClient.PostRequest("api/Warehouse/CreateOrUpdateWarehouse", new WarehouseBindingModel
            {
                Id = warehouseId,
                WarehouseName = warehouseName,
                WarehouseManagerFullName = warehouseManagerFullName,
                WarehouseComponents = warehouse.WarehouseComponents,
                DateCreate = DateTime.Now
            });
            Response.Redirect("Index");
        }
    }
}