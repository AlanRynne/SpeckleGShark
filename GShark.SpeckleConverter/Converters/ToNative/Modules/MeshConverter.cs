using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToNative.Modules;

public class MeshConverter : ConverterBase<MeshConverter, OG.Mesh, GSG.Mesh>
{
  public MeshConverter(ILogger<MeshConverter> logger) : base(logger)
  {
  }

  protected override GSG.Mesh PerformConversion(OG.Mesh obj) => throw new NotImplementedException();
}