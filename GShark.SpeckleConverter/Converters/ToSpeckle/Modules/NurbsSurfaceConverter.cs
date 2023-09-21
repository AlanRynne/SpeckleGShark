using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToSpeckle.Modules;

public class NurbsSurfaceConverter : ConverterBase<NurbsSurfaceConverter, GSG.NurbsSurface, OG.Surface>,
                                     IObjectConverter<GSG.NurbsSurface, OG.Surface>
{
  public NurbsSurfaceConverter(ILogger<NurbsSurfaceConverter> logger) : base(logger)
  {
  }

  protected override OG.Surface PerformConversion(GSG.NurbsSurface obj) => throw new NotImplementedException();
}