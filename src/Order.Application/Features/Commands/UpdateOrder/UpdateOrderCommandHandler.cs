
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Order.Application.Common.CustomExceptions;
using Order.Application.Contracts.Infrastructure;
using Order.Application.Contracts.Persistence;

namespace Order.Application.Features.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {

        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommand> _logger;
        private readonly IEmailService _emailService;

        public UpdateOrderCommandHandler(IOrderRepository repo, ILogger<UpdateOrderCommand> logger,
            IEmailService service, IMapper mapper)
        {
            _repository = repo;
            _logger = logger;
            _emailService = service;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetByIdAsync(request.Id);

            if(currentOrder == null)
            {
                _logger.LogError($"This order id is not found: {request.Id}");
                throw new NotFoundException("This order is not found");
            }

            _mapper.Map(request, currentOrder, typeof(UpdateOrderCommand), typeof(Domain.Entities.Order));

            await _repository.UpdateAsync(currentOrder);

            _logger.LogInformation($"Order {currentOrder.Id} is successfully updated");

            return currentOrder.Id;
        }
    }
}
