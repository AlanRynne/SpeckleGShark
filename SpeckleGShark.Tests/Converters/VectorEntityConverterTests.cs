using SpeckleGShark.Core.Context;
using SpeckleGShark.Modules.ToNative.Modules;
using SpeckleGShark.Tests.TestData;
using Xunit.Abstractions;

namespace SpeckleGShark.Tests.Converters;

public class VectorEntityConverterTests : ConverterTestsBase<VectorConverter>
{
  public VectorEntityConverterTests(ITestOutputHelper output) : base(output)
  {
    Converter = new VectorConverter(Logger, new ConverterContextProvider<GSharkConverterContext>());
  }

  [Theory]
  [ClassData(typeof(TestVectorData))]
  private void CanConvert_Vector_ToNative(GSG.Vector3 nativeVector, OG.Vector speckleVector)
  {
    var actual = Converter?.Convert(speckleVector);
    Assert.True(nativeVector.Equals(actual));
  }
}