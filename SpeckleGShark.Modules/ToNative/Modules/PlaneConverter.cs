using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Converters;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Modules.ToNative.Modules;

public class PlaneConverter : ConverterBase<PlaneConverter, OG.Plane, GSG.Plane>
{
  private readonly IObjectConverter<OG.Point, GSG.Point3> pointToNative;
  private readonly IObjectConverter<OG.Vector, GSG.Vector3> vectorToNative;

  public PlaneConverter(IObjectConverter<OG.Point, GSG.Point3> pointToNative,
                        IObjectConverter<OG.Vector, GSG.Vector3> vectorToNative,
                        ILogger<PlaneConverter> logger) : base(logger)
  {
    this.pointToNative = pointToNative;
    this.vectorToNative = vectorToNative;
  }

  protected override GSG.Plane PerformConversion(OG.Plane obj) => new(
    pointToNative.Convert(obj.origin),
    vectorToNative.Convert(obj.xdir),
    vectorToNative.Convert(obj.ydir)
  );
}