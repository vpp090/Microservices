using BrokerMessagesR.Models;

namespace BrokerMessagesR.Events
{
    public class BasketCheckoutEvent : IntegrationBaseEvent
    {
        public BasketCheckoutEvent()
        {
            Order = new EventOrderModel();
        }
        public BasketCheckoutEvent(Guid id, DateTime createDate) : base(id, createDate)
        {
        }

        public EventOrderModel Order { get; set; }


    }
}
