using EnterprisePatterns.DbContexts;
using EnterprisePatterns.Entities;
using EnterprisePatterns.Repositories;

namespace EnterprisePatterns.UnitsOfWork;

public class CreateOrderWithOrderLinesUnitOfWork : UnitOfWork
{
    public IRepository<Order> OrderRepository { get; }
    public IOrderLineRepository OrderLineRepository { get; }

    public CreateOrderWithOrderLinesUnitOfWork(
        OrderDbContext orderDbContext,
        IRepository<Order> orderRepository,
        IOrderLineRepository orderLineRepository) : base(orderDbContext)
    {
        OrderRepository = orderRepository;
        OrderLineRepository = orderLineRepository;
    }
}