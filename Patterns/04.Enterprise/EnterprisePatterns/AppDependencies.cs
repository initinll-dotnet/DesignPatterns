using EnterprisePatterns.DbContexts;
using EnterprisePatterns.DemoServices;
using EnterprisePatterns.Entities;
using EnterprisePatterns.Repositories;
using EnterprisePatterns.UnitsOfWork;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EnterprisePatterns;

public static class AppDependencies
{
    public static IServiceCollection AddPatternDependencies(this IServiceCollection services)
    {
        services.AddLogging(configure => configure.AddDebug().AddConsole());

        // Using In-Memory database for testing
        services.AddDbContext<OrderDbContext>(options =>
            options.UseInMemoryDatabase("TestDb"));

        services.AddScoped<RepositoryDemoService>();
        services.AddScoped<UnitOfWorkDemoService>();

        //services.AddScoped<IRepository<Order>, GenericOrderRepository>();
        services.AddScoped<IRepository<Order>, GenericEFCoreRepository<Order>>();
        services.AddScoped<IOrderLineRepository, OrderLineRepository>();

        services.AddScoped<CreateOrderWithOrderLinesUnitOfWork>();

        services.AddScoped<App>();

        return services;
    }
}
