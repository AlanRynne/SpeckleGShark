using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToSpeckle.Modules;

public class PlaneConverter : ConverterBase<PlaneConverter, GSG.Plane, OG.Plane>,
                              IObjectConverter<GSG.Plane, OG.Plane>
{
  private readonly IObjectConverter<GSG.Point3, OG.Point> pointToSpeckle;
  private readonly IObjectConverter<GSG.Vector3, OG.Vector> vectorToSpeckle;

  public PlaneConverter(IObjectConverter<GSG.Point3, OG.Point> pointToSpeckle,
                        IObjectConverter<GSG.Vector3, OG.Vector> vectorToSpeckle,
                        ILogger<PlaneConverter> logger) : base(logger)
  {
    this.pointToSpeckle = pointToSpeckle;
    this.vectorToSpeckle = vectorToSpeckle;
  }

  protected override OG.Plane PerformConversion(GSG.Plane obj) => new(
    pointToSpeckle.Convert(obj.Origin),
    vectorToSpeckle.Convert(obj.XAxis),
    vectorToSpeckle.Convert(obj.YAxis),
    vectorToSpeckle.Convert(obj.ZAxis)
  );
}