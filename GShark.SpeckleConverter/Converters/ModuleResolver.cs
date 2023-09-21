using GShark.Core;
using GShark.SpeckleConverter.Converters.ToNative;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Speckle.Core.Models;
using TNM = GShark.SpeckleConverter.Converters.ToNative.Modules;
using Transform = Objects.Other.Transform;
using TSM = GShark.SpeckleConverter.Converters.ToSpeckle.Modules;

namespace GShark.SpeckleConverter.Converters;

public class ModuleResolver
{
  private readonly ServiceProvider provider;
  private readonly ServiceCollection services;

  public ModuleResolver()
  {
    services = new ServiceCollection();
    SetupDefaultConverters();
    services.AddLogging(builder => builder.AddConsole().AddDebug());
    provider = services.BuildServiceProvider();
  }


  public IObjectConverter<Base, object>? GetToNativeConverter() => GetConverter<Base, object>();

  public IObjectConverter<object, Base>? GetToSpeckleConverter() => GetConverter<object, Base>();

  public IObjectConverter<t, q>? GetConverter<t, q>() => provider.GetService<IObjectConverter<t, q>>();

  private void SetupDefaultConverters()
  {
    SetupDefaultToNativeConverters();
    SetupDefaultToSpeckleConverters();
  }

  private void SetupDefaultToNativeConverters()
  {
    services.AddScoped<IObjectConverter<OG.Point, GSG.Point3>, TNM.PointConverter>()
            .AddScoped<IObjectConverter<OG.Vector, GSG.Vector3>, TNM.VectorConverter>()
            .AddScoped<IObjectConverter<OG.Plane, GSG.Plane>, TNM.PlaneConverter>()
            .AddScoped<IObjectConverter<OG.Line, GSG.Line>, TNM.LineConverter>()
            .AddScoped<IObjectConverter<OG.Arc, GSG.Arc>, TNM.ArcConverter>()
            .AddScoped<IObjectConverter<OG.Circle, GSG.Circle>, TNM.CircleConverter>()
            .AddScoped<IObjectConverter<OG.Mesh, GSG.Mesh>, TNM.MeshConverter>()
            .AddScoped<IObjectConverter<OG.Curve, GSG.NurbsCurve>, TNM.NurbsCurveConverter>()
            .AddScoped<IObjectConverter<OG.Surface, GSG.NurbsSurface>, TNM.NurbsSurfaceConverter>()
            .AddScoped<IObjectConverter<Transform, TransformMatrix>, TNM.TransformConverter>()
            .AddScoped<IMainVectorConverter, MainVectorConverter>()
            .AddScoped<IMainCurveConverter, MainCurveConverter>()
            .AddScoped<IMainSurfaceConverter, MainSurfaceConverter>()
            .AddScoped<IObjectConverter<Base, object>, MainConverter>();
  }

  private void SetupDefaultToSpeckleConverters()
  {
    services.AddScoped<IObjectConverter<GSG.Point3, OG.Point>, TSM.PointConverter>()
            .AddScoped<IObjectConverter<GSG.Vector3, OG.Vector>, TSM.VectorConverter>()
            .AddScoped<IObjectConverter<GSG.Plane, OG.Plane>, TSM.PlaneConverter>()
            .AddScoped<IObjectConverter<GSG.Line, OG.Line>, TSM.LineConverter>()
            .AddScoped<IObjectConverter<GSG.Arc, OG.Arc>, TSM.ArcConverter>()
            .AddScoped<IObjectConverter<GSG.Circle, OG.Circle>, TSM.CircleConverter>()
            .AddScoped<IObjectConverter<GSG.NurbsCurve, OG.Curve>, TSM.NurbsCurveConverter>()
            .AddScoped<IObjectConverter<GSG.NurbsSurface, OG.Surface>, TSM.NurbsSurfaceConverter>()
            .AddScoped<IObjectConverter<GSG.Mesh, OG.Mesh>, TSM.MeshConverter>()
            .AddScoped<IObjectConverter<TransformMatrix, Transform>, TSM.TransformConverter>()
            .AddScoped<ToSpeckle.IMainVectorConverter, ToSpeckle.MainVectorConverter>()
            .AddScoped<ToSpeckle.IMainCurveConverter, ToSpeckle.MainCurveConverter>()
            .AddScoped<ToSpeckle.IMainSurfaceConverter, ToSpeckle.MainSurfaceConverter>()
            .AddScoped<IObjectConverter<object, Base>, ToSpeckle.MainConverter>();
  }
}