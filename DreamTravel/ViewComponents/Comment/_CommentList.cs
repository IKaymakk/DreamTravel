using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.ViewComponents.Destination
{
    public class _CommentList : ViewComponent
    {
        CommentManager manager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = manager.TGetListCommentWithDestinationAndUser(id);
            ViewBag.commentCount = values.Count();
            return View(values);
        }
    }
}
