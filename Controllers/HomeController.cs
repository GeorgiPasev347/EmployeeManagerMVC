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
        public IActionResult Error(int? statusCode = null)
        {
            return View("Error500");
        }
        [Route("Home/HandleError/{statusCode}")]
        public IActionResult HandleError(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound"); 
            }

            
            return View("Error500");
        }

       
    }
}
