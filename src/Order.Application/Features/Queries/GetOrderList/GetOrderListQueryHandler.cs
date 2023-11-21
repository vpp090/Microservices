using AutoMapper;
using MediatR;
using Order.Application.Contracts.Persistence;

namespace Order.Application.Features.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrdersVm>>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderRepository repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        public async Task<List<OrdersVm>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _repository.GetOrderByUserName(request.UserName);

            var mappedOrders = orderList.Select(_mapper.Map<Domain.Entities.Order, OrdersVm>).ToList();

            return mappedOrders;
        }
    }
}
