using Divergic.Logging.Xunit;
using GShark.SpeckleConverter.Converters;
using Xunit.Abstractions;

namespace GShark.SpeckleConverter.Tests;

public class CachedLoggerConverterTest<T> where T : ConverterBase<T>
{
  protected CachedLoggerConverterTest(ITestOutputHelper output)
  {
    Logger = output.BuildLoggerFor<T>();
  }

  protected T? Converter { get; set; }
  protected ICacheLogger<T> Logger { get; }
}