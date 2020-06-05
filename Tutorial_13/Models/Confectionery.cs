using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_13.Models
{
    public class Confectionery
    {
        [Key]
        public int IdConfectionery { get; set; }


        public string Name { get; set; }

        public double PricePerItem { get; set; }
        public string Type { get; set; }
    }
}
