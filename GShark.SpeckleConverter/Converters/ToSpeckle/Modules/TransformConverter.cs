using Microsoft.Extensions.Logging;
using Objects.Other;
using GSC = GShark.Core;

namespace GShark.SpeckleConverter.Converters.ToSpeckle.Modules;

public class TransformConverter : ConverterBase<TransformConverter, GSC.TransformMatrix, Transform>,
                                  IObjectConverter<GSC.TransformMatrix, Transform>
{
  public TransformConverter(ILogger<TransformConverter> logger) : base(logger)
  {
  }

  protected override Transform PerformConversion(GSC.TransformMatrix obj)
  {
    return new Transform(new[]
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
}