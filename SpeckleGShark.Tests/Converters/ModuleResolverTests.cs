using SpeckleGShark.Tests.Fixtures;
using SpeckleGShark.Tests.TestData;

namespace SpeckleGShark.Tests.Converters;

public class ModuleResolverTests : IClassFixture<ModuleResolverFixture>
{
  private readonly ModuleResolverFixture fixture;

  public ModuleResolverTests(ModuleResolverFixture fixture)
  {
    this.fixture = fixture;
  }

  [Fact]
  public void CanGetSpecificConverters()
  {
    var toNative = fixture.Resolver.GetConverter<OG.Line, GSG.Line>();
    Assert.NotNull(toNative);
    var toSpeckle = fixture.Resolver.GetConverter<GSG.Line, OG.Line>();
    Assert.NotNull(toSpeckle);
  }

  [Theory]
  [ClassData(typeof(TestAllData))]
  public void CanGetToNativeConverter(object nativeObject, Base speckleObject)
  {
    var toNative = fixture.Resolver.GetConverter<Base, object>();
    Assert.NotNull(toNative);
    var result = toNative.Convert(speckleObject);
    Assert.NotNull(result);
    Assert.IsType(nativeObject.GetType(), nativeObject);
  }
}