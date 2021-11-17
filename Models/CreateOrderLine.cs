using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning1.Models
{
    public class CreateOrderLine
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
