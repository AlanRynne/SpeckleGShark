using GShark.Core;
using Microsoft.Extensions.Logging;
using Transform = Objects.Other.Transform;

namespace GShark.SpeckleConverter.Converters.ToNative;

public interface IMainVectorConverter :
  IObjectConverter<OG.Point, GSG.Point3>,
  IObjectConverter<OG.Vector, GSG.Vector3>,
  IObjectConverter<OG.Plane, GSG.Plane>,
  IObjectConverter<Transform, TransformMatrix>
{
}

public class MainVectorConverter : ConverterBase<MainVectorConverter>, IMainVectorConverter
{
  private readonly IObjectConverter<OG.Plane, GSG.Plane> planeConverter;
  private readonly IObjectConverter<OG.Point, GSG.Point3> pointConverter;
  private readonly IObjectConverter<Transform, TransformMatrix> transformConverter;
  private readonly IObjectConverter<OG.Vector, GSG.Vector3> vectorConverter;

  public MainVectorConverter(IObjectConverter<OG.Point, GSG.Point3> pointConverter,
                             IObjectConverter<OG.Vector, GSG.Vector3> vectorConverter,
                             IObjectConverter<OG.Plane, GSG.Plane> planeConverter,
                             IObjectConverter<Transform, TransformMatrix> transformConverter,
                             ILogger<MainVectorConverter> logger) : base(logger)
  {
    this.pointConverter = pointConverter;
    this.vectorConverter = vectorConverter;
    this.planeConverter = planeConverter;
    this.transformConverter = transformConverter;
  }

  public GSG.Point3 Convert(OG.Point obj) => pointConverter.Convert(obj);

  public GSG.Vector3 Convert(OG.Vector obj) => vectorConverter.Convert(obj);

  public GSG.Plane Convert(OG.Plane obj) => planeConverter.Convert(obj);

  public TransformMatrix Convert(Transform obj) => transformConverter.Convert(obj);
}