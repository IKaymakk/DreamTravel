using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DreamTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class TourController : Controller
    {
        private readonly IDestinationService _destinationService;

        public TourController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TourList()
        {
            var jsonTour = JsonConvert.SerializeObject(_destinationService.GetListAll());
            return Json(jsonTour);
        }

        [HttpPost]
        public IActionResult AddTour(Destination p)
        {
            p.Status = true;
            _destinationService.Insert(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.GetById(DestinationID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }
    }
}
