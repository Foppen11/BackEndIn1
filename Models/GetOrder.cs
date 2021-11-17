using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning1.Models
{
    public class GetOrder
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string Status { get; set; }
        public List<GetOrderLine> OrderLines { get; set; }

    }
}
