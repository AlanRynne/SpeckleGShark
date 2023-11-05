using AlanRynne.SpeckleGShark.Tests.Fixtures;
using AlanRynne.SpeckleGShark.Tests.TestData;
using GShark.SpeckleConverter;
using Speckle.Core.Kits;

namespace AlanRynne.SpeckleGShark.Tests;

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

  [Fact]
  public void Converter_HasAuthorInfo()
  {
    Assert.NotNull(fixture.Converter.Author);
    Assert.NotEmpty(fixture.Converter.Author);
    Assert.NotNull(fixture.Converter.Description);
    Assert.NotEmpty(fixture.Converter.Description);
    Assert.NotNull(fixture.Converter.WebsiteOrEmail);
    Assert.NotEmpty(fixture.Converter.WebsiteOrEmail);
  }

  [Theory]
  [ClassData(typeof(TestAllData))]
  public void Converter_CanConvert_ToNative(object nativeObject, Base speckleObject)
  {
    var canConvert = fixture.Converter.CanConvertToNative(speckleObject);
    var actual = fixture.Converter.ConvertToNative(speckleObject);

    Assert.True(canConvert);
    Assert.NotNull(actual);
    Assert.IsType(nativeObject.GetType(), actual);
  }

  [Fact]
  public void Converter_ReceiveMode_AllowsOnlyCreate()
  {
    Assert.Equal(ReceiveMode.Create, fixture.Converter.ReceiveMode);
    Assert.Throws<NotSupportedException>(() => fixture.Converter.ReceiveMode = ReceiveMode.Ignore);
  }

  [Fact]
  public void Converter_Report_WillThrow()
  {
    Assert.Throws<NotSupportedException>(() => fixture.Converter.Report);
  }

  [Fact]
  public void Converter_NotSupportedMethods_WillThrow()
  {
    Assert.Throws<NotSupportedException>(() => fixture.Converter.SetContextDocument(null));
    Assert.Throws<NotSupportedException>(() => fixture.Converter.SetContextObjects(null));
    Assert.Throws<NotSupportedException>(() => fixture.Converter.SetPreviousContextObjects(null));
    Assert.Throws<NotSupportedException>(() => fixture.Converter.SetConverterSettings(null));
    Assert.Throws<NotSupportedException>(() => fixture.Converter.ConvertToNativeDisplayable(null));
    Assert.Throws<NotSupportedException>(() => fixture.Converter.CanConvertToNativeDisplayable(null));
  }
}