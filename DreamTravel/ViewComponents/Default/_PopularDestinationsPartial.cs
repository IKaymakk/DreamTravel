using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Default
{
    public class _PopularDestinationsPartial : ViewComponent
    {
        GenericManager<Destination> manager = new GenericManager<Destination>(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = manager.GetListAll();
            return View(values);
        }
    }
}
