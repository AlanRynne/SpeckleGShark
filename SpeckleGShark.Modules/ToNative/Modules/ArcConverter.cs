using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Converters;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Modules.ToNative.Modules;

public class ArcConverter : ConverterBase<ArcConverter, OG.Arc, GSG.Arc>
{
  private readonly IObjectConverter<OG.Point, GSG.Point3> pointToNative;

  public ArcConverter(IObjectConverter<OG.Point, GSG.Point3> pointToNative,
                      ILogger<ArcConverter> logger) : base(logger)
  {
    this.pointToNative = pointToNative;
  }

  protected override GSG.Arc PerformConversion(OG.Arc obj) => new(
    pointToNative.Convert(obj.startPoint),
    pointToNative.Convert(obj.midPoint),
    pointToNative.Convert(obj.endPoint)
  );
}