using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuideManager manager = new GuideManager(new EfGuideDal());
        public IActionResult Index()
        {
            var values = manager.GetListAll();
            return View(values);
        }
    }
}
