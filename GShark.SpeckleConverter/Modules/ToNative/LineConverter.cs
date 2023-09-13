using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Modules.ToSpeckle;

public class LineConverter : ConverterBase, 
                             IObjectToNativeConverter<OG.Line, GSG.Line>,
                             IObjectToSpeckleConverter<GSG.Line, OG.Line>
{
  private readonly IObjectToNativeConverter<OG.Point, GSG.Point3> pointToNative;
  private readonly IObjectToSpeckleConverter<GSG.Point3, OG.Point> pointToSpeckle;
    
  public LineConverter(IObjectToNativeConverter<OG.Point, GSG.Point3> pointToNative,
                       IObjectToSpeckleConverter<GSG.Point3, OG.Point> pointToSpeckle,
                       ILogger<LineConverter> logger) : base(logger)
  {
    this.pointToNative = pointToNative;
    this.pointToSpeckle = pointToSpeckle;
  }

  public GSG.Line Convert(OG.Line obj) => new(
    pointToNative.Convert(obj.start),
    pointToNative.Convert(obj.end)
  );

  public OG.Line Convert(GSG.Line obj) => new(
    pointToSpeckle.Convert(obj.StartPoint),
    pointToSpeckle.Convert(obj.EndPoint)
  );
}