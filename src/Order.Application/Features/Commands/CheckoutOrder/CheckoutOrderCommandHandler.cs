

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Order.Application.Contracts.Infrastructure;
using Order.Application.Contracts.Persistence;
using Order.Application.Model;

namespace Order.Application.Features.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommand> _logger;
        private readonly IConfiguration _config;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepo, IMapper mapper,
                IEmailService emailService, ILogger<CheckoutOrderCommand> logger,
                IConfiguration config)
        {
            _repository = orderRepo;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
            _config = config;
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Domain.Entities.Order>(request);

            var newOrder = await _repository.AddAsync(orderEntity);

            _logger.LogInformation($"Order: {newOrder.Id} is successfully created");

            await SendMail(newOrder);

            return newOrder.Id;
        }

        private async Task SendMail(Domain.Entities.Order order)
        {
            try
            {
                var emailAddress = _config["MailSettings:Email"];
                var email = new Email { To = emailAddress, Body = $"Order was created with Id: {order.Id}", Subject = $"New Order" };

                await _emailService.SendMail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Order {order.Id} failed due to an error: {ex}");
            }

        }

    }
}
