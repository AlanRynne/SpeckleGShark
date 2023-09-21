using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToSpeckle.Modules;

public class VectorConverter : ConverterBase<VectorConverter, GSG.Vector3, OG.Vector>,
                               IObjectConverter<GSG.Vector3, OG.Vector>
{
  public VectorConverter(ILogger<VectorConverter> logger) : base(logger)
  {
  }

  protected override OG.Vector PerformConversion(GSG.Vector3 obj) => new(obj.X, obj.Y, obj.Z);
}