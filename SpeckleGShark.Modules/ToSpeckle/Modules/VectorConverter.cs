using Microsoft.Extensions.Logging;
using SpeckleGShark.Core.Converters;

namespace SpeckleGShark.Modules.ToSpeckle.Modules;

public class VectorConverter : ConverterBase<VectorConverter, GSG.Vector3, OG.Vector>
{
  public VectorConverter(ILogger<VectorConverter> logger) : base(logger)
  {
  }

  protected override OG.Vector PerformConversion(GSG.Vector3 obj) => new(obj.X, obj.Y, obj.Z);
}