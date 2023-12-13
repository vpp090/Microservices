using EcomWebApp.Models;

namespace EcomWebApp.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
