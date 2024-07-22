using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        FeatureManager manager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var values = manager.GetListAll().Take(5);
            return View(values);
        }
    }
}
