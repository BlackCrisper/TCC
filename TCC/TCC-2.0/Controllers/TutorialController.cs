using Microsoft.AspNetCore.Mvc;

namespace TCC_2._0.Controllers
{
    public class TutorialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
