using System.Reflection;
using Speckle.Core.Models;

namespace GShark.SpeckleConverter;

public static class ConverterUtils
{
  public static MethodInfo? TryGetConversionMethodForType(Type? converterType, Type? objType)
  {
    if (converterType == null || objType == null)
      return null;

    var converterInterfaces = converterType.GetInterfaces();

    MethodInfo? conversionMethod = null;
    foreach (var iface in converterInterfaces)
      if (iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IObjectConverter<,>))
      {
        var inType = iface.GetGenericArguments()[0];
        if (inType != objType) continue;
        conversionMethod = iface.GetMethod("Convert");
        break;
      }

    return conversionMethod;
  }

  public static bool CanConvert(this IObjectConverter<Base, object> converter, Base obj) =>
    TryGetConversionMethodForType(converter.GetType(), obj.GetType()) != null;

  public static bool CanConvert(this IObjectConverter<object, Base> converter, object obj) =>
    TryGetConversionMethodForType(converter.GetType(), obj.GetType()) != null;
}