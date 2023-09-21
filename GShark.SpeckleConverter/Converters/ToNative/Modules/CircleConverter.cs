using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToNative.Modules;

public class CircleConverter : ConverterBase<CircleConverter, OG.Circle, GSG.Circle>
{
  private readonly IObjectConverter<OG.Plane, GSG.Plane> planeToNative;

  public CircleConverter(IObjectConverter<OG.Plane, GSG.Plane> planeToNative,
                         ILogger<CircleConverter> logger) : base(logger)
  {
    this.planeToNative = planeToNative;
  }

  protected override GSG.Circle PerformConversion(OG.Circle obj) => new(
    planeToNative.Convert(obj.plane),
    obj.radius ?? throw new Exception("Radius of a circle can't be null")
  );
}