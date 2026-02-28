using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SampleCrudMVC.Models;

namespace SampleCrudMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult HowToUse()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("Home/HandleError/{statusCode}")]
        public IActionResult HandleError(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound"); // Това е твоето 6-то вю
            }

            // Можеш да добавиш и за 500 (Bad Request), което е 7-мо вю
            return View("Error");
        }

       
    }
}
