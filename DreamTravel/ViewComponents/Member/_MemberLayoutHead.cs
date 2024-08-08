using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Member
{
    public class _MemberLayoutHead:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
