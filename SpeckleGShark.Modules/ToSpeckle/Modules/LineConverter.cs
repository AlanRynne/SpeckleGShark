using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Converters;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Modules.ToSpeckle.Modules;

public class LineConverter : ConverterBase<LineConverter, GSG.Line, OG.Line>
{
  private readonly IObjectConverter<GSG.Point3, OG.Point> pointToSpeckle;

  public LineConverter(IObjectConverter<GSG.Point3, OG.Point> pointToSpeckle,
                       ILogger<LineConverter> logger) : base(logger)
  {
    this.pointToSpeckle = pointToSpeckle;
  }

  protected override OG.Line PerformConversion(GSG.Line obj) => new(
    pointToSpeckle.Convert(obj.StartPoint),
    pointToSpeckle.Convert(obj.EndPoint)
  );
}