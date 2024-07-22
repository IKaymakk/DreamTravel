using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Destination
    {
        [Key]
        public int DestinationID { get; set; }
        public string? City { get; set; }
        public string? DayNight { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }
        public string? BlogImage1 { get; set; }
        public string? BlogImage2 { get; set; }
        public string? Description1 { get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set; }
        public string? Description4 { get; set; }
        public string? DescriptionTitle1 { get; set; }
        public string? DescriptionTitle2 { get; set; }
        public string? ShortDescription { get; set; }
        public string? GuideName { get; set; }
        public string? GuideImage { get; set; }
        public string? Image { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
