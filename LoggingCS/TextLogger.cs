using Microsoft.Extensions.Options;

namespace TradingEngineServer.Logging.LoggingConfiguration;

public class TextLogger : AbstractLogger, ITextLogger
{
    private readonly LoggerConfiguration _loggerConfiguration; 
    public TextLogger(IOptions<LoggerConfiguration> loggingConfiguration) : base()
    {
        _loggerConfiguration = loggingConfiguration.Value ??  throw new ArgumentNullException(nameof(loggingConfiguration));
    }
    protected override void Log(LogLevel logLevel, string module, string message)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}