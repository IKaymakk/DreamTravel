using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    public class Information : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
