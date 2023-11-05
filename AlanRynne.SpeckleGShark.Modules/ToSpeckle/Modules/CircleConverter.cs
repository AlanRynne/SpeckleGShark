using AlanRynne.SpeckleGShark.Core.Converters;
using AlanRynne.SpeckleGShark.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace AlanRynne.SpeckleGShark.Modules.ToSpeckle.Modules;

public class CircleConverter : ConverterBase<CircleConverter, GSG.Circle, OG.Circle>
{
  private readonly IObjectConverter<GSG.Plane, OG.Plane> planeToSpeckle;

  public CircleConverter(IObjectConverter<GSG.Plane, OG.Plane> planeToSpeckle,
                         ILogger<CircleConverter> logger) : base(logger)
  {
    this.planeToSpeckle = planeToSpeckle;
  }

  protected override OG.Circle PerformConversion(GSG.Circle obj) => new(
    planeToSpeckle.Convert(obj.Plane),
    obj.Radius
  );
}