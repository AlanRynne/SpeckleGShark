using Speckle.Core.Kits;

namespace SpeckleGShark.Modules.Utils;

public static class PointExtensions
{
  public static IEnumerable<OG.Point> UnFlattenPoints(this List<double> arr, string units = Units.None)
  {
    if (arr.Count % 3 != 0)
      throw new ArgumentException("Array malformed: length%3 != 0.", nameof(arr));

    var points = new List<OG.Point>(arr.Count / 3);

    var sf = 1; // Conversion factor
    for (var i = 2; i < arr.Count; i += 3)
      points.Add(new OG.Point(arr[i - 2] * sf, arr[i - 1] * sf, arr[i] * sf));

    return points;
  }

  public static IEnumerable<OG.ControlPoint> UnFlattenControlPoints(this List<double> arr, string units = Units.None)
  {
    if (arr.Count % 4 != 0)
      throw new ArgumentException("Array malformed: length%3 != 0.", nameof(arr));

    var points = new List<OG.ControlPoint>(arr.Count / 3);

    var sf = 1; // Conversion factor
    for (var i = 3; i < arr.Count; i += 4)
      points.Add(new OG.ControlPoint(arr[i - 3] * sf, arr[i - 2] * sf, arr[i - 1] * sf, arr[i] * sf, units));

    return points;
  }
}