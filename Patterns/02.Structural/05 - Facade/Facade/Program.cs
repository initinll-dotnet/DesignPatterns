using Facade;

Console.Title = "Facade";


var orderService = new OrderService();
var customerDiscountBaseService = new CustomerDiscountBaseService();
var dayOfTheWeekFactorService = new DayOfTheWeekFactorService();

var facade = new DiscountFacade(
    orderService,
    customerDiscountBaseService,
    dayOfTheWeekFactorService);

Console.WriteLine($"Discount percentage for customer with id 1: " +
    $"{facade.CalculateDiscountPercentage(1)}");

Console.WriteLine($"Discount percentage for customer with id 10: " +
    $"{facade.CalculateDiscountPercentage(10)}");

Console.ReadKey();