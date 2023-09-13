using Microsoft.Extensions.Logging;
using GSC = GShark.Core;
using Transform = Objects.Other.Transform;

namespace GShark.SpeckleConverter.Modules.ToSpeckle;

public class TransformConverter : ConverterBase,
                                  IObjectToNativeConverter<Transform, GSC.TransformMatrix>,
                                  IObjectToSpeckleConverter<GSC.TransformMatrix, Transform>
{
  public TransformConverter(ILogger logger) : base(logger)
  {
  }

  public GSC.TransformMatrix Convert(Transform obj) => new(obj.ToArray());

  public Transform Convert(GSC.TransformMatrix obj) =>
    new(new[]
    {
      obj.M00,
      obj.M01,
      obj.M02,
      obj.M03,
      obj.M10,
      obj.M11,
      obj.M12,
      obj.M13,
      obj.M20,
      obj.M21,
      obj.M22,
      obj.M23,
      obj.M30,
      obj.M31,
      obj.M32,
      obj.M33
    });
}