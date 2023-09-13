using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Modules.ToSpeckle;

public class PointConverter : ConverterBase,
                              IObjectToNativeConverter<OG.Point, GSG.Point3>,
                              IObjectToSpeckleConverter<GSG.Point3, OG.Point>
{
  public PointConverter(ILogger<PointConverter> logger) : base(logger)
  {
  }

  public GSG.Point3 Convert(OG.Point obj) => new(obj.x, obj.y, obj.z);

  public OG.Point Convert(GSG.Point3 obj) => new(obj.X, obj.Y, obj.Z);
}