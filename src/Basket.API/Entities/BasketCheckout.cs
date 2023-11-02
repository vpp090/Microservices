namespace Basket.API.Entities
{
    public class CheckoutEvent
    {
        public BasketCheckout Checkout { get; set; }
    }
    public class BasketCheckout
    {
        public Guid OrderId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }

        public string Email { get; set; }
        
    }
}
