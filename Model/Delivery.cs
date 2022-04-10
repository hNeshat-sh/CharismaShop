using   CharismaShop.Enums;

namespace CharismaShop.Model
{
    public class Delivery : BaseEntity
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public DeliveryContentType ContentType { get; set; }
        public DeliveryType DeliveryType { get; set; }

    }

}