using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.AdminDashboard
{
    public class _Cards2Statistics : ViewComponent
    {
        DestinationManager manager = new DestinationManager(new EfDestinationDal());

        public IViewComponentResult Invoke()
        {
            //var totalPrice = manager.GetTotalPrice();
            //ViewBag.TotalPrice = totalPrice;
            return View();
        }
    }
}
