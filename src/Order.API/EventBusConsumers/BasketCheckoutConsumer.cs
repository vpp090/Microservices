using BrokerMessagesR.Events;
using MassTransit;

namespace Order.API.Consumers
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        public Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
