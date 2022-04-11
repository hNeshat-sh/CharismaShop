using System.ComponentModel.DataAnnotations.Schema;
using CharismaShop.Enums;

namespace CharismaShop.Model
{
    public class Product : BaseEntity
    {
        [Column(TypeName = "nvarchar(300)")]
        public string Title { get; set; }

        [Column(TypeName = "decimal(19, 4)")]
        public decimal Price { get; set; }
        public DeliveryContentType DeliveryContentType { get; set; }
    }
}