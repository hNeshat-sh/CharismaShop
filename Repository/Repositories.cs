using CharismaShop.Model;
using CharismaShop.Data;

namespace CharismaShop.Repository
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(AppDbContext dbContext) :
        base(dbContext)
        { }
    }

    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(AppDbContext dbContext) :
        base(dbContext)
        { }
    }
}