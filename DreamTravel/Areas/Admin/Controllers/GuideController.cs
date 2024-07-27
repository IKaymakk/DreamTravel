using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;
        GuideValidator gv = new GuideValidator();


        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.Count = c.Guides.Count();
            var values = _guideService.GetListAll();
            return View(values);
        }
        public IActionResult DeleteGuide(int id)
        {
            var values = _guideService.GetById(id);
            _guideService.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide P)
        {
            ValidationResult result = gv.Validate(P);
            if (result.IsValid)
            {
                P.Status = true;
                _guideService.Insert(P);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in result.Errors)
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.GetById(id);
            ViewBag.Name = values.Name;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide P)
        {

            ValidationResult result = gv.Validate(P);
            if (result.IsValid)
            {
                P.Status = true;
                _guideService.Update(P);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in result.Errors)
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
            }
            return View();
        }
    }
}
