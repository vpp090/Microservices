using AutoMapper;
using BrokerMessagesR.Events;
using BrokerMessagesR.Models;
using Order.Application.Features.Commands.CheckoutOrder;

namespace Order.API.Mapping
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<CheckoutOrderCommand, EventOrderModel>().ReverseMap();
        }
    }
}
