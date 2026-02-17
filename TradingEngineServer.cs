using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TradineEngineServer.Core.Configuration;

namespace TradineEngineServer.Core;
class TradingEngineServer : BackgroundService, ITradingEngineServer
{
    private readonly ILogger<TradingEngineServer> _logger;
    private readonly TradingEngineServerConfiguration _config;
    
    public TradingEngineServer(ILogger<TradingEngineServer> logger, IOptions<TradingEngineServerConfiguration> config)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _config = config.Value ?? throw new ArgumentNullException(nameof(config));
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            
        }
        return Task.CompletedTask;
    }

    public Task Run(CancellationToken token) => ExecuteAsync(token);
}
