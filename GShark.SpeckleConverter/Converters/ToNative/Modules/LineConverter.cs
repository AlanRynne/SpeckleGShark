using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToNative.Modules;

public class LineConverter : ConverterBase<LineConverter, OG.Line, GSG.Line>
{
  private readonly IObjectConverter<OG.Point, GSG.Point3> pointToNative;

  public LineConverter(IObjectConverter<OG.Point, GSG.Point3> pointToNative,
                       ILogger<LineConverter> logger) : base(logger)
  {
    this.pointToNative = pointToNative;
  }

  protected override GSG.Line PerformConversion(OG.Line obj) => new(
    pointToNative.Convert(obj.start),
    pointToNative.Convert(obj.end)
  );
}