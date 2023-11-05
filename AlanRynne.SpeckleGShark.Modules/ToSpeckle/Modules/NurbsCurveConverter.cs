using AlanRynne.SpeckleGShark.Core.Converters;
using Microsoft.Extensions.Logging;

namespace AlanRynne.SpeckleGShark.Modules.ToSpeckle.Modules;

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