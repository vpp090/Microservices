namespace Basket.API.Entities
{
    public class ShoppingBasketItem
    {
        public string ProductName { get; set; }
        public Color Color { get; set; }

        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public enum Color
    {
        Blue,
        Red,
        Green
    }
}
