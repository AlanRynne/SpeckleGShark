using GShark.SpeckleConverter.Tests.Fixtures;
using GShark.SpeckleConverter.Tests.TestData;

namespace GShark.SpeckleConverter.Tests.Converters;

public class SpeckleConverterTests : IClassFixture<ConverterFixture>
{
  private readonly ConverterFixture fixture;

  public SpeckleConverterTests(ConverterFixture fixture)
  {
    this.fixture = fixture;
  }

  [Fact]
  public void CanGet_Converter_WithKitManager()
  {
    Assert.NotNull(fixture.Converter);
    Assert.IsType<SpeckleGSharkConverter>(fixture.Converter);
  }


  [Theory]
  [ClassData(typeof(TestAllData))]
  public void CanConvert_ToNative(object nativeObject, Base speckleObject)
  {
    var canConvert = fixture.Converter.CanConvertToNative(speckleObject);
    var actual = fixture.Converter.ConvertToNative(speckleObject);

    //Assert.True(canConvert);
    Assert.NotNull(actual);
    Assert.IsType(nativeObject.GetType(), actual);
  }

  [Fact]
  public void ContravarianceTest()
  {
    /*IObjectToNativeConverter<OG.Vector, GSG.Vector> vc = new VectorConverter(null);
    var toObject = vc as IObjectToNativeConverter<OG.Point, object> ;
    var toSubclassObject = vc as IObjectToNativeConverter<OG.ControlPoint, object> ;
    var toBase = vc as IBaseConverter<GSG.Point3, Base>;

    var toInvalid = vc as IObjectToNativeConverter<OG.Point, GSG.Arc> ;
    var toInvalid2 = vc as IObjectToNativeConverter<OG.Curve, GSG.Arc> ;

    Assert.NotNull(toObject);
    Assert.NotNull(toSubclassObject);
    Assert.NotNull(toBase);
    Assert.Null(toInvalid);
    Assert.Null(toInvalid2);*/
  }
}