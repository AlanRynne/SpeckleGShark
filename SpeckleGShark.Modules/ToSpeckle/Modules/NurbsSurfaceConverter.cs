using GShark.Enumerations;
using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Converters;

namespace SpeckleGShark.Modules.ToSpeckle.Modules;

public class NurbsSurfaceConverter : ConverterBase<NurbsSurfaceConverter, GSG.NurbsSurface, OG.Surface>
{
  public NurbsSurfaceConverter(ILogger<NurbsSurfaceConverter> logger) : base(logger)
  {
  }

  protected override OG.Surface PerformConversion(GSG.NurbsSurface obj)
  {
    return new OG.Surface
    {
      closedU = obj.IsClosed(SurfaceDirection.U),
      closedV = obj.IsClosed(SurfaceDirection.V),
      knotsU = obj.KnotsU.ToList(),
      knotsV = obj.KnotsV.ToList(),
      pointData = obj.ControlPoints
                     .SelectMany(list => list.SelectMany(pt => new List<double> { pt.X, pt.Y, pt.Z, pt.W })).ToList()
    };
  }
}