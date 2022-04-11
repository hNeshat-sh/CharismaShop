using AutoMapper;
using CharismaShop.Model;
using CharismaShop.Dto;

namespace CharismaShop.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDto, Order>();

            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<DeliveryDto, Delivery>();
        }

    }
}