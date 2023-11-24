using AutoMapper;
using BrokerMessagesR.Events;
using MassTransit;
using MassTransit.Serialization;
using MediatR;
using Order.Application.Features.Commands.CheckoutOrder;

namespace Order.API.Consumers
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private ILogger<BasketCheckoutConsumer> _logger; 

        public BasketCheckoutConsumer(IMapper mapper, IMediator mediator, ILogger<BasketCheckoutConsumer> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;

        }
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message.Order);
            var result = await _mediator.Send(command);

            _logger.LogInformation($"BasketCheckoutEvent consumed successfully. New_OrderId: {result}");
        }
    }
}
