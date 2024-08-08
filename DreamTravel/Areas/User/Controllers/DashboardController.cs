using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = values.Name + " " + values.Surname;
            ViewBag.Image = values.ImageUrl;
            ViewBag.Phone = values.PhoneNumber;
            ViewBag.Username = values.UserName;
            ViewBag.Mail = values.Email;
            return View();
        }
        public async Task<IActionResult> MemberDashboard()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = values.Name + " " + values.Surname;
            ViewBag.Image = values.ImageUrl;
            ViewBag.Phone = values.PhoneNumber;
            ViewBag.Username = values.UserName;
            ViewBag.Mail = values.Email;
            return View();
        }
    }
}
