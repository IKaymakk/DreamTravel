using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Member
{
    public class _MemberLayoutLanguages:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
