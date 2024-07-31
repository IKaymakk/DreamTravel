using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.AdminDashboard
{
    public class _Cards2Statistics : ViewComponent
    {
        private readonly IDestinationService _manager;

        public _Cards2Statistics(IDestinationService manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var totalPrice = _manager.GetTotalPrice();
            ViewBag.TotalPrice = totalPrice;
            return View();
        }
    }
}
