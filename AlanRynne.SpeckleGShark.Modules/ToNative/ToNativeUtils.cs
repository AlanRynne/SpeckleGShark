namespace AlanRynne.SpeckleGShark.Modules.ToNative;

public static class ToNativeUtils
{
  public static List<List<int>> FaceListToNative(List<int> faces)
  {
    var i = 0;
    var groupedFaces = new List<List<int>>();
    while (i < faces.Count)
    {
      var n = faces[i];
      if (n < 3)
        n += 3; // 0 -> 3, 1 -> 4

      if (n == 3)
        // triangle
        groupedFaces.Add(new List<int> { faces[i + 1], faces[i + 2], faces[i + 3] });
      else if (n == 4)
        // quad
        groupedFaces.Add(new List<int> { faces[i + 1], faces[i + 2], faces[i + 3], faces[i + 4] });
      else
        // n-gon
        groupedFaces.Add(faces.GetRange(i + 1, n));

      i += n + 1;
    }

    return groupedFaces;
  }

  public static IEnumerable<GSG.Point3> PointListToNative(IList<double> arr)
  {
    if (arr.Count % 3 != 0)
      throw new ArgumentException("Array malformed: length%3 != 0.", nameof(arr));

    var points = new List<GSG.Point3>(arr.Count / 3);

    var sf = 1; // Conversion factor
    for (var i = 2; i < arr.Count; i += 3)
      points.Add(new GSG.Point3(arr[i - 2] * sf, arr[i - 1] * sf, arr[i] * sf));

    return points;
  }
}