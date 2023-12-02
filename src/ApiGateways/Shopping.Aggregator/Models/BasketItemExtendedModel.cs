namespace Shopping.Aggregator.Models
{
    public class BasketItemExtendedModel
    {
        public int Quantity { get; set; }
        public int Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }

        //Extendend product properties comming from catalog and not from the original basket service
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}
