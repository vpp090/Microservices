namespace EcomWebApp.Models
{
    public class CheckoutEvent
    {
        public BasketCheckout Checkout { get; set; }
    }

    public class BasketCheckout
    {
        public int Id { get; set; }
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

    public class BasketCheckoutModel
    {
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

        public decimal TotalPrice { get; set; }

        public string Expiration { get; set; }

        public string ZipCode { get; set; }

        public string State { get; set; }
    }
}
