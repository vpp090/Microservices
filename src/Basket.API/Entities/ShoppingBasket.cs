namespace Basket.API.Entities
{
    public class ShoppingBasket
    {
        public Guid BasketId { get; set; }
        public string Username { get; set; }

        public decimal TotalPrice => Items.Sum(p => p.Price * p.Quantity);
        public List<ShoppingBasketItem> Items { get; set; } = new List<ShoppingBasketItem>();

        public ShoppingBasket(string userName)
        {
            Username = userName;
        }
    }
}
