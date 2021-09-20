using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyServerRenderedPortal.Models
{
    public class Shoe
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string Size { get; set; }
        public int ShoeSizeID { get; set; }
        public ShoeSize ShoeSize { get; set; }
    }   
}
