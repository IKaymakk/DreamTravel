using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Default
{
    public class _Testimonial : ViewComponent
    {
        GenericManager<Testimonial> manager = new GenericManager<Testimonial>(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var values = manager.GetListAll();
            return View(values);
        }
    }
}
