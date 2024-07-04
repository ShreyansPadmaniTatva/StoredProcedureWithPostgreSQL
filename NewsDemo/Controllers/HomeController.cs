using Microsoft.AspNetCore.Mvc;
using NewsDemo.Models;
using NewsDemo.Service.Menu;
using System.Diagnostics;

namespace NewsDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenu _menu;

        public HomeController(ILogger<HomeController> logger, IMenu menu)
        {
            _logger = logger;
            _menu = menu;
        }

        public IActionResult Index()
        {
            var v = _menu.get_all_menu();
            return View(v);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsDemo.Domain.Model.Menu menu)
        {
            await _menu.InsertMenuAsync(menu);
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
