using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DestinationPdfReport()
        {
            return View();
        }
    }
}
