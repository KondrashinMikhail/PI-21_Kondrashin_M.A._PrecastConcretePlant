using Microsoft.AspNetCore.Mvc;
using PrecastConcretePlantClientApp.Models;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.ViewModels;
using System.Diagnostics;

namespace PrecastConcretePlantClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) => _logger = logger;
        public IActionResult Index()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}"));
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.Client);
        }
        [HttpPost]
        public void Privacy(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(fio))
            {
                APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
                {
                    Id = Program.Client.Id,
                    ClientName = fio,
                    Login = login,
                    Password = password
                });
                Program.Client.ClientName = fio;
                Program.Client.Login = login;
                Program.Client.Password = password;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public void Enter(string login, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Program.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={login}&password={password}");
                if (Program.Client == null)
                {
                    throw new Exception("Неверный логин/пароль");
                }
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public void Register(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(fio))
            {
                APIClient.PostRequest("api/client/register", new ClientBindingModel
                {
                    ClientName = fio,
                    Login = login,
                    Password = password
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Reinforceds = APIClient.GetRequest<List<ReinforcedViewModel>>("api/main/getreinforcedlist");
            return View();
        }
        [HttpPost]
        public void Create(int reinforced, int count, decimal sum)
        {
            if (count == 0 || sum == 0)
            {
                return;
            }
            APIClient.PostRequest("api/main/createorder", new CreateOrderBindingModel
            {
                ClientId = Program.Client.Id,
                ReinforcedId = reinforced,
                Count = count,
                Sum = sum
            }); 
            Response.Redirect("Index");
        }
        [HttpPost]
        public decimal Calc(decimal count, int reinforced)
        {
            var prod = APIClient.GetRequest<ReinforcedViewModel>($"api/main/getreinforced?reinforcedId={reinforced}");
            return count * prod.Price;
        }
        public IActionResult Messages(int page = 1)
        {
            if (Program.Client == null) return Redirect("~/Home/Enter");
            var temp = APIClient.GetRequest<(List<MessageInfoViewModel> list, bool hasNext)>
                ($"api/main/GetMessages?clientId={Program.Client.Id}&page={page}");
            (List<MessageInfoViewModel>, bool, int) model = (temp.list, temp.hasNext, page);
            return View(model);
        }
    }
}