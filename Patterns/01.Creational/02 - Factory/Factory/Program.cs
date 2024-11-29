using Factory;

Console.Title = "Factory Method";

List<DiscountFactory> factories = 
[
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("BE") 
];

foreach (var factory in factories)
{
    var discountService = factory.CreateDiscountService();

    var log = $"Percentage {discountService.DiscountPercentage} coming from {discountService}";

    Console.WriteLine(log);
}

Console.ReadKey();