using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserLoginDTOs
    {
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Password { get; set; }
    }
}
