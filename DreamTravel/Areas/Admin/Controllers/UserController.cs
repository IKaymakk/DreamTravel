using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;
        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
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
        public IActionResult UserReservations(int id)
        {
            var values = _appUserService.GetById(id);
            ViewBag.Name = values.Name;
            ViewBag.Surname = values.Surname;
            var list = _reservationService.GetListReservationWithDestination(id);
            return View(list);
        }
    }
}
