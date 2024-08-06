using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TF_IOT_2024_MVC_Exo_Session.Handlers;
using TF_IOT_2024_MVC_Exo_Session.Models;

namespace TF_IOT_2024_MVC_Exo_Session.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoListSessionManager _session;
        public HomeController(ILogger<HomeController> logger, ToDoListSessionManager session)
        {
            _logger = logger;
            _session = session;
        }

        public IActionResult Index()
        {
            IEnumerable<string> model = _session.ToDoList;
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(string task) {
            try
            {
                if(task is null) throw new ArgumentNullException(nameof(task));
                _session.AddTask(task);
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View(task);
            }
        }

        public IActionResult Remove()
        {
            IEnumerable<string> model = _session.ToDoList;
            return View(model);
        }
        [HttpPost]
        public IActionResult Remove(string task) {
            try
            {
                if (task is null) throw new ArgumentNullException(nameof(task));
                _session.RemoveTask(task);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                IEnumerable<string> model = _session.ToDoList;
                return View(model);
            }
        }

        public IActionResult Clear() { 
            _session.ClearTodoList();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
