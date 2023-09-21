using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToSpeckle.Modules;

public class PointConverter : ConverterBase<PointConverter, GSG.Point3, OG.Point>,
                              IObjectConverter<GSG.Point3, OG.Point>
{
  public PointConverter(ILogger<PointConverter> logger) : base(logger)
  {
  }

  protected override OG.Point PerformConversion(GSG.Point3 obj) => new(obj.X, obj.Y, obj.Z);
}