using Order.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository()
        {

        }

        public async Task<Domain.Entities.Order> AddAsync(Domain.Entities.Order entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Domain.Entities.Order entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Domain.Entities.Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Domain.Entities.Order>> GetAsync(Expression<Func<Domain.Entities.Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Domain.Entities.Order>> GetAsync(Expression<Func<Domain.Entities.Order, bool>> predicate = null, Func<IQueryable<Domain.Entities.Order>, IOrderedQueryable<Domain.Entities.Order>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Domain.Entities.Order>> GetAsync(Expression<Func<Domain.Entities.Order, bool>> predicate = null, Func<IQueryable<Domain.Entities.Order>, IOrderedQueryable<Domain.Entities.Order>> orderBy = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Domain.Entities.Order>> GetOrderByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Domain.Entities.Order entity)
        {
            throw new NotImplementedException();
        }


    }
}
