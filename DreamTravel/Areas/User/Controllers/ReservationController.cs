using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DreamTravel.Areas.User.Controllers
{
    [Area("User")]
    public class ReservationController : Controller
    {
        private readonly IDestinationService _manager;
        ReservationManager rm = new ReservationManager(new EfReservationDal());

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager, IDestinationService manager)
        {
            _userManager = userManager;
            _manager = manager;
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in _manager.GetListAll()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.Status = "Onay Bekliyor";
            p.AppUserId = 20;
            p.ReservationDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            rm.Insert(p);
            return RedirectToAction("ProgressingReservation", "Reservation", new { area = "User" });
        }

        public async Task<IActionResult> ProgressingReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var list = rm.GetListReservationWithDestination(values.Id);
            return View(list);
        }
        public IActionResult PendingApprovalReservation()
        {
            return View();
        }
        public IActionResult OldReservation()
        {
            return View();
        }
    }
}
