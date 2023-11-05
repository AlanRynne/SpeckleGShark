using AlanRynne.SpeckleGShark.Core.Converters;
using Microsoft.Extensions.Logging;

namespace AlanRynne.SpeckleGShark.Modules.ToNative.Modules;

public class MeshConverter : ConverterBase<MeshConverter, OG.Mesh, GSG.Mesh>
{
  public MeshConverter(ILogger<MeshConverter> logger) :
    base(logger)
  {
  }

  protected override GSG.Mesh PerformConversion(OG.Mesh obj)
  {
    var vertices = ToNativeUtils.PointListToNative(obj.vertices).ToList();
    var faces = ToNativeUtils.FaceListToNative(obj.faces);
    return new GSG.Mesh(vertices, faces);
  }
}