using Microsoft.AspNetCore.Mvc;

namespace SampleCrudMVC.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
