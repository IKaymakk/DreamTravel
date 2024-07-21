using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
