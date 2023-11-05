namespace SpeckleGShark.Core.Interfaces;

public interface IGSharkConverterContext<T> : IConverterContext<T> where T : IGSharkConverterContext<T>, new()
{
  string WorkingUnits { get; set; }
  double GetConversionFactor(string unit);
}