using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Modules;

public class NurbsCurveConverter : ConverterBase,
                                   IObjectToNativeConverter<OG.Curve, GSG.NurbsCurve>,
                                   IObjectToSpeckleConverter<GSG.NurbsCurve, OG.Curve>
{
  public NurbsCurveConverter(ILogger logger) : base(logger)
  {
  }

  public GSG.NurbsCurve Convert(OG.Curve obj)
  {
    throw new NotImplementedException();
  }

  public OG.Curve Convert(GSG.NurbsCurve obj)
  {
    throw new NotImplementedException();
  }
}