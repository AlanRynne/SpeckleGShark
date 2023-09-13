using Speckle.Core.Kits;
using Speckle.Core.Models;

namespace GShark.SpeckleConverter;

public class SpeckleGSharkConverter : ISpeckleConverter
{
  public Base ConvertToSpeckle(object @object)
  {
    throw new NotImplementedException();
  }

  public List<Base> ConvertToSpeckle(List<object> objects) => objects.Select(ConvertToSpeckle).ToList();

  public bool CanConvertToSpeckle(object @object)
  {
    throw new NotImplementedException();
  }

  public object ConvertToNative(Base @object)
  {
    throw new NotImplementedException();
  }

  public List<object> ConvertToNative(List<Base> objects)=> objects.Select(ConvertToNative).ToList();

  public bool CanConvertToNative(Base @object)
  {
    throw new NotImplementedException();
  }

  public IEnumerable<string> GetServicedApplications() => new[] { "GShark" };

  public void SetContextDocument(object doc)
  {
    throw new NotSupportedException();
  }

  public void SetContextObjects(List<ApplicationObject> objects)
  {
    throw new NotSupportedException();
  }

  public void SetPreviousContextObjects(List<ApplicationObject> objects)
  {
    throw new NotSupportedException();
  }

  public void SetConverterSettings(object settings)
  {
    throw new NotSupportedException("No converter settings have been ");
  }

  public string Description => "The officially non-official Speckle <-> GShark Converter";
  public string Name => "Speckle GShark Converter";
  public string Author => "Alan Rynne";
  public string WebsiteOrEmail => "https://github.com/alanrynne";
  public ProgressReport Report => throw new NotSupportedException("No report support for GShark");

  // Receive mode doesn't really make sense here.
  public ReceiveMode ReceiveMode
  {
    get => throw new NotSupportedException();
    set => throw new NotSupportedException();
  }
}