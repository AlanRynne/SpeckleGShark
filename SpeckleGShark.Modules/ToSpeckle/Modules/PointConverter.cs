using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Converters;

namespace SpeckleGShark.Modules.ToSpeckle.Modules;

public class PointConverter : ConverterBase<PointConverter, GSG.Point3, OG.Point>
{
  public PointConverter(ILogger<PointConverter> logger) : base(logger)
  {
  }

  protected override OG.Point PerformConversion(GSG.Point3 obj) => new(obj.X, obj.Y, obj.Z);
}