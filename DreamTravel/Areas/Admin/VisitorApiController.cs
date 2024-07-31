using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.Admin
{
    public class VisitorApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
