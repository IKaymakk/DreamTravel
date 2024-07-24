using DreamTravel.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signin;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signin)
        {
            _signin = signin;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signin.PasswordSignInAsync(p.Username, p.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new { area = "User" });
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {

                // E-posta adresinin daha önce alınmış olup olmadığını kontrol et
                var existingUserByEmail = await _userManager.FindByEmailAsync(p.Mail);
                if (existingUserByEmail != null)
                {
                    ModelState.AddModelError("Email", "Bu e-posta adresi zaten alınmıştır.");
                    return View(p);
                }


            AppUser appuser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.UserName
            };

            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appuser, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        if (item.Code == "DuplicateUserName")
                        {
                            ModelState.AddModelError("UserName", "Bu kullanıcı adı zaten alınmış.");
                        }
                        else
                        {
                            ModelState.AddModelError("", item.Description);

                        }
                    }
                }
            }
            return View(p);
        }
    }
}

