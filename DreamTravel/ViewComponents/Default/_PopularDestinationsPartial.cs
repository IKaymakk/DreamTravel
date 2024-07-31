using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Default
{
    public class _PopularDestinationsPartial : ViewComponent
    {
        private readonly IDestinationService _manager;

        public _PopularDestinationsPartial(IDestinationService manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _manager.GetListAll();
            return View(values);
        }
    }
}
