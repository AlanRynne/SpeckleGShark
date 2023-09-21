using Speckle.Core.Kits;
using Speckle.Core.Logging;

namespace GShark.SpeckleConverter.Tests.Fixtures;

public class ConverterFixture : IDisposable
{
  public ConverterFixture()
  {
    Setup.Init("GSharkSpeckleTests", "GShark");
    Kit = KitManager.GetDefaultKit();
    Converter = Kit.LoadConverter("GShark");
  }

  public ISpeckleKit Kit { get; }
  public ISpeckleConverter Converter { get; private set; }

  public void Dispose()
  {
  }
}