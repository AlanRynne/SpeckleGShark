using Speckle.Core.Models;

namespace GShark.SpeckleConverter.Interfaces;

public interface IObjectToNativeConverter<in tSpeckleObject, out tNativeObject>
  : IBaseConverter<tSpeckleObject, tNativeObject>
  where tSpeckleObject : Base
{
}