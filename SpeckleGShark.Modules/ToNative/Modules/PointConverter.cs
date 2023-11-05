using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Context;
using SpeckleGShark.Core.Converters;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Modules.ToNative.Modules;

public class PointConverter : ContextAwareConverterBase<PointConverter, OG.Point, GSG.Point3>
{
  public PointConverter(ILogger<PointConverter> logger,
                        IConverterContextProvider<GSharkConverterContext> contextProvider) :
    base(logger, contextProvider)
  {
  }

  protected override GSG.Point3 PerformConversion(OG.Point obj)
  {
    var conversionFactor = ContextProvider.Peek().GetConversionFactor(obj.units);
    return new GSG.Point3(obj.x * conversionFactor, obj.y * conversionFactor, obj.z * conversionFactor);
  }
}