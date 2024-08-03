using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDto model)
        {
            if (ModelState.IsValid)
            {
                var message = _mapper.Map<ContactUs>(model);
                message.ContactUsDate = DateTime.Now;
                message.Status = true;
                _contactUsService.Insert(message);

                TempData["Message"] = "Mesajınız Başarıyla Gönderildi";

                return Redirect("/Default/Index");
            }
            else
            {
                ViewBag.SendMessageFailed = "alert alert-danger";
                TempData["Message2"] = "Mesajınız Gönderilmedi , Kontrol Ediniz";
                return View(model);
            }
        }
    }
}
