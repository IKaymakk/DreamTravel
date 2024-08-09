using DreamTravel.Models;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace DreamTravel.Controllers
{
    [AllowAnonymous]
    public class ResetPasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ResetPasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgetPasswordViewModel)
        {
            if (forgetPasswordViewModel.Mail == null)
            {
                ModelState.AddModelError(string.Empty, "E-Mail Adresi Girin.");
                return View(forgetPasswordViewModel);
            }
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Bu e-posta adresiyle kayıtlı bir kullanıcı bulunamadı.");
                return View(forgetPasswordViewModel);
            }
            else
            {
                ViewBag.SuccessMessage = "Şifre sıfırlama bağlantısı e-posta adresinize gönderildi. Lütfen e-postanızı kontrol edin.";
            }
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ChangePassword", "ResetPassword", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ikaymak817@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody ="Bu linke tıklayarak DreamTravel hesabınızın şifresini yenileyebilirsiniz."+ " "+ passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişiklik Talebi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("ikaymak817@gmail.com", "kdtnkngtbninqcty");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            var userid = TempData.Peek("userid");
            var token = TempData.Peek("token");

            if (userid == null || token == null)
            {
                // Hata mesajı göster veya hata sayfasına yönlendir
                ModelState.AddModelError(string.Empty, "Geçersiz istek. Lütfen yeniden deneyin.");
                return View();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userid.ToString());

                var result = await _userManager.ResetPasswordAsync(user, token.ToString(), changePasswordViewModel.password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
            }
            return View();
        }
    }
}
