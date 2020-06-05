using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_13.Models
{
    public class Confectionery_Order
    {
        public int IdConfectionary { get; set; }
        [ForeignKey("IdConfectionary")]
        public Confectionery Confectionary { get; set; }

        public int IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public Order Order { get; set; }

        public int Quantity { get; set; }

        public string Notes { get; set; }

    }
}
