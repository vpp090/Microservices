using AutoMapper;
using Discount.Grpc.Entities;
using DIscount.Grpc.Protos;

namespace DIscount.Grpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }   
    }
}
