using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.UserDashboard
{
    public class _DashboardGuideList : ViewComponent
    {
        GuideManager gm = new GuideManager(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            var values = gm.GetListAll();
            return View(values);
        }
    }
}
