using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_13.DTOs.Request
{
    public class AddConfectioneryRequest
    {
        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }
    }
}
