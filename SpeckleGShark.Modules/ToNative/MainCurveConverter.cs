using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Converters;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Modules.ToNative;

public interface IMainCurveConverter : IObjectConverter<OG.Line, GSG.Line>,
                                       IObjectConverter<OG.Arc, GSG.Arc>,
                                       IObjectConverter<OG.Circle, GSG.Circle>,
                                       IObjectConverter<OG.Curve, GSG.NurbsCurve>
{
}

public class MainCurveConverter : ConverterBase<MainCurveConverter>, IMainCurveConverter
{
  private readonly IObjectConverter<OG.Arc, GSG.Arc> arcConverter;
  private readonly IObjectConverter<OG.Circle, GSG.Circle> circleConverter;
  private readonly IObjectConverter<OG.Line, GSG.Line> lineConverter;
  private readonly IObjectConverter<OG.Curve, GSG.NurbsCurve> nurbsConverter;

  public MainCurveConverter(IObjectConverter<OG.Line, GSG.Line> lineConverter,
                            IObjectConverter<OG.Arc, GSG.Arc> arcConverter,
                            IObjectConverter<OG.Circle, GSG.Circle> circleConverter,
                            IObjectConverter<OG.Curve, GSG.NurbsCurve> nurbsConverter,
                            ILogger<MainCurveConverter> logger) : base(logger)
  {
    this.lineConverter = lineConverter;
    this.arcConverter = arcConverter;
    this.circleConverter = circleConverter;
    this.nurbsConverter = nurbsConverter;
  }

  public GSG.Line Convert(OG.Line obj) => lineConverter.Convert(obj);

  public GSG.Arc Convert(OG.Arc obj) => arcConverter.Convert(obj);

  public GSG.Circle Convert(OG.Circle obj) => circleConverter.Convert(obj);

  public GSG.NurbsCurve Convert(OG.Curve obj) => nurbsConverter.Convert(obj);
}