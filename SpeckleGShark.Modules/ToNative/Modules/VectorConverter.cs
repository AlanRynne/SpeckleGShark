using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Context;
using SpeckleGShark.Core.Converters;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Modules.ToNative.Modules;

public class VectorConverter : ContextAwareConverterBase<VectorConverter, OG.Vector, GSG.Vector3>
{
  public VectorConverter(ILogger<VectorConverter> logger, IConverterContextProvider<GSharkConverterContext> context) :
    base(logger, context)
  {
  }

  protected override GSG.Vector3 PerformConversion(OG.Vector obj)
  {
    var conversionFactor = ContextProvider.Peek().GetConversionFactor(obj.units);
    return new GSG.Vector3(obj.x * conversionFactor, obj.y * conversionFactor, obj.z * conversionFactor);
  }
}