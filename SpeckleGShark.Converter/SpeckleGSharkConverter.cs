using Speckle.Core.Kits;
using Speckle.Core.Models;

using SpeckleGShark.Core;
using SpeckleGShark.Core.Interfaces;
using SpeckleGShark.Modules;

namespace GShark.SpeckleConverter;

/// <summary>
///   The Speckle-GShark converter.
///   Can be used standalone or loaded as part of the KitManager.
///   Preferred option is always to use KitManager for consistency with other converters.
/// </summary>
/// <remarks>
///   Reference it directly at your own peril 😉
/// </remarks>
public partial class SpeckleGSharkConverter : ISpeckleConverter
{
  private readonly IObjectConverter<Base, object>? toNativeConverter;
  private readonly IObjectConverter<object, Base>? toSpeckleConverter;

  public SpeckleGSharkConverter()
  {
    var resolver = GSharkConverterResolver.BuildDefault();
    toNativeConverter = resolver.GetToNativeConverter();
    toSpeckleConverter = resolver.GetToSpeckleConverter();
  }

  public bool CanConvertToNative(Base @object) => toNativeConverter?.CanConvert(@object) ?? false;

  public bool CanConvertToSpeckle(object @object) => toSpeckleConverter?.CanConvert(@object) ?? false;

  public Base ConvertToSpeckle(object @object)
  {
    if (toSpeckleConverter == null)
      throw new Exception("Converter does not implement toNative conversions");
    return toSpeckleConverter.Convert(@object);
  }

  public object ConvertToNative(Base @object)
  {
    if (toNativeConverter == null)
      throw new Exception("Converter does not implement toNative conversions");
    return toNativeConverter.Convert(@object);
  }

  public List<Base> ConvertToSpeckle(List<object> objects) => objects.Select(ConvertToSpeckle).ToList();
  public List<object> ConvertToNative(List<Base> objects) => objects.Select(ConvertToNative).ToList();
}