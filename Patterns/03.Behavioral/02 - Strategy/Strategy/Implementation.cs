namespace Strategy;

/// <summary>
/// Strategy
/// </summary>
public interface IExportService
{
    void Export(Order order);
}

/// <summary>
/// ConcreteStrategy
/// </summary>
public class JsonExportService : IExportService
{
    public void Export(Order order)
    {
        Console.WriteLine($"Exporting {order.Name} to Json.");
    }
}

/// <summary>
/// ConcreteStrategy
/// </summary>
public class XMLExportService : IExportService
{
    public void Export(Order order)
    {
        Console.WriteLine($"Exporting {order.Name} to XML.");
    }
}

/// <summary>
/// ConcreteStrategy
/// </summary>
public class CSVExportService : IExportService
{
    public void Export(Order order)
    {
        Console.WriteLine($"Exporting {order.Name} to CSV.");
    }
}

/// <summary>
/// Context
/// </summary>
public class Order
{
    private readonly IExportService _exportService;

    public Order(
        string customer,
        int amount,
        string name,
        IExportService exportService)
    {
        Customer = customer;
        Amount = amount;
        Name = name;
        _exportService = exportService;
    }
    public string Customer { get; set; }
    public int Amount { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    // Variation 1
    public void Export1()
    {
        _exportService.Export(this);
    }

    // Variation 2
    public void Export2(IExportService exportService)
    {
        if (exportService is null)
        {
            throw new ArgumentNullException(nameof(exportService));
        }

        exportService.Export(this);
    }
}