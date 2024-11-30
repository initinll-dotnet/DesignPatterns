using ObjectAdapter;

Console.Title = "Adapter";

// 3rd party external system
var externalSystem = new ExternalSystem();

// object adapter example
ICityAdapter adapter = new CityAdapter(externalSystem);
var city = adapter.GetCity();

Console.WriteLine($"{city.FullName}, {city.Inhabitants}");
Console.ReadKey();