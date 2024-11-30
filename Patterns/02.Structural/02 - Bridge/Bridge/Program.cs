using Bridge;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneEuroCoupon = new OneEuroCoupon();
var twoEuroCoupon = new TwoEuroCoupon();

// no discount coupon orignal meat price
var meatBasedMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro.");

// one euro discount coupon discounted meat price
meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
Console.WriteLine($"Meat based menu, one euro coupon: {meatBasedMenu.CalculatePrice()} euro.");

// no discount coupon orignal vegetarian price
var vegetarianMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian menu, no coupon: {vegetarianMenu.CalculatePrice()} euro.");

// two euro discount coupon discounted vegetarian price
vegetarianMenu = new VegetarianMenu(twoEuroCoupon);
Console.WriteLine($"Vegetarian menu, two euro coupon: {vegetarianMenu.CalculatePrice()} euro.");

Console.ReadKey();