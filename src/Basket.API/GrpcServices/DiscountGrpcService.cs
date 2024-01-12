using DIscount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _protoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient protoService)
        {
            _protoService = protoService;
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var request = new GetDiscountRequest { ProductName = productName };

            return await _protoService.GetDiscountAsync(request);
        }
    }
}
