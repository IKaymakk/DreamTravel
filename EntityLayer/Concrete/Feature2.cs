using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Feature2
    {
        [Key]
        public int FeatureID { get; set; }
        public string? Post2Title { get; set; }
        public string? Post2Description { get; set; }
        public string? Post2Image { get; set; }
        public bool Post2Status { get; set; }
    }
}


