using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Modules;

public class CircleConverter : ConverterBase,
                               IObjectToNativeConverter<OG.Circle, GSG.Circle>,
                               IObjectToSpeckleConverter<GSG.Circle, OG.Circle>
{
  private readonly IObjectToNativeConverter<OG.Plane, GSG.Plane> planeToNative;
  private readonly IObjectToSpeckleConverter<GSG.Plane, OG.Plane> planeToSpeckle;

  public CircleConverter(IObjectToNativeConverter<OG.Plane, GSG.Plane> planeToNative,
                         IObjectToSpeckleConverter<GSG.Plane, OG.Plane> planeToSpeckle,
                         ILogger<CircleConverter> logger) : base(logger)
  {
    this.planeToNative = planeToNative;
    this.planeToSpeckle = planeToSpeckle;
  }
  
  public GSG.Circle Convert(OG.Circle obj) => new(
    planeToNative.Convert(obj.plane),
    obj.radius ?? throw new Exception("Radius of a circle can't be null")
  );

  public OG.Circle Convert(GSG.Circle obj) => new(
    planeToSpeckle.Convert(obj.Plane),
    obj.Radius
  );
}