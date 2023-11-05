using System.Reactive.Disposables;
using Microsoft.Extensions.Logging;

namespace AlanRynne.SpeckleGShark.Core.Logging;

public class DelegateLogger : ILogger
{
  private readonly string _categoryName;
  private readonly Action<string> _logDelegate;

  public DelegateLogger(string categoryName, Action<string> logDelegate)
  {
    _categoryName = categoryName;
    _logDelegate = logDelegate;
  }

  public IDisposable BeginScope<tState>(tState state) where tState : notnull => Disposable.Empty;

  public bool IsEnabled(LogLevel logLevel) => true;

  public void Log<TState>(LogLevel logLevel,
                          EventId eventId,
                          TState state,
                          Exception? exception,
                          Func<TState, Exception, string> formatter)
  {
    if (!IsEnabled(logLevel)) return;

    var logMessage = formatter(state, exception);
    _logDelegate($"[{_categoryName}] {logLevel}: {logMessage}");
  }
}