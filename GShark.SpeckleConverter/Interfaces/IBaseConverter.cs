namespace GShark.SpeckleConverter.Interfaces;

public interface IBaseConverter<in tFrom, out tTo>
{
  public tTo Convert(tFrom obj);
}