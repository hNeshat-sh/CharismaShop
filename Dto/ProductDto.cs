using CharismaShop.Enums;

namespace CharismaShop.Dto
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DeliveryContentType DeliveryContentType { get; set; }
    }
}