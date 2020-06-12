using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_13.Models;

namespace Tutorial_13.DTOs.Request
{
    public class AddOrderRequest
    {
        public DateTime DateAccepted { get; set; }
        public string Notes { get; set; }

        public int IdEmployee { get; set; }

        public ICollection<AddConfectioneryRequest> Confectionery { get; set; }
    }
}
