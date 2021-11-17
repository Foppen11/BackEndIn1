//using Inlamning1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning1.Models
{
    public class CreateOrder
    {
        public int UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string Status { get; set; }
        public List<CreateOrderLine> OrderLines { get; set; }
    }
}
