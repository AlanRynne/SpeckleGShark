namespace AlanRynne.SpeckleGShark.Core.Interfaces;

public interface IConverterContext<T> : IDisposable where T : IConverterContext<T>, new()
{
  void SetProvider(IConverterContextProvider<T> provider);
  T Clone();
}