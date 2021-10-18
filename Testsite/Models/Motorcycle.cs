using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testsite.Models
{
    public class Motorcycle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)] 
        public DateTime ReleaseDate { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Engine { get; set; }
    }
}
