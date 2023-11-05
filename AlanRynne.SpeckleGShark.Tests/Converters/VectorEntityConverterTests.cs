using AlanRynne.SpeckleGShark.Core.Context;
using AlanRynne.SpeckleGShark.Modules.ToNative.Modules;
using AlanRynne.SpeckleGShark.Tests.TestData;
using Xunit.Abstractions;

namespace AlanRynne.SpeckleGShark.Tests.Converters;

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