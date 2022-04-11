using CharismaShop.Model;
using System.Linq;
using System;

namespace CharismaShop.Services
{
    public interface IDeliveryService : IServiceBase<Delivery>
    {

    }
    public class DeliveryService : ServiceBase<Delivery>, IDeliveryService
    {
        public DeliveryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

    }
}