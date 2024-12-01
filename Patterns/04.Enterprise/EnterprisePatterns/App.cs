using EnterprisePatterns.DemoServices;

using Microsoft.Extensions.Logging;

namespace EnterprisePatterns;

public class App
{
    public readonly ILogger<App> _logger;
    private readonly RepositoryDemoService _repositoryDemoService;
    private readonly UnitOfWorkDemoService _unitOfWorkDemoService;

    public App(
        ILogger<App> logger,
        RepositoryDemoService repositoryDemoService,
        UnitOfWorkDemoService unitOfWorkDemoService)
    {
        _logger = logger;
        _repositoryDemoService = repositoryDemoService;
        _unitOfWorkDemoService = unitOfWorkDemoService;
    }

    public async Task ExecuteAsync()
    {
        try
        {
            _logger.LogInformation("Execute Async");

            // Run a demo service
            await _repositoryDemoService.RunAsync();
            await _unitOfWorkDemoService.RunAsync();
        }
        catch (Exception ex)
        {
            // log the exception
            _logger.LogError(ex, "An exception happened while running the integration service.");
        }
    }
}
