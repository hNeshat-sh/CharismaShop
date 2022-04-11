using System;
using System.Linq;
using CharismaShop.Model;
using CharismaShop.Dto;
using AutoMapper;

namespace CharismaShop.Services
{
    public interface IOrderService : IServiceBase<Order>
    {
        Task CreateOrderAsync(OrderDto dto);
    }
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        private readonly IMapper _mapper;
        public OrderService(IServiceProvider serviceProvider, 
            IMapper mapper) : base(serviceProvider)
        {
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(OrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            await AddAsync(order);
        }
    }
}