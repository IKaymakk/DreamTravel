using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager m = new CommentManager(new EfCommentDal());
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            p.CommentStatus = true;



            m.Insert(p);
            return RedirectToAction("DestinationDetails", "Destination", new { id = p.DestinationID });
        }
    }
}
