using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    [AllowAnonymous]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values = _contactUsService.TTrueMessageList();
            return View(values);
        }
        public IActionResult ChangeStatus(int id)
        {
            _contactUsService.TChangeMessageStatus(id);
            return RedirectToAction("Index");
        }
    }
}
