using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TradingEngineServer.Core.Configuration;

namespace TradingEngineServer.Core;
sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
{
    private readonly ILogger<TradingEngineServer> _logger;
    private readonly TradingEngineServerConfiguration _config;
    
    public TradingEngineServer(ILogger<TradingEngineServer> logger, IOptions<TradingEngineServerConfiguration> config)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _config = config.Value ?? throw new ArgumentNullException(nameof(config));
    }
    protected Task ExecueAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"{nameof(TradingEngineServer)} is starting.");
        while (!stoppingToken.IsCancellationRequested)
        {
            
        }
        _logger.LogInformation($"{nameof(TradingEngineServer)} is stopping.");
        return Task.CompletedTask;
    }

    public Task Run(CancellationToken token) => ExecuteAsync(token);
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}