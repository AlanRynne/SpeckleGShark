using Speckle.Core.Models;

namespace GShark.SpeckleConverter.Interfaces;

public interface IObjectToSpeckleConverter<in tNativeObject, out tSpeckleObject>
  : IBaseConverter<tNativeObject, tSpeckleObject>
  where tSpeckleObject : Base
{
}