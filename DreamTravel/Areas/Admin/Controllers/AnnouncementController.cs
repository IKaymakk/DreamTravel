using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly AnnouncementManager _announcementManager;

        public AnnouncementController(AnnouncementManager announcementManager)
        {
            _announcementManager = announcementManager;
        }

        public IActionResult Index()
        {
            var values = _announcementManager.GetListAll();
            return View(values);
        }
    }
}
