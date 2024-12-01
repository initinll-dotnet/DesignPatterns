using System.ComponentModel.DataAnnotations.Schema;

namespace EnterprisePatterns.Entities;

[Table("OrderLines")]
public class OrderLine
{
    public OrderLine(string product, int amount)
    {
        Product = product;
        Amount = amount;
    }

    public int Id { get; set; }
    public string Product { get; set; }
    public int Amount { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
}