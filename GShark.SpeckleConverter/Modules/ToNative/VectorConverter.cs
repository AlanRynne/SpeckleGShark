using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Modules.ToSpeckle;

public class VectorConverter : ConverterBase,
                               IObjectToNativeConverter<OG.Vector, GSG.Vector3>,
                               IObjectToSpeckleConverter<GSG.Vector3, OG.Vector>
{
  public VectorConverter(ILogger<VectorConverter> logger) : base(logger)
  {
  }

  public GSG.Vector3 Convert(OG.Vector obj) => new(obj.x, obj.y, obj.z);

  public OG.Vector Convert(GSG.Vector3 obj) => new(obj.X, obj.Y, obj.Z);
}