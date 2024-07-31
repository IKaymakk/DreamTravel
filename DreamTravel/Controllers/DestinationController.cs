using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _manager;

        public DestinationController(IDestinationService manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var values = _manager.GetListAll();
            return View(values);
        }
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.i = id;
            var did = _manager.GetById(id);
            return View(did);
        }
    }
}
