namespace TradingEngineServer.Logging;

abstract class AbstractLogger : ILogger
{
    protected abstract Log(LogLevel logLevel, string module, string message);
}