using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Context;
using SpeckleGShark.Core.Converters;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Modules.ToNative.Modules;

public class CircleConverter : ContextAwareConverterBase<CircleConverter, OG.Circle, GSG.Circle>
{
  private readonly IObjectConverter<OG.Plane, GSG.Plane> planeToNative;

  public CircleConverter(IObjectConverter<OG.Plane, GSG.Plane> planeToNative,
                         ILogger<CircleConverter> logger,
                         IConverterContextProvider<GSharkConverterContext> context) : base(logger, context)
  {
    this.planeToNative = planeToNative;
  }

  protected override GSG.Circle PerformConversion(OG.Circle obj)
  {
    var radius = obj.radius ?? throw new Exception("Radius of a circle can't be null");
    return new GSG.Circle(
      planeToNative.Convert(obj.plane),
      radius * ContextProvider.Peek().GetConversionFactor(obj.units)
    );
  }
}