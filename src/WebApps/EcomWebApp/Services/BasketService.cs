using EcomWebApp.Contracts;
using EcomWebApp.Models;
using EcomWebApp.Extensions;

namespace EcomWebApp.Services
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
            var response = await _client.GetAsync($"/Basket/{userName}");

            if (!response.IsSuccessStatusCode)
            {
                var cartModel = new BasketModel
                {
                    Username = userName,

                };

                var res = await _client.PostAsJsonAsync($"/Baske?userName={userName}", cartModel);
                response = await _client.GetAsync($"/Basket/{userName}");
            }

            var result = await response.ReadContentAs<BasketModel>();

            return result;
        }

        public async Task<BasketModel> UpdateBasket(BasketModel model)
        {
            var response = await _client.PutAsJson($"/Basket", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<BasketModel>();
            else
                throw new System.Exception("Something went wrong when calling api");
        }

        public async Task CheckoutBasket(BasketCheckoutModel model)
        {
            var response = await _client.PostAsJson($"/Basket/Checkout", model);
            if (!response.IsSuccessStatusCode)
                throw new System.Exception("Something went wrong when calling api");
        }
    }
}
