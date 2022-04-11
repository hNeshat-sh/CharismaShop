using System.ComponentModel.DataAnnotations;
using System;

namespace CharismaShop.Dto
{
    public class OrderDto
    {
        public decimal Markup { get; set; }
        public decimal DiscountAmount { get; set; }
        public double DiscountPercent { get; set; }
        public long CustomerId { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public DateTime CreationDateTime { get; set; }
        [Range(8, 19,
        ErrorMessage = "Registration time must be between {1} and {2}.")]
        public int CreationTime => CreationDateTime.Hour;
    }
}