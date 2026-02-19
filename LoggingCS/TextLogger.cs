using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Options;

namespace TradingEngineServer.Logging.LoggingConfiguration;

public class TextLogger : AbstractLogger, ITextLogger
{
    private readonly LoggerConfiguration _loggerConfiguration; 
    public TextLogger(IOptions<LoggerConfiguration> loggingConfiguration) : base()
    {
        _loggerConfiguration = loggingConfiguration.Value ??  throw new ArgumentNullException(nameof(loggingConfiguration));
        string filepath = string.Empty;
        _ = Task.Run(() => LogAsync(filepath, _logQueue, _tokenSource.Token));
    }

    private static async Task LogAsync(string filepath, BufferBlock<LogInformation> logQueue, CancellationToken token)
    {
        using var fs = new FileStream(filepath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
        using var sw = new StreamWriter(fs);

        try
        {
            while (true)
            {
                var logItem = logQueue.ReceiveAsync(token).ConfigureAwait(false);
                string formattedMessage = FormatLogItem(logItem);
                await sw.WriteAsync(formattedMessage).ConfigureAwait(false);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static string FormatLogItem(LogInformation logItem)
    {
        return $"[{logItem.Now:f}] [{logItem.ThreadName}:{logItem.ThreadId:000}] " + 
               $"[{logItem.LogLevel}] {logItem.Message}";
    }

    protected override void Log(LogLevel logLevel, string module, string message)
    {
        _logQueue.Post(new LogInformation(logLevel, module, message, DateTime.Now,
            Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name));
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
    
    private BufferBlock<LogInformation> _logQueue = new BufferBlock<LogInformation>();
    private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
}