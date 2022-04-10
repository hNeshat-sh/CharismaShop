using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharismaShop.Model
{
    public class Order : BaseEntity, ITrackableEntity
    {
        [Column(TypeName = "decimal(19, 4)")]
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
    }
}