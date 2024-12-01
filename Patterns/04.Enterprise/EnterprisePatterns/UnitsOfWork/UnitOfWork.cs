using EnterprisePatterns.DbContexts;

namespace EnterprisePatterns.UnitsOfWork;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Rollback();
}

public abstract class UnitOfWork : IUnitOfWork
{
    private readonly OrderDbContext _orderDbContext;

    public UnitOfWork(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public async Task CommitAsync()
    {
        await _orderDbContext.SaveChangesAsync();
    }

    public void Rollback()
    {
        _orderDbContext.ChangeTracker.Clear();
    }
}
