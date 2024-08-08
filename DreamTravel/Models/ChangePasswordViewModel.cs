using System.ComponentModel.DataAnnotations;

namespace DreamTravel.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(8, ErrorMessage = "En Az 8 Karakterlik Şifre Girin")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).+$", ErrorMessage = "Şifre en az bir büyük harf ve bir küçük harf içermelidir.")]
        [Compare("confirmpassword", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string? password { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(8, ErrorMessage = "En Az 8 Karakterlik Şifre Girin")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).+$", ErrorMessage = "Şifre en az bir büyük harf ve bir küçük harf içermelidir.")]
        [Compare("password", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string? confirmpassword { get; set; }
    }
}
