using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Modules;

public class NurbsSurfaceConverter : ConverterBase,
                                     IObjectToNativeConverter<OG.Surface, GSG.NurbsSurface>,
                                     IObjectToSpeckleConverter<GSG.NurbsSurface, OG.Surface>
{
  public NurbsSurfaceConverter(ILogger logger) : base(logger)
  {
  }

  public GSG.NurbsSurface Convert(OG.Surface obj)
  {
    throw new NotImplementedException();
  }

  public OG.Surface Convert(GSG.NurbsSurface obj)
  {
    throw new NotImplementedException();
  }
}