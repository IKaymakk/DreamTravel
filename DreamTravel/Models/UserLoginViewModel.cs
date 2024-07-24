using System.ComponentModel.DataAnnotations;

namespace DreamTravel.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Password { get; set; }
    }
}
