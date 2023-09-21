using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToSpeckle.Modules;

public class NurbsCurveConverter : ConverterBase<NurbsCurveConverter, GSG.NurbsCurve, OG.Curve>,
                                   IObjectConverter<GSG.NurbsCurve, OG.Curve>
{
  public NurbsCurveConverter(ILogger<NurbsCurveConverter> logger) : base(logger)
  {
  }

  protected override OG.Curve PerformConversion(GSG.NurbsCurve obj) => throw new NotImplementedException();
}