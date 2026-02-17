namespace TradineEngineServer.Core;

interface ITradingEngineServer
{
    Task Run(CancellationToken token);
    
}