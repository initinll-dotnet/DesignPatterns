using Strategy;

Console.Title = "Strategy";

var order = new Order(
    customer: "Marvin Software", 
    amount: 5, 
    name: "Visual Studio License", 
    exportService: new CSVExportService());
// Variation 1
order.Export1();
// Variation 2
order.Export2(new CSVExportService());

order = new Order(
    customer: "Marvin Software",
    amount: 5,
    name: "Visual Studio License",
    exportService: new JsonExportService());
// Variation 1
order.Export1();
// Variation 2
order.Export2(new JsonExportService());

Console.ReadKey();