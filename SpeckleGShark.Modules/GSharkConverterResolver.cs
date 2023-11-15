using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Speckle.Core.Models;

using SpeckleGShark.Core.Context;
using SpeckleGShark.Core.Interfaces;
using SpeckleGShark.Core.Logging;
using SpeckleGShark.Modules.ToNative;
using SpeckleGShark.Modules.ToNative.Modules;

namespace SpeckleGShark.Modules;

public class GSharkConverterResolver
{
  private readonly IServiceProvider provider;

  public GSharkConverterResolver(IServiceProvider provider)
  {
    this.provider = provider;
  }

  public IObjectConverter<Base, object>? GetToNativeConverter() => GetConverter<Base, object>();

  public IObjectConverter<object, Base>? GetToSpeckleConverter() => GetConverter<object, Base>();

  public IObjectConverter<tFrom, tTo>? GetConverter<tFrom, tTo>() =>
    provider.GetService<IObjectConverter<tFrom, tTo>>();

  public static GSharkConverterResolver BuildDefault()
  {
    var services = new ServiceCollection();
    SetupDefaultConverters(services);
    services.AddLogging(builder =>
    {
      builder.AddProvider(new DelegateLoggerProvider(message => Console.WriteLine("Converter said:" + message)));
    });
    var provider = services.BuildServiceProvider();
    return new GSharkConverterResolver(provider);
  }

  public static void SetupDefaultConverters(IServiceCollection serviceCol)
  {
    SetupDefaultToNativeConverters(serviceCol);
    SetupDefaultToSpeckleConverters(serviceCol);
    serviceCol
     .AddScoped<IConverterContextProvider<GSharkConverterContext>, ConverterContextProvider<GSharkConverterContext>>();
  }

  public static void SetupDefaultToNativeConverters(IServiceCollection serviceCol) => serviceCol
   .AddScoped<IObjectConverter<OG.Point, GSG.Point3>, PointConverter>()
   .AddScoped<IObjectConverter<OG.Vector, GSG.Vector3>, VectorConverter>()
   .AddScoped<IObjectConverter<OG.Plane, GSG.Plane>, PlaneConverter>()
   .AddScoped<IObjectConverter<OG.Line, GSG.Line>, LineConverter>()
   .AddScoped<IObjectConverter<OG.Arc, GSG.Arc>, ArcConverter>()
   .AddScoped<IObjectConverter<OG.Circle, GSG.Circle>, CircleConverter>()
   .AddScoped<IObjectConverter<OG.Mesh, GSG.Mesh>, MeshConverter>()
   .AddScoped<IObjectConverter<OG.Curve, GSG.NurbsCurve>, NurbsCurveConverter>()
   .AddScoped<IObjectConverter<OG.Surface, GSG.NurbsSurface>, NurbsSurfaceConverter>()
   .AddScoped<IMainVectorConverter, MainVectorConverter>()
   .AddScoped<IMainCurveConverter, MainCurveConverter>()
   .AddScoped<IMainSurfaceConverter, MainSurfaceConverter>()
   .AddScoped<IObjectConverter<Base, object>, MainConverter>();

  public static void SetupDefaultToSpeckleConverters(IServiceCollection serviceCol) => serviceCol
   .AddScoped<IObjectConverter<GSG.Point3, OG.Point>, ToSpeckle.Modules.PointConverter>()
   .AddScoped<IObjectConverter<GSG.Vector3, OG.Vector>, ToSpeckle.Modules.VectorConverter>()
   .AddScoped<IObjectConverter<GSG.Plane, OG.Plane>, ToSpeckle.Modules.PlaneConverter>()
   .AddScoped<IObjectConverter<GSG.Line, OG.Line>, ToSpeckle.Modules.LineConverter>()
   .AddScoped<IObjectConverter<GSG.Arc, OG.Arc>, ToSpeckle.Modules.ArcConverter>()
   .AddScoped<IObjectConverter<GSG.Circle, OG.Circle>, ToSpeckle.Modules.CircleConverter>()
   .AddScoped<IObjectConverter<GSG.NurbsCurve, OG.Curve>, ToSpeckle.Modules.NurbsCurveConverter>()
   .AddScoped<IObjectConverter<GSG.NurbsSurface, OG.Surface>, ToSpeckle.Modules.NurbsSurfaceConverter>()
   .AddScoped<IObjectConverter<GSG.Mesh, OG.Mesh>, ToSpeckle.Modules.MeshConverter>()
   .AddScoped<ToSpeckle.IMainVectorConverter, ToSpeckle.MainVectorConverter>()
   .AddScoped<ToSpeckle.IMainCurveConverter, ToSpeckle.MainCurveConverter>()
   .AddScoped<ToSpeckle.IMainSurfaceConverter, ToSpeckle.MainSurfaceConverter>()
   .AddScoped<IObjectConverter<object, Base>, ToSpeckle.MainConverter>();
}