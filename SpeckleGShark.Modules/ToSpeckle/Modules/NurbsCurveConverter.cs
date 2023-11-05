using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Converters;

namespace SpeckleGShark.Modules.ToSpeckle.Modules;

public class NurbsCurveConverter : ConverterBase<NurbsCurveConverter, GSG.NurbsCurve, OG.Curve>
{
  public NurbsCurveConverter(ILogger<NurbsCurveConverter> logger) : base(logger)
  {
  }

  protected override OG.Curve PerformConversion(GSG.NurbsCurve obj) => new()
  {
    points = obj.ControlPointLocations.SelectMany(pt => new List<double> { pt.X, pt.Y, pt.Z }).ToList(),
    weights = obj.Weights,
    knots = obj.Knots.ToList()
  };
}