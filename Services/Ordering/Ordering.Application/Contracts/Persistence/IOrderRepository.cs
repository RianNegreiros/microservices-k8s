using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Persistence;

public interface IOrderRepository : IRepositoryGeneric<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUsername(string username);
}