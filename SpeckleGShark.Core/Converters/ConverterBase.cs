using Microsoft.Extensions.Logging;

using SpeckleGShark.Core.Context;
using SpeckleGShark.Core.Extensions;
using SpeckleGShark.Core.Interfaces;

namespace SpeckleGShark.Core.Converters;

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
    using var scope = Logger.BeginScope("Conversion from {from} To {to}", typeof(tFrom), typeof(tTo));
    try
    {
      var result = PerformConversion(obj);
      Logger.LogConversionSucceeded(obj!, result!);
      return result;
    }
    catch (Exception e)
    {
      Logger.LogConversionFailed(obj!, e);
      throw;
    }
  }

  protected abstract tTo PerformConversion(tFrom obj);
}

public abstract class ContextAwareConverterBase<t, tFrom, tTo> :
  ConverterBase<t, tFrom, tTo>,
  IContextAwareObjectConverter<tFrom, tTo, IConverterContextProvider<GSharkConverterContext>, GSharkConverterContext>
  where t : ContextAwareConverterBase<t, tFrom, tTo>
{
  protected ContextAwareConverterBase(ILogger<t> logger, IConverterContextProvider<GSharkConverterContext> provider) :
    base(logger)
  {
    ContextProvider = provider;
  }

  public IConverterContextProvider<GSharkConverterContext> ContextProvider { get; }
}