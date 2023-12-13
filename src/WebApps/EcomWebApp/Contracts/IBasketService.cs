using EcomWebApp.Models;

namespace EcomWebApp.Contracts
{
    public interface IBasketService
    {
        Task CheckoutBasket(BasketCheckoutModel model);
        Task<BasketModel> GetBasket(string userName);
        Task<BasketModel> UpdateBasket(BasketModel model);
    }
}
