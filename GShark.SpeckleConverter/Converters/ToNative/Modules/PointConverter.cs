using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToNative.Modules;

public class PointConverter : ConverterBase<PointConverter, OG.Point, GSG.Point3>
{
  public PointConverter(ILogger<PointConverter> logger) : base(logger)
  {
  }

  protected override GSG.Point3 PerformConversion(OG.Point obj) => new(obj.x, obj.y, obj.z);
}