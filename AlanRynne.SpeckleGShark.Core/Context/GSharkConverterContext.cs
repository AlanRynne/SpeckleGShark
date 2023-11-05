using AlanRynne.SpeckleGShark.Core.Interfaces;
using Speckle.Core.Kits;

namespace AlanRynne.SpeckleGShark.Core.Context;

public class GSharkConverterContext : IGSharkConverterContext<GSharkConverterContext>
{
  private IConverterContextProvider<GSharkConverterContext>? provider;

  public string WorkingUnits { get; set; } = Units.None;

  public double GetConversionFactor(string unit) => Units.GetConversionFactor(unit, WorkingUnits);

  public void Dispose()
  {
    provider?.Pop(this);
  }

  public void SetProvider(IConverterContextProvider<GSharkConverterContext>? contextProvider)
  {
    provider = contextProvider;
  }

  public GSharkConverterContext Clone()
  {
    var cloned = new GSharkConverterContext
    {
      WorkingUnits = WorkingUnits
    };

    cloned.SetProvider(provider); // Set the provider reference in the cloned object
    return cloned;
  }
}