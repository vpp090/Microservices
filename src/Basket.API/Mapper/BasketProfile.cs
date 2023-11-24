using AutoMapper;
using Basket.API.Entities;
using BrokerMessagesR.Events;
using BrokerMessagesR.Models;

namespace Basket.API.Mapper
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketCheckout, EventOrderModel>().ReverseMap();
            CreateMap<CheckoutEvent, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
