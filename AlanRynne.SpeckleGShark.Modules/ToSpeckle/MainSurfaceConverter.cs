using AlanRynne.SpeckleGShark.Core.Converters;
using AlanRynne.SpeckleGShark.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace AlanRynne.SpeckleGShark.Modules.ToSpeckle;

public interface IMainSurfaceConverter :
  IObjectConverter<GSG.NurbsSurface, OG.Surface>,
  IObjectConverter<GSG.Mesh, OG.Mesh>
{
}

public class MainSurfaceConverter : ConverterBase<MainSurfaceConverter>, IMainSurfaceConverter
{
  private readonly IObjectConverter<GSG.Mesh, OG.Mesh> meshConverter;
  private readonly IObjectConverter<GSG.NurbsSurface, OG.Surface> surfaceConverter;

  public MainSurfaceConverter(IObjectConverter<GSG.Mesh, OG.Mesh> meshConverter,
                              IObjectConverter<GSG.NurbsSurface, OG.Surface> surfaceConverter,
                              ILogger<MainSurfaceConverter> logger) : base(logger)
  {
    this.meshConverter = meshConverter;
    this.surfaceConverter = surfaceConverter;
  }

  public OG.Mesh Convert(GSG.Mesh obj) => meshConverter.Convert(obj);

  public OG.Surface Convert(GSG.NurbsSurface obj) => surfaceConverter.Convert(obj);
}