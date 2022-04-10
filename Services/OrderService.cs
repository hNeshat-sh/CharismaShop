using CharismaShop.Model;

namespace CharismaShop.Services
{
    public interface IOrderService : IServiceBase<Order>
    {

    }
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        public OrderService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task CreateOrderAsync()
        {
            var order = new Order();
            await AddAsync(order);
        }

    }
}