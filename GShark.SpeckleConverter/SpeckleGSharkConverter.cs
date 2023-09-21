using GShark.SpeckleConverter.Converters;
using Speckle.Core.Kits;
using Speckle.Core.Models;

namespace GShark.SpeckleConverter;

/// <summary>
///   The Speckle-GShark converter.
///   Can be used standalone or loaded as part of the KitManager.
///   Preferred option is always to use KitManager for consistency with other converters.
/// </summary>
/// <remarks>
///   Reference it directly at your own peril 😉
/// </remarks>
public class SpeckleGSharkConverter : ISpeckleConverter
{
  private readonly IObjectConverter<Base, object>? toNativeConverter;
  private readonly IObjectConverter<object, Base>? toSpeckleConverter;

  public SpeckleGSharkConverter()
  {
    var resolver = new ModuleResolver();
    toNativeConverter = resolver.GetToNativeConverter();
    toSpeckleConverter = resolver.GetToSpeckleConverter();
  }

  public Base ConvertToSpeckle(object @object)
  {
    if (toSpeckleConverter == null)
      throw new Exception("Converter does not implement toNative conversions");
    return toSpeckleConverter.Convert(@object);
  }

  public List<Base> ConvertToSpeckle(List<object> objects) => objects.Select(ConvertToSpeckle).ToList();

  public bool CanConvertToSpeckle(object @object) => toSpeckleConverter?.CanConvert(@object) ?? false;

  public object ConvertToNative(Base @object)
  {
    if (toNativeConverter == null)
      throw new Exception("Converter does not implement toNative conversions");
    return toNativeConverter.Convert(@object);
  }

  public List<object> ConvertToNative(List<Base> objects) => objects.Select(ConvertToNative).ToList();

  public bool CanConvertToNative(Base @object) => toNativeConverter?.CanConvert(@object) ?? false;

  public IEnumerable<string> GetServicedApplications() => new[] { "GShark" };

  public void SetContextDocument(object doc) => throw new NotSupportedException("No context document is supported");

  public void SetContextObjects(List<ApplicationObject> objects) =>
    throw new NotSupportedException("No context objects are supported");

  public void SetPreviousContextObjects(List<ApplicationObject> objects) =>
    throw new NotSupportedException("No previous contexts are supported");

  public void SetConverterSettings(object settings) => throw new NotSupportedException("No settings are supported");

  public string Description => "The officially non-official Speckle <-> GShark Converter";
  public string Name => "Speckle GShark Converter";
  public string Author => "Alan Rynne";
  public string WebsiteOrEmail => "https://github.com/alanrynne";
  public ProgressReport Report => throw new NotImplementedException("Converter does not support reporting");

  // Receive mode doesn't really make sense here.
  public ReceiveMode ReceiveMode { get; set; }
}