using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Core.Context;

public class ConverterContextProvider<T> : IConverterContextProvider<T> where T : IConverterContext<T>, new()
{
  private readonly AsyncLocal<Stack<T>> _contextStack = new();

  public ConverterContextProvider()
  {
    _contextStack.Value = new Stack<T>();
  }

  public T Peek()
  {
    EnsureStackInitialized();
    if (_contextStack.Value.Count > 0) return _contextStack.Value.Peek();
    var t = new T();
    t.SetProvider(this);
    return t;
  }

  public T Push()
  {
    EnsureStackInitialized();
    var topContext = _contextStack.Value.Peek();
    var clonedContext = topContext.Clone();
    _contextStack.Value.Push(clonedContext);
    return clonedContext;
  }

  public void Pop(T contextToPop)
  {
    EnsureStackInitialized();
    if (_contextStack.Value.Count <= 0) return;

    var topContext = _contextStack.Value.Peek();
    if (ReferenceEquals(topContext, contextToPop))
      _contextStack.Value.Pop();
    else
      // Throwing an exception as the context being popped is not at the top of the stack
      throw new InvalidOperationException("Attempted to pop a context that is not at the top of the stack.");
  }

  private void EnsureStackInitialized()
  {
    _contextStack.Value ??= new Stack<T>();
  }
}