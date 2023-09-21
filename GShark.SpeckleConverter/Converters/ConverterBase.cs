using GShark.SpeckleConverter.Extensions;
using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Converters;

public abstract class ConverterBase<t>
{
  protected readonly ILogger<t> Logger;

  protected ConverterBase(ILogger<t> logger)
  {
    Logger = logger;
  }
}

public abstract class ConverterBase<t, tFrom, tTo> : ConverterBase<t>,
                                                     IObjectConverter<tFrom, tTo>
  where t : ConverterBase<t, tFrom, tTo>
{
  protected ConverterBase(ILogger<t> logger) : base(logger)
  {
  }

  public tTo Convert(tFrom obj)
  {
    try
    {
      Logger.LogConversionStart(obj);
      var result = PerformConversion(obj);
      Logger.LogConversionSucceeded(obj, result);
      return result;
    }
    catch (Exception e)
    {
      Logger.LogConversionFailed(obj, e);
      throw;
    }
  }

  protected abstract tTo PerformConversion(tFrom obj);
}