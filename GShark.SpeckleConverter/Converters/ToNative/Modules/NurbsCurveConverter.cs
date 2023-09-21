using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToNative.Modules;

public class NurbsCurveConverter : ConverterBase<NurbsCurveConverter, OG.Curve, GSG.NurbsCurve>
{
  public NurbsCurveConverter(ILogger<NurbsCurveConverter> logger) : base(logger)
  {
  }

  protected override GSG.NurbsCurve PerformConversion(OG.Curve obj) => throw new NotImplementedException();
}