using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DreamTravel.Areas.Admin.Models;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementManager;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementManager, IMapper mapper)
        {
            _announcementManager = announcementManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementManager.GetListAll());
            return View(values);
        }
        [HttpGet]
        public IActionResult NewAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewAnnouncement(AnnouncementAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementManager.Insert(new Announcement()
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementManager.GetById(id);
            _announcementManager.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementManager.GetById(id));
            ViewBag.No = values.AnnouncementID;
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementManager.Update(new Announcement
                {
                    AnnouncementID = model.AnnouncementID,
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                }) ;
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
