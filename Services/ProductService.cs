using CharismaShop.Model;

namespace CharismaShop.Services
{
    public interface IProductService : IServiceBase<Product>
    {

    }
    public class ProductService : ServiceBase<Product>, IProductService
    {
        public ProductService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

    }
}