using EventBus.Messages.Models;

namespace EventBus.Messages.Events
{
    public class BasketCheckoutEvent : IntegrationBaseEvent
    {
        public BasketCheckoutEvent(Guid id, DateTime createDate) : base(id, createDate)
        {
        }

        public OrderModel Order { get; set; }


    }
}
