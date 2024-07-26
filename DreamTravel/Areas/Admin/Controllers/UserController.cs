using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;

        public UserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.GetListAll();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var value = _appUserService.GetById(id);
            _appUserService.Delete(value);
            return RedirectToAction("Index");
        }
        public IActionResult UserComments()
        {
            return View();
        }
        public IActionResult UserReservations()
        {
            return View();  
        }
    }
}
