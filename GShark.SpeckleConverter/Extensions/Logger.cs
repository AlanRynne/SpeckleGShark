using GShark.SpeckleConverter.Logging;
using Microsoft.Extensions.Logging;

namespace GShark.SpeckleConverter.Extensions;

public static partial class Logger
{
  [LoggerMessage(
    EventId = (int)LoggerEvents.ConversionStart,
    Level = LogLevel.Information,
    Message = "Started conversion for {source}")]
  public static partial void LogConversionStart(this ILogger logger, object source);

  [LoggerMessage(
    EventId = (int)LoggerEvents.ConversionSucceeded,
    Level = LogLevel.Information,
    Message = "Conversion for {source} succeeded with result {result}")]
  public static partial void LogConversionSucceeded(this ILogger logger, object source, object result);

  [LoggerMessage(
    EventId = (int)LoggerEvents.ConversionFailed,
    Level = LogLevel.Error,
    Message = "Conversion for {source} failed")]
  public static partial void LogConversionFailed(this ILogger logger, object source, Exception exception);
}