using AlanRynne.SpeckleGShark.Core.Context;
using AlanRynne.SpeckleGShark.Core.Converters;
using AlanRynne.SpeckleGShark.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace AlanRynne.SpeckleGShark.Modules.ToNative.Modules;

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