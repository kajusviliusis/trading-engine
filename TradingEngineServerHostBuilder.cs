using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TradingEngineServer.Core.Configuration;
using TradingEngineServer.Logging;
using TradingEngineServer.Logging.LoggingConfiguration;

namespace TradingEngineServer.Core;

public sealed class TradingEngineServerHostBuilder
{
   public static IHost BuildTradingEngineServer() => Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
   {
      services.AddOptions();
      services.Configure<TradingEngineServerConfiguration>(context.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));
      services.Configure<LoggerConfiguration>(context.Configuration.GetSection(nameof(LoggerConfiguration)));

      services.AddSingleton<ITradingEngineServer, global::TradingEngineServer.Core.TradingEngineServer>();
      services.AddSingleton<ITextLogger, TextLogger>();
      
      services.AddHostedService<global::TradingEngineServer.Core.TradingEngineServer>();
      
      
   }).Build();

}