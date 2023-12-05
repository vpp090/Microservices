using AspnetRunBasics.Models;
using System.Threading.Tasks;

namespace AspnetRunBasics.Contracts
{
    public interface IBasketService
    {
        Task CheckoutBasket(BasketCheckoutModel model);
        Task<BasketModel> GetBasket(string userName);
        Task<BasketModel> UpdateBasket(BasketModel model);
    }
}
