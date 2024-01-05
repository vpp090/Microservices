using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class ShoppingBasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public ShoppingBasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));  
        }

        public async Task<ShoppingBasket> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);

            if (string.IsNullOrWhiteSpace(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingBasket>(basket);
        }

        public async Task<ShoppingBasket> CreateBasket(string userName, ShoppingBasket basket)
        {
            await _redisCache.SetStringAsync(userName, JsonConvert.SerializeObject(basket));

            return basket;
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);

            return true;
        }

        public async Task<ShoppingBasket> UpdateBasket(ShoppingBasket basket)
        {
            await _redisCache.SetStringAsync(basket.Username, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.Username);
        }
    }
}
