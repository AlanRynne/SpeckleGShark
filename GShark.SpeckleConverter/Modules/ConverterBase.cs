using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Modules.ToNative;

public abstract class ConverterBase
{
  protected ILogger logger { get; }

  protected ConverterBase(ILogger logger)
  {
    this.logger = logger;
  }
}