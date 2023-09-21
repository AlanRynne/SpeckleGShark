using Microsoft.Extensions.Logging;
using Objects.Other;
using GSC = GShark.Core;

namespace GShark.SpeckleConverter.Converters.ToNative.Modules;

public class TransformConverter : ConverterBase<TransformConverter, Transform, GSC.TransformMatrix>
{
  public TransformConverter(ILogger<TransformConverter> logger) : base(logger)
  {
  }

  protected override GSC.TransformMatrix PerformConversion(Transform obj) => new(obj.ToArray());
}