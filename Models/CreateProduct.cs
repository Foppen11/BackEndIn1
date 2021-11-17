using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning1.Models
{
    public class CreateProduct
    {
        
        public string Image { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}
