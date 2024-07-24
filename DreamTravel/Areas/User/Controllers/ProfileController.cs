using DreamTravel.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel wm = new UserEditViewModel();
            wm.name = values.Name;
            wm.surname = values.Surname;
            wm.email = values.Email;
            wm.phonenumber = values.PhoneNumber;
            wm.username = values.UserName;
            wm.imageurl = values.ImageUrl;
            return View(wm);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            //Kullanıcıdan Resim Aldık
            if (p.image != null)
            {
                //var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "userimages", imagename);
                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await p.image.CopyToAsync(stream);
                }
                values.ImageUrl = "/userimages/" + imagename;
                p.imageurl = values.ImageUrl;
            }

            values.Name = p.name;
            values.Surname = p.surname;
            values.Email = p.email;
            values.PhoneNumber = p.phonenumber;
            p.imageurl = values.ImageUrl;
            values.UserName = p.username;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.password);
            var result = await _userManager.UpdateAsync(values);


            if (p.password == p.confirpassword)
            {
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
