using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TradingEngineServer.Core.Configuration;
using TradingEngineServer.Logging;

namespace TradingEngineServer.Core;
sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
{
    private readonly ITextLogger _logger;
    private readonly IOptions<TradingEngineServerConfiguration> _config;
    
    public TradingEngineServer(ITextLogger textLogger, IOptions<TradingEngineServerConfiguration> config)
    {
        _logger = textLogger ?? throw new ArgumentNullException(nameof(textLogger));
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.Information(nameof(TradingEngineServer), $"Starting Trading Engine");
        while (!stoppingToken.IsCancellationRequested)
        {
            
        }
        _logger.Information(nameof(TradingEngineServer), $"Stopping Trading Engine");
        return Task.CompletedTask;
    }

    public Task Run(CancellationToken token) => ExecuteAsync(token);
}