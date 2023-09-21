using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToSpeckle;

public interface IMainCurveConverter : IObjectConverter<GSG.Arc, OG.Arc>,
                                       IObjectConverter<GSG.Line, OG.Line>,
                                       IObjectConverter<GSG.Circle, OG.Circle>,
                                       IObjectConverter<GSG.NurbsCurve, OG.Curve>
{
}

public class MainCurveConverter : ConverterBase<MainCurveConverter>, IMainCurveConverter
{
  private readonly IObjectConverter<GSG.Arc, OG.Arc> arcConverter;
  private readonly IObjectConverter<GSG.Circle, OG.Circle> circleConverter;
  private readonly IObjectConverter<GSG.Line, OG.Line> lineConverter;
  private readonly IObjectConverter<GSG.NurbsCurve, OG.Curve> nurbsConverter;

  public MainCurveConverter(ILogger<MainCurveConverter> logger,
                            IObjectConverter<GSG.Arc, OG.Arc> arcConverter,
                            IObjectConverter<GSG.Circle, OG.Circle> circleConverter,
                            IObjectConverter<GSG.Line, OG.Line> lineConverter,
                            IObjectConverter<GSG.NurbsCurve, OG.Curve> nurbsConverter) : base(logger)
  {
    this.arcConverter = arcConverter;
    this.circleConverter = circleConverter;
    this.lineConverter = lineConverter;
    this.nurbsConverter = nurbsConverter;
  }

  public OG.Arc Convert(GSG.Arc obj) => arcConverter.Convert(obj);

  public OG.Circle Convert(GSG.Circle obj) => circleConverter.Convert(obj);

  public OG.Line Convert(GSG.Line obj) => lineConverter.Convert(obj);

  public OG.Curve Convert(GSG.NurbsCurve obj) => nurbsConverter.Convert(obj);
}