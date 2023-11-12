using Microsoft.EntityFrameworkCore;
using Order.Application.Contracts.Persistence;
using Order.Infrastructure.Persistence;

namespace Order.Infrastructure.Repositories.cs
{
    public class OrderRepository : RepositoryBase<Domain.Entities.Order>, IOrderRepository
    {
        
        public OrderRepository(OrderContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Entities.Order>> GetOrderByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                        .Where(o => o.UserName == userName)
                                        .ToListAsync();

            return orderList;
        }
    }
}
