using EnterprisePatterns;

using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddPatternDependencies();

var serviceProvider = services.BuildServiceProvider();

var appService = serviceProvider.GetRequiredService<App>();
await appService.ExecuteAsync();



