using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToSpeckle.Modules;

public class MeshConverter : ConverterBase<MeshConverter, GSG.Mesh, OG.Mesh>,
                             IObjectConverter<GSG.Mesh, OG.Mesh>
{
  public MeshConverter(ILogger<MeshConverter> logger) : base(logger)
  {
  }

  protected override OG.Mesh PerformConversion(GSG.Mesh obj) => throw new NotImplementedException();
}