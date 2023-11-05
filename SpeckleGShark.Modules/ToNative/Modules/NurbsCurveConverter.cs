using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Converters;

namespace SpeckleGShark.Modules.ToNative.Modules;

public class NurbsCurveConverter : ConverterBase<NurbsCurveConverter, OG.Curve, GSG.NurbsCurve>
{
  public NurbsCurveConverter(ILogger<NurbsCurveConverter> logger) : base(logger)
  {
  }

  protected override GSG.NurbsCurve PerformConversion(OG.Curve obj) =>
    new(ToNativeUtils.PointListToNative(obj.points).ToList(), obj.weights, obj.degree);
}