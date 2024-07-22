using System.ComponentModel.DataAnnotations;

namespace DreamTravel.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Mail { get; set; }

        //[Required(ErrorMessage = "Boş Bırakılamaz")]
        //public string Phone { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(5, ErrorMessage = "En Az 5 Karakterlik Şifre Girin")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(6,ErrorMessage ="En Az 5 Karakterlik Şifre Girin")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string UserName { get; set; }
    }
}
