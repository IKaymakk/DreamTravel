using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic : ViewComponent
    {
        private readonly Context _context;

        public _Cards1Statistic(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var dcount = _context.Destinations.Count();
            var adcount = _context.Destinations.Where(x=>x.Status==true).Count();
            var ucount = _context.ContactUss.Count();
            var umcount = _context.ContactUss.Where(x=>x.ContactUsDate.Month==DateTime.Now.Month).Count();
            ViewBag.dcount = dcount;
            ViewBag.adcount = adcount;
            ViewBag.ucount = ucount;
            ViewBag.umcount = umcount;
            return View();
        }
    }
}
