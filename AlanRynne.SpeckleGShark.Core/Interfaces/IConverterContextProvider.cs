namespace AlanRynne.SpeckleGShark.Core.Interfaces;

public interface IConverterContextProvider<T> where T : IConverterContext<T>, new()
{
  T Peek();
  T Push();
  void Pop(T context);
}