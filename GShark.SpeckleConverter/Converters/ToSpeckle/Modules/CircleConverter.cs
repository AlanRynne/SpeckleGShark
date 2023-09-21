using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToSpeckle.Modules;

public class CircleConverter : ConverterBase<CircleConverter, GSG.Circle, OG.Circle>,
                               IObjectConverter<GSG.Circle, OG.Circle>
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