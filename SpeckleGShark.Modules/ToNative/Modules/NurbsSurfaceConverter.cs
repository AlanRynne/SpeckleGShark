using Microsoft.Extensions.Logging;

using SpeckleGShark.Core.Context;
using SpeckleGShark.Core.Converters;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Modules.ToNative.Modules;

public class NurbsSurfaceConverter : ContextAwareConverterBase<NurbsSurfaceConverter, OG.Surface, GSG.NurbsSurface>
{
  private readonly IObjectConverter<OG.Point, GSG.Point3> pointConverter;

  public NurbsSurfaceConverter(ILogger<NurbsSurfaceConverter> logger,
                               IConverterContextProvider<GSharkConverterContext> context,
                               IObjectConverter<OG.Point, GSG.Point3> pointConverter) :
    base(logger, context)
  {
    this.pointConverter = pointConverter;
  }

  protected override GSG.NurbsSurface PerformConversion(OG.Surface obj)
  {
    var controlPoints = obj.GetControlPoints();
    var points = controlPoints.Select(group => group.Select(pointConverter.Convert).ToList()).ToList();
    var weights = controlPoints.Select(group => group.Select(pt => pt.weight).ToList()).ToList();

    // TODO: This is lossy, as it's missing the knotVector to initialize with. Issue will be raised on GShark.
    var srf = GSG.NurbsSurface.FromPoints(obj.degreeU, obj.degreeV, points, weights);
    return srf;
  }
}