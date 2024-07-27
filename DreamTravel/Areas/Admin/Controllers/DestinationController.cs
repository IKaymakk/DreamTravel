using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult NewDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewDestination(Destination P)
        {
            P.Status = true;
            _destinationService.Insert(P);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDestination(int id)
        {
            var destination = _destinationService.GetById(id);
            _destinationService.Delete(destination);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {

            var destination = _destinationService.GetById(id);
            return View(destination);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination p)
        {
            p.Status = true;
            _destinationService.Update(p);
            return Redirect("/Admin/Destination/Index/");
        }
        public IActionResult ChangeDestinationStatus(int id)
        {
            _destinationService.ChangeDestinationStatus(id);
            return RedirectToAction("Index");
        }

    }
}
