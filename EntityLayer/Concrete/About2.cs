using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About2
    {
        [Key]
        public int AbouID2 { get; set; }
        public int Title { get; set; }
        public int Titl2 { get; set; }
        public int Description { get; set; }
        public int Image { get; set; }
    }
}
