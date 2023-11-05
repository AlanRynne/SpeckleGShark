namespace SpeckleGShark.Core.Interfaces;

public interface IContextAwareObjectConverter<in tFrom, out tTo, tContextProvider, tContext> :
  IObjectConverter<tFrom, tTo> where tContextProvider : IConverterContextProvider<tContext>
                               where tContext : IConverterContext<tContext>, new()
{
  tContextProvider ContextProvider { get; }
}