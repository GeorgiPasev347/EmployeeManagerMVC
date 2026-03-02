using Microsoft.AspNetCore.Mvc;

namespace SampleCrudMVC.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
