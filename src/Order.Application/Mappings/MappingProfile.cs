using AutoMapper;
using Order.Application.Features.Commands.CheckoutOrder;
using Order.Application.Features.Commands.UpdateOrder;
using Order.Application.Features.Queries.GetOrderList;

namespace Order.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Order, OrdersVm>().ReverseMap();
            CreateMap<Domain.Entities.Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Domain.Entities.Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
