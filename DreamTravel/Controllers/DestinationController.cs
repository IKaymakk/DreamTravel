using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing.Charts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _manager;
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(IDestinationService manager, UserManager<AppUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _manager.GetListAll();
            return View(values);
        }
        public async Task<IActionResult> DestinationDetails(int id)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserId = value.Id;
            ViewBag.i = id;
            var did = _manager.GetById(id);
            return View(did);
        }
    }
}
