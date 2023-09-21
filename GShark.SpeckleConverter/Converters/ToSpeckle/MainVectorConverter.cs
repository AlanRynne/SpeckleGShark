using GShark.Core;
using Microsoft.Extensions.Logging;
using Transform = Objects.Other.Transform;

namespace GShark.SpeckleConverter.Converters.ToSpeckle;

public interface IMainVectorConverter :
  IObjectConverter<GSG.Vector3, OG.Vector>,
  IObjectConverter<GSG.Point3, OG.Point>,
  IObjectConverter<GSG.Plane, OG.Plane>,
  IObjectConverter<TransformMatrix, Transform>
{
}

public class MainVectorConverter : ConverterBase<MainVectorConverter>, IMainVectorConverter
{
  private readonly IObjectConverter<GSG.Plane, OG.Plane> planeConverter;
  private readonly IObjectConverter<GSG.Point3, OG.Point> pointConverter;
  private readonly IObjectConverter<TransformMatrix, Transform> transformConverter;
  private readonly IObjectConverter<GSG.Vector3, OG.Vector> vectorConverter;

  public MainVectorConverter(IObjectConverter<GSG.Vector3, OG.Vector> vectorConverter,
                             IObjectConverter<GSG.Point3, OG.Point> pointConverter,
                             IObjectConverter<GSG.Plane, OG.Plane> planeConverter,
                             IObjectConverter<TransformMatrix, Transform> transformConverter,
                             ILogger<MainVectorConverter> logger) : base(logger)
  {
    this.vectorConverter = vectorConverter;
    this.pointConverter = pointConverter;
    this.planeConverter = planeConverter;
    this.transformConverter = transformConverter;
  }


  public OG.Vector Convert(GSG.Vector3 obj) => vectorConverter.Convert(obj);

  public OG.Point Convert(GSG.Point3 obj) => pointConverter.Convert(obj);

  public OG.Plane Convert(GSG.Plane obj) => planeConverter.Convert(obj);

  public Transform Convert(TransformMatrix obj) => transformConverter.Convert(obj);
}