using Microsoft.Extensions.Logging;

using SpeckleGShark.Core.Converters;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Modules.ToNative;

public interface IMainSurfaceConverter : IObjectConverter<OG.Mesh, GSG.Mesh>,
                                         IObjectConverter<OG.Surface, GSG.NurbsSurface>
{
}

public class MainSurfaceConverter : ConverterBase<MainSurfaceConverter>, IMainSurfaceConverter
{
  private readonly IObjectConverter<OG.Mesh, GSG.Mesh> meshConverter;
  private readonly IObjectConverter<OG.Surface, GSG.NurbsSurface> surfaceConverter;

  public MainSurfaceConverter(IObjectConverter<OG.Surface, GSG.NurbsSurface> surfaceConverter,
                              IObjectConverter<OG.Mesh, GSG.Mesh> meshConverter,
                              ILogger<MainSurfaceConverter> logger) : base(logger)
  {
    this.surfaceConverter = surfaceConverter;
    this.meshConverter = meshConverter;
  }

  public GSG.Mesh Convert(OG.Mesh obj) => meshConverter.Convert(obj);

  public GSG.NurbsSurface Convert(OG.Surface obj) => surfaceConverter.Convert(obj);
}