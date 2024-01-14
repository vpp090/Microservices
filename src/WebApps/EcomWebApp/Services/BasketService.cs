using EcomWebApp.Contracts;
using EcomWebApp.Models;
using EcomWebApp.Extensions;
using SpecMapperR;

namespace EcomWebApp.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;
        private readonly ISpecialMapper _mapper;

        public BasketService(HttpClient client, ISpecialMapper mapper)
        {
            _client = client;
            _mapper = mapper;
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

                var res = await _client.PostAsJsonAsync($"/Basket?username={userName}", cartModel);
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
            var chEvent = new CheckoutEvent();

            chEvent.Checkout = _mapper.MapProperties<BasketCheckoutModel, BasketCheckout>(model);

            var response = await _client.PostAsJson($"/Basket/Checkout", chEvent);
            if (!response.IsSuccessStatusCode)
                throw new System.Exception("Something went wrong when calling api");
        }
    }
}
