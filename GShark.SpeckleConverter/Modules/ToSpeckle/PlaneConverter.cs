using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Modules;

public class PlaneConverter : ConverterBase,
                              IObjectToNativeConverter<OG.Plane, GSG.Plane>,
                              IObjectToSpeckleConverter<GSG.Plane, OG.Plane>
{
  private readonly IObjectToNativeConverter<OG.Point, GSG.Point3> pointToNative;
  private readonly IObjectToSpeckleConverter<GSG.Point3, OG.Point> pointToSpeckle;
  private readonly IObjectToNativeConverter<OG.Vector, GSG.Vector3> vectorToNative;
  private readonly IObjectToSpeckleConverter<GSG.Vector3, OG.Vector> vectorToSpeckle;

  public PlaneConverter(IObjectToNativeConverter<OG.Point, GSG.Point3> pointToNative,
                        IObjectToSpeckleConverter<GSG.Point3, OG.Point> pointToSpeckle,
                        IObjectToNativeConverter<OG.Vector, GSG.Vector3> vectorToNative,
                        IObjectToSpeckleConverter<GSG.Vector3, OG.Vector> vectorToSpeckle,
                        ILogger<PlaneConverter> logger) : base(logger)
  {
    this.pointToNative = pointToNative;
    this.pointToSpeckle = pointToSpeckle;
    this.vectorToNative = vectorToNative;
    this.vectorToSpeckle = vectorToSpeckle;
  }

  public GSG.Plane Convert(OG.Plane obj) =>
    new(
      pointToNative.Convert(obj.origin),
      vectorToNative.Convert(obj.xdir),
      vectorToNative.Convert(obj.ydir)
    );

  public OG.Plane Convert(GSG.Plane obj)
  {
    return new OG.Plane(
      pointToSpeckle.Convert(obj.Origin),
      vectorToSpeckle.Convert(obj.XAxis),
      vectorToSpeckle.Convert(obj.YAxis),
      vectorToSpeckle.Convert(obj.ZAxis)
    );
  }
}