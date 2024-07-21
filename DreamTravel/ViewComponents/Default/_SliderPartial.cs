using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
