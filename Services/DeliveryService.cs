using CharismaShop.Model;
using System.Linq;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CharismaShop.Enums;

namespace CharismaShop.Services
{
    public interface IDeliveryService : IServiceBase<Delivery>
    {
        Task CreateAsync(DeliveryDto dto);
    }

    public class DeliveryService : ServiceBase<Delivery>, IDeliveryService
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public DeliveryService(IServiceProvider serviceProvider,
            IOrderService orderService,
            IMapper mapper) : base(serviceProvider)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task CreateAsync(DeliveryDto dto)
        {
            var delivery = _mapper.Map<Delivery>(dto);
            await DefineDeliveryType(delivery);
            await AddAsync(delivery);
        }

        async Task DefineDeliveryType(Delivery delivery)
        {
            var products = await _orderService.GetAll()
            .Where(a => a.Id == delivery.OrderId)
            .Include(a => a.Items)
            .ThenInclude(a => a.Product)
            .SelectMany(a => a.Items)
            .Select(a => a.Product)
            .ToListAsync();
            if (products.Any(a => a.DeliveryContentType == DeliveryContentType.Fragile))
            {
                delivery.DeliveryType = Enums.DeliveryType.Express;
            }
        }

    }
}