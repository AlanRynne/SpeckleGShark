using GShark.SpeckleConverter.Converters;

namespace GShark.SpeckleConverter.Tests.Fixtures;

public class ModuleResolverFixture : IDisposable
{
  public ModuleResolverFixture()
  {
    Resolver = new ModuleResolver();
  }

  public ModuleResolver Resolver { get; }

  public void Dispose()
  {
    // TODO release managed resources here
  }
}