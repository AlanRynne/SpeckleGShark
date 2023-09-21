using GShark.SpeckleConverter.Converters.ToNative.Modules;
using GShark.SpeckleConverter.Tests.TestData;
using Xunit.Abstractions;

namespace GShark.SpeckleConverter.Tests.Converters;

public class VectorEntityConverterTests : CachedLoggerConverterTest<VectorConverter>
{
  public VectorEntityConverterTests(ITestOutputHelper output) : base(output)
  {
    Converter = new VectorConverter(Logger);
  }

  [Theory]
  [ClassData(typeof(TestVectorData))]
  private void CanConvert_Vector_ToNative(GSG.Vector3 nativeVector, OG.Vector speckleVector)
  {
    var actual = Converter?.Convert(speckleVector);
    Assert.True(nativeVector.Equals(actual));
  }
}