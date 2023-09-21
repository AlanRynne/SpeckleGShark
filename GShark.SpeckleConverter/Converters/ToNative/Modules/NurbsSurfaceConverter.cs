using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters.ToNative.Modules;

public class NurbsSurfaceConverter : ConverterBase<NurbsSurfaceConverter, OG.Surface, GSG.NurbsSurface>
{
  public NurbsSurfaceConverter(ILogger<NurbsSurfaceConverter> logger) : base(logger)
  {
  }

  protected override GSG.NurbsSurface PerformConversion(OG.Surface obj) => throw new NotImplementedException();
}