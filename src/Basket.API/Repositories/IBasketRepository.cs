using Basket.API.Entities;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingBasket> GetBasket(string userName);
        Task<ShoppingBasket> CreateBasket(string userName, ShoppingBasket basket);
        Task<ShoppingBasket> UpdateBasket(ShoppingBasket basket);
        Task<bool> DeleteBasket(string userName);
    }
}
