using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToNative.Modules;

public class VectorConverter : ConverterBase<VectorConverter, OG.Vector, GSG.Vector3>
{
  public VectorConverter(ILogger<VectorConverter> logger) : base(logger)
  {
  }

  protected override GSG.Vector3 PerformConversion(OG.Vector obj) => new(obj.x, obj.y, obj.z);
}