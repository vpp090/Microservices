using AutoMapper;
using Basket.API.Entities;
using BrokerMessagesR.Events;

namespace Basket.API.Mapper
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CheckoutEvent, BasketCheckoutEvent>().ReverseMap();
            
        }
    }
}
