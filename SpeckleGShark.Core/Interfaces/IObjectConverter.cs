namespace SpeckleGShark.Core.Interfaces;

public interface IObjectConverter<in tFrom, out tTo>
{
  public tTo Convert(tFrom obj);
}