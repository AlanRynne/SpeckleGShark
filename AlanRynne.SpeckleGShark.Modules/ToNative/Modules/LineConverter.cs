using AlanRynne.SpeckleGShark.Core.Converters;
using AlanRynne.SpeckleGShark.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace AlanRynne.SpeckleGShark.Modules.ToNative.Modules;

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