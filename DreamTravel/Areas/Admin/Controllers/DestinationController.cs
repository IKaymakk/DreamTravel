using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        DestinatonValidator dv = new DestinatonValidator();
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
            ValidationResult result = dv.Validate(P);
            if (result.IsValid)
            {
                P.Status = true;
                _destinationService.Insert(P);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in result.Errors)
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
            }
            return View();

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
