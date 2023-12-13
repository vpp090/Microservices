using EcomWebApp.Contracts;
using EcomWebApp.Extensions;
using EcomWebApp.Models;

namespace EcomWebApp.Services
{
    public class OrderService : IOrderService
    {
        private HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var response = await _client.GetAsync($"/Order/{userName}");

            return await response.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}
