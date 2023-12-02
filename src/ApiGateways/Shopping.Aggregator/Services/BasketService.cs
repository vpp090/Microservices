using Shopping.Aggregator.Models;
using Shopping.Aggregator.Extensions;

namespace Shopping.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client;
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var response = await _client.GetAsync($"/api/Basket/{userName}");
            var result = await response.ReadContentAs<BasketModel>();

            return result;
        }
    }
}
