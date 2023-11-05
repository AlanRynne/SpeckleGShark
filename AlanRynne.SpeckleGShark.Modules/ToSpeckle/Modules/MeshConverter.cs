using AlanRynne.SpeckleGShark.Core.Converters;
using Microsoft.Extensions.Logging;

namespace AlanRynne.SpeckleGShark.Modules.ToSpeckle.Modules;

public class MeshConverter : ConverterBase<MeshConverter, GSG.Mesh, OG.Mesh>
{
  public MeshConverter(ILogger<MeshConverter> logger) : base(logger)
  {
  }

  protected override OG.Mesh PerformConversion(GSG.Mesh obj)
  {
    var mesh = new OG.Mesh();

    mesh.vertices = obj.Vertices.SelectMany(vertex => new List<double> { vertex.X, vertex.Y, vertex.Z }).ToList();
    mesh.faces = obj.Faces.SelectMany(face =>
    {
      var vertexIndices = face.AdjacentVertices().Select(vertex => vertex.Index).ToList();
      var flat = new List<int> { vertexIndices.Count };
      flat.AddRange(vertexIndices);
      return flat;
    }).ToList();

    return mesh;
  }
}