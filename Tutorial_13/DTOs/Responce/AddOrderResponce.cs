using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_13.Models;

namespace Tutorial_13.DTOs.Request
{
    public class AddOrderResponce
    {
        public int IdOrder { get; set; }

        public List<int> Conf_Ids { get; set; }

    }
}
