using Shopping.Aggregator.Models;
using Shopping.Aggregator.Extensions;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var response = await _client.GetAsync($"/api/Ordering{userName}");
            var result = await response.ReadContentAs<List<OrderResponseModel>>();

            return result;
        }
    }
}
