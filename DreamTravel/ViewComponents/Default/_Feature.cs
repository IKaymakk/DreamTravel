using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        GenericManager<Feature> manager = new GenericManager<Feature>(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var values = manager.GetListAll().Take(5);
            return View(values);
        }
    }
}
