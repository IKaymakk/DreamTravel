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
            using var c = new Context();
            var values = manager.GetAll(id);
            ViewBag.commentCount = c.Comments.Count(x => x.DestinationID == id);
            return View(values);
        }
    }
}
