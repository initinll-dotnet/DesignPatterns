using System.ComponentModel.DataAnnotations.Schema;

namespace EnterprisePatterns.Entities;

[Table("Orders")]
public class Order
{
    public Order(string? description)
    {
        Description = description;
    }

    public int Id { get; set; }
    public string? Description { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; } = [];    
}