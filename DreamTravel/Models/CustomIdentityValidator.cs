using Microsoft.AspNetCore.Identity;

namespace DreamTravel.Models
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError()
            {
                Code = "InvalidEmail",
                Description = "Geçerli Bir Mail Adresi Girin"
            };
        }
    }
}
