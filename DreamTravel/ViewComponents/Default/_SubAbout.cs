using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        SubAboutManager manager = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()

        {
            var values = manager.GetListAll();
            return View(values);
        }
    }
}
