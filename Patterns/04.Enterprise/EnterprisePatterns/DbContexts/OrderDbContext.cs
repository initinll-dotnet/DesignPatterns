using EnterprisePatterns.Entities;

using Microsoft.EntityFrameworkCore;

namespace EnterprisePatterns.DbContexts;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Order>()
            .HasData(
            new(description: "Shopping Spree") { Id = 1 },
            new(description: "Holiday Shopping") { Id = 2 });

        modelBuilder
            .Entity<OrderLine>()
            .HasData(
            new(product: "Shoes", amount: 1) { Id = 1, OrderId = 1 },
            new(product: "Shirt", amount: 2) { Id = 2, OrderId = 1 },
            new(product: "Pants", amount: 1) { Id = 3, OrderId = 1 },
            new(product: "Socks", amount: 5) { Id = 4, OrderId = 1 },
            new(product: "Sunglasses", amount: 1) { Id = 5, OrderId = 2 },
            new(product: "Sunscreen", amount: 2) { Id = 6, OrderId = 2 });

        base.OnModelCreating(modelBuilder);
    }
}
