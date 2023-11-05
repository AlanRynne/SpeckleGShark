using System.Reflection;
using Speckle.Core.Models;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Core;

public static class ConverterUtils
{
  public static MethodInfo? TryGetConversionMethodForType(Type? converterType, Type? objType)
  {
    if (converterType == null || objType == null)
      return null;

    var converterInterfaces = converterType.GetInterfaces();

    return converterInterfaces
          .Where(iface => iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IObjectConverter<,>))
          .Select(iface => new { iface, inType = iface.GetGenericArguments()[0] })
          .Where(t => t.inType == objType)
          .Select(t => t.iface.GetMethod("Convert")).FirstOrDefault();
  }

  public static bool CanConvert(this IObjectConverter<Base, object> converter, Base obj) =>
    TryGetConversionMethodForType(converter.GetType(), obj.GetType()) != null;

  public static bool CanConvert(this IObjectConverter<object, Base> converter, object obj) =>
    TryGetConversionMethodForType(converter.GetType(), obj.GetType()) != null;
}