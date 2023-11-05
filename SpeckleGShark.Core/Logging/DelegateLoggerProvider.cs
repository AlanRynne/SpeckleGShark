using Microsoft.Extensions.Logging;

namespace SpeckleGShark.Core.Logging;

public class DelegateLoggerProvider : ILoggerProvider
{
  private readonly Action<string> _logDelegate;

  public DelegateLoggerProvider(Action<string> logDelegate)
  {
    _logDelegate = logDelegate;
  }

  public ILogger CreateLogger(string categoryName) => new DelegateLogger(categoryName, _logDelegate);

  public void Dispose()
  {
  }
}