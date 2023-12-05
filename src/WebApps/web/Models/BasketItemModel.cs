namespace AspnetRunBasics.Models
{
    public class BasketItemModel
    {
        public int Quantity { get; set; }
        public int Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
