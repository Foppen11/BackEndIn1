using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Inlamning1.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        [Required]
        [StringLength(15)]
        public string Status { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Orders")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(OrderLine.Order))]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
