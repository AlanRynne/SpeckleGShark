using AlanRynne.SpeckleGShark.Core.Converters;
using AlanRynne.SpeckleGShark.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace AlanRynne.SpeckleGShark.Modules.ToSpeckle.Modules;

public class ArcConverter : ConverterBase<ArcConverter, GSG.Arc, OG.Arc>
{
  private readonly IObjectConverter<GSG.Plane, OG.Plane> planeToSpeckle;
  private readonly IObjectConverter<GSG.Point3, OG.Point> pointToSpeckle;

  public ArcConverter(IObjectConverter<GSG.Point3, OG.Point> pointToSpeckle,
                      IObjectConverter<GSG.Plane, OG.Plane> planeToSpeckle,
                      ILogger<ArcConverter> logger) : base(logger)
  {
    this.pointToSpeckle = pointToSpeckle;
    this.planeToSpeckle = planeToSpeckle;
  }

  protected override OG.Arc PerformConversion(GSG.Arc obj) => new(
    planeToSpeckle.Convert(obj.Plane),
    pointToSpeckle.Convert(obj.StartPoint),
    pointToSpeckle.Convert(obj.EndPoint),
    obj.Angle
  );
}