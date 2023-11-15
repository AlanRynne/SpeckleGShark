using Microsoft.Extensions.Logging;

using Speckle.Core.Models;

using SpeckleGShark.Core.Converters;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Modules.ToSpeckle;

public class MainConverter : ConverterBase<MainConverter>, IObjectConverter<object, Base>
{
  private readonly IMainCurveConverter curveConverter;
  private readonly IMainSurfaceConverter surfaceConverter;
  private readonly IMainVectorConverter vectorConverter;

  public MainConverter(IMainVectorConverter vectorConverter,
                       IMainCurveConverter curveConverter,
                       IMainSurfaceConverter surfaceConverter,
                       ILogger<MainConverter> logger) : base(logger)
  {
    this.vectorConverter = vectorConverter;
    this.curveConverter = curveConverter;
    this.surfaceConverter = surfaceConverter;
  }

  public Base Convert(object obj)
  {
    return obj switch
    {
      GSG.Point3 pt => vectorConverter.Convert(pt),
      GSG.Vector3 v => vectorConverter.Convert(v),
      GSG.Plane pln => vectorConverter.Convert(pln),
      GSG.Arc arc => curveConverter.Convert(arc),
      GSG.Line line => curveConverter.Convert(line),
      GSG.Circle circle => curveConverter.Convert(circle),
      GSG.NurbsCurve nurbs => curveConverter.Convert(nurbs),
      GSG.Mesh mesh => surfaceConverter.Convert(mesh),
      GSG.NurbsSurface nurbs => surfaceConverter.Convert(nurbs),
      _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
    };
  }
}