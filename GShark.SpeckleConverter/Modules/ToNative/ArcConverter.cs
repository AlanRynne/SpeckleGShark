using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Modules.ToSpeckle;

public class ArcConverter : ConverterBase,
                            IObjectToNativeConverter<OG.Arc, GSG.Arc>,
                            IObjectToSpeckleConverter<GSG.Arc, OG.Arc>
{
  private readonly IObjectToNativeConverter<OG.Point, GSG.Point3> pointToNative;
  private readonly IObjectToSpeckleConverter<GSG.Point3, OG.Point> pointToSpeckle;
  private readonly IObjectToSpeckleConverter<GSG.Plane, OG.Plane> planeToSpeckle;

  public ArcConverter(IObjectToNativeConverter<OG.Point, GSG.Point3> pointToNative,
                      IObjectToSpeckleConverter<GSG.Point3, OG.Point> pointToSpeckle,
                      IObjectToSpeckleConverter<GSG.Plane, OG.Plane> planeToSpeckle,
                      ILogger<ArcConverter> logger): base(logger)
  {
    this.pointToNative = pointToNative;
    this.pointToSpeckle = pointToSpeckle;
    this.planeToSpeckle = planeToSpeckle;
  }

  public GSG.Arc Convert(OG.Arc obj) =>
    new(
      pointToNative.Convert(obj.startPoint),
      pointToNative.Convert(obj.midPoint),
      pointToNative.Convert(obj.endPoint)
    );

  public OG.Arc Convert(GSG.Arc obj) =>
    new(
      planeToSpeckle.Convert(obj.Plane),
      pointToSpeckle.Convert(obj.StartPoint),
      pointToSpeckle.Convert(obj.EndPoint),
      obj.Angle
    );
}