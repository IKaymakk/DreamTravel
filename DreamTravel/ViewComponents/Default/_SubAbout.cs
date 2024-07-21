using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        GenericManager<SubAbout> manager = new GenericManager<SubAbout>(new EfSubAboutDal());
        public IViewComponentResult Invoke()

        {
            var values = manager.GetListAll();
            return View(values);
        }
    }
}
