using AlanRynne.SpeckleGShark.Core.Converters;
using AlanRynne.SpeckleGShark.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace AlanRynne.SpeckleGShark.Modules.ToNative.Modules;

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