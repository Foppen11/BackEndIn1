using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Inlamning1.Entities
{
    public partial class OrderLine
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderLines")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderLines")]
        public virtual Product Product { get; set; }
    }
}
