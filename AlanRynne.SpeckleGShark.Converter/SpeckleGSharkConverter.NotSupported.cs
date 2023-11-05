using Speckle.Core.Kits;
using Speckle.Core.Models;

namespace GShark.SpeckleConverter;

/// <summary>
///   Includes everything not supported yet.
/// </summary>
public partial class SpeckleGSharkConverter
{
  public ReceiveMode ReceiveMode
  {
    get => ReceiveMode.Create;
    [Obsolete("Receive mode cannot be changed in GShark converter", true)]
    set => throw new NotSupportedException("Receive mode cannot be changed.");
  }

  public void SetContextDocument(object doc) => throw new NotSupportedException("No context document is supported");

  public void SetContextObjects(List<ApplicationObject> objects) =>
    throw new NotSupportedException("No context objects are supported");

  public void SetPreviousContextObjects(List<ApplicationObject> objects) =>
    throw new NotSupportedException("No previous contexts are supported");

  public void SetConverterSettings(object settings) => throw new NotSupportedException("No settings are supported");

  public ProgressReport Report => throw new NotSupportedException("Converter does not support reporting");

  public object ConvertToNativeDisplayable(Base @object) =>
    throw new NotSupportedException("Displayable object conversion is not supported yet");

  public bool CanConvertToNativeDisplayable(Base @object) =>
    throw new NotSupportedException("Displayable object conversion is not supported yet");
}