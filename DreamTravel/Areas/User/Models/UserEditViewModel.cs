namespace DreamTravel.Areas.User.Models
{
    public class UserEditViewModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirpassword { get; set; }
        public string? imageurl { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public IFormFile? image { get; set; }
    }
}
