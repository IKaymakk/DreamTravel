using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
