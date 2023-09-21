using GShark.Core;
using Microsoft.Extensions.Logging;
using Speckle.Core.Models;
using Transform = Objects.Other.Transform;

namespace GShark.SpeckleConverter.Converters.ToNative;

public class MainConverter : ConverterBase<MainConverter>, IObjectConverter<Base, object>
{
  private readonly List<object> converters;

  public MainConverter(IMainVectorConverter vectorConverter,
                       IMainCurveConverter curveConverter,
                       IMainSurfaceConverter surfaceConverter,
                       ILogger<MainConverter> logger) : base(logger)
  {
    converters = new List<object> { vectorConverter, curveConverter, surfaceConverter };
  }


  public object Convert(Base obj)
  {
    foreach (var c in converters)
    {
      var convert = ConverterUtils.TryGetConversionMethodForType(c.GetType(), obj.GetType());
      if (convert == null) continue;
      return convert.Invoke(c, new object[] { obj });
    }

    throw new NotSupportedException($"Conversion of {obj.GetType().Name} to GShark is not supported");
  }
}