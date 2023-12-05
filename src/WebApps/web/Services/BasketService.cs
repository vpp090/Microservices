using AspnetRunBasics.Contracts;
using AspnetRunBasics.Models;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        public Task CheckoutBasket(BasketCheckoutModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<BasketModel> GetBasket(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<BasketModel> UpdateBasket(BasketModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
