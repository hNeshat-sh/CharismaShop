using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CharismaShop.Model;
using CharismaShop.Dto;

namespace CharismaShop.Services
{
    public interface IOrderService : IServiceBase<Order>
    {
        Task CreateOrderAsync(OrderDto dto);
    }
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public OrderService(IServiceProvider serviceProvider,
            IMapper mapper,
            IProductService productService) : base(serviceProvider)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task CreateOrderAsync(OrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            await CalculateOrderPrice(order);
            await AddAsync(order);
        }

        async Task CalculateOrderPrice(Order order)
        {
            //TODO: need cache
            var products = await _productService.GetAll()
                .Where(a => order.Items.Select(a => a.ProductId).Distinct().ToArray().Contains(a.Id))
                .ToDictionaryAsync(a => a.Id, a => a.Price);
            decimal totalPrice = 0;
            foreach (var item in order.Items)
            {
                totalPrice += products[item.ProductId] * (decimal)item.Quantity;
            }
            order.Price = totalPrice;
        }
    }
}