using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Repositories;
using DIscount.Grpc.Protos;
using Grpc.Core;

namespace DIscount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repo, ILogger<DiscountService> logger, IMapper mapper)
        {
            _repository = repo;
            _logger = logger;
            _mapper = mapper;

        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetDiscount(request.ProductName);

            if(coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount not available: {request.ProductName}"));
            }

            var couponModel = _mapper.Map<CouponModel>(coupon);

            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            var result = await _repository.CreateDiscount(coupon);

            if (!result)
                throw new ArgumentException("Cannot create coupon");

            return request.Coupon;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var couponToUpdate = await _repository.GetDiscount(request.Coupon.ProductName);

            couponToUpdate = _mapper.Map<Coupon>(request.Coupon);

            var result = await _repository.UpdateDiscount(couponToUpdate);

            if (!result)
                throw new ArgumentException("Cannot update discount");

            return request.Coupon;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var result = await _repository.DeleteDiscount(request.ProductName);

            if (!result)
                throw new ArgumentException("Cannot delete coupon");

            return new DeleteDiscountResponse { Success = result };
        }
    }
}
