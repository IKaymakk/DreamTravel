using System.ComponentModel.DataAnnotations;

namespace DreamTravel.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(3, ErrorMessage = "En Az 3 KarakterGirin")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(3, ErrorMessage = "En Az 3 KarakterGirin")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Geçerli bir mail adresi giriniz.")]
        [EmailAddress]
        public string Mail { get; set; }

        //[Required(ErrorMessage = "Boş Bırakılamaz")]
        //public string Phone { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(8, ErrorMessage = "En Az 8 Karakterlik Şifre Girin")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).+$", ErrorMessage = "Şifre en az bir büyük harf ve bir küçük harf içermelidir.")]
        [Compare("ConfirmPassword", ErrorMessage = "Şifreler Uyuşmuyor!")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(8,ErrorMessage ="En Az 8 Karakterlik Şifre Girin")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).+$", ErrorMessage = "Şifre en az bir büyük harf ve bir küçük harf içermelidir.")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(3, ErrorMessage = "En Az 3 KarakterGirin")]
        public string UserName { get; set; }
    }
}
