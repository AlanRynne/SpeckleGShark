using Divergic.Logging.Xunit;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace SpeckleGShark.Tests.Converters;

public abstract class ConverterTestsBase<T> : LoggingTestsBase<T>
{
  protected ConverterTestsBase(ITestOutputHelper output, LogLevel logLevel) : base(output, logLevel)
  {
  }

  protected ConverterTestsBase(ITestOutputHelper output, LoggingConfig? config = null) : base(output, config)
  {
  }

  protected T? Converter { get; set; }
}