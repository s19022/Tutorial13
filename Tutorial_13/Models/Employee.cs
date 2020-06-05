using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_13.Models
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
