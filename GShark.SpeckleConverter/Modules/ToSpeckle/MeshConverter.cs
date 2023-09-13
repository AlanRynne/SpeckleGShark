using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Modules;

public class MeshConverter : ConverterBase,
                             IObjectToNativeConverter<OG.Mesh, GSG.Mesh>,
                             IObjectToSpeckleConverter<GSG.Mesh, OG.Mesh>
{
  public MeshConverter(ILogger logger) : base(logger)
  {
  }

  public GSG.Mesh Convert(OG.Mesh obj)
  {
    throw new NotImplementedException();
  }

  public OG.Mesh Convert(GSG.Mesh obj)
  {
    throw new NotImplementedException();
  }
}