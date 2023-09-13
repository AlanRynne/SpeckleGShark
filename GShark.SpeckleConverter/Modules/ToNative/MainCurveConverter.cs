using Microsoft.Extensions.Logging;
using Speckle.Core.Models;

namespace GShark.SpeckleConverter.Modules.ToNative;

public class MainConverter : ConverterBase, IObjectToNativeConverter<Base, object>
{
  private IObjectToNativeConverter<OG.Line, GSG.Line> lineConverter;
  private IObjectToNativeConverter<OG.Arc, GSG.Arc> arcConverter;
  private IObjectToNativeConverter<OG.Circle, GSG.Circle> circleConverter;
  private IObjectToNativeConverter<OG.Curve, GSG.NurbsCurve> nurbsConverter;

  public MainConverter(IObjectToNativeConverter<OG.Line, GSG.Line> lineConverter,
                       IObjectToNativeConverter<OG.Arc, GSG.Arc> arcConverter,
                       IObjectToNativeConverter<OG.Circle, GSG.Circle> circleConverter,
                       IObjectToNativeConverter<OG.Curve, GSG.NurbsCurve> nurbsConverter,
                       ILogger logger) : base(logger)
  {
    this.lineConverter = lineConverter;
    this.arcConverter = arcConverter;
    this.circleConverter = circleConverter;
    this.nurbsConverter = nurbsConverter;
  }

  public object Convert(Base obj)
  {
    return obj switch
    {
      OG.Line line     => lineConverter.Convert(line),
      OG.Arc arc       => arcConverter.Convert(arc),
      OG.Circle circle => circleConverter.Convert(circle),
      OG.Curve curve   => nurbsConverter.Convert(curve),
      _                => throw new NotSupportedException($"Conversion of {nameof(obj)} to GShark is not supported")
    };
  }
}