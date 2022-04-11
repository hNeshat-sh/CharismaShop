using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System;

namespace CharismaShop.Model
{
    [Index(nameof(CustomerId), nameof(Id), IsUnique = true)]
    public class Order : BaseEntity, ITrackableEntity
    {
        [Column(TypeName = "decimal(19, 4)")]
        [Range(500000, double.MaxValue,
            ErrorMessage = "Value for {0} must be greater then {1}.")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Markup { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal DiscountAmount { get; set; }
        public double DiscountPercent { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime CreationDateTime { get; set; }

        public Order()
        {
            CreationDateTime = DateTime.Now;
        }
    }
}