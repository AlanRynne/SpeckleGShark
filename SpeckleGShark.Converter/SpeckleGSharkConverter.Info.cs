namespace GShark.SpeckleConverter;

/// <summary>
///   Contains any identifying info from the converter.
/// </summary>
public partial class SpeckleGSharkConverter
{
  public string Description => "The officially non-official Speckle <-> GShark Converter";
  public string Name => "Speckle GShark Converter";
  public string Author => "Alan Rynne";
  public string WebsiteOrEmail => "https://github.com/alanrynne";

  public IEnumerable<string> GetServicedApplications() => new[] { "GShark" };
}