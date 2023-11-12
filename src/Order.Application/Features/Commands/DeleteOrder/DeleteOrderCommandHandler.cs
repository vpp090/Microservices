using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Order.Application.Common.CustomExceptions;
using Order.Application.Contracts.Persistence;


namespace Order.Application.Features.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IOrderRepository repo, IMapper mapper, ILogger<DeleteOrderCommandHandler> logger)
        {
            _repository = repo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var delOrder = await _repository.GetByIdAsync(request.Id);

            if (delOrder == null)
                throw new NotFoundException($"DeleteOrder_NotFound: {request.Id}");

            await _repository.DeleteAsync(delOrder);

            _logger.LogInformation($"OrderId_Deleted: {request.Id}"); 

            return true;
        }
    }
}
