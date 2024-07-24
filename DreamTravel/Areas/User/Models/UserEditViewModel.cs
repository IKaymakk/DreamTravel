using System.ComponentModel.DataAnnotations;

namespace DreamTravel.Areas.User.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(3, ErrorMessage = "En Az 3 Karakter Girin")]
        public string name { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(3, ErrorMessage = "En Az 3 Karakter Girin")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(3, ErrorMessage = "En Az 3 Karakter Girin")]
        public string username { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(8, ErrorMessage = "En Az 8 Karakterlik Şifre Girin")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).+$", ErrorMessage = "Şifre en az bir büyük harf ve bir küçük harf içermelidir.")]
        [Compare("confirpassword", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string password { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(8, ErrorMessage = "En Az 8 Karakterlik Şifre Girin")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).+$", ErrorMessage = "Şifre en az bir büyük harf ve bir küçük harf içermelidir.")]
        [Compare("password", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string confirpassword { get; set; }

        public string? imageurl { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Geçerli bir mail adresi giriniz.")]
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string email { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string phonenumber { get; set; }

        public IFormFile? image { get; set; }

    }
}
