using System.Collections;

namespace GShark.SpeckleConverter.Tests.TestData;

internal class TestPlaneData : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    yield return new object[]
    {
      GSG.Plane.PlaneXY,
      new OG.Plane(
        new OG.Point(0, 0, 0),
        new OG.Vector(0, 0, 1),
        new OG.Vector(1, 0, 0),
        new OG.Vector(0, 1, 0))
    };
    yield return new object[]
    {
      GSG.Plane.PlaneZX,
      new OG.Plane(
        new OG.Point(0, 0, 0),
        new OG.Vector(0, 1, 0),
        new OG.Vector(0, 0, 1),
        new OG.Vector(1, 0, 0))
    };
    yield return new object[]
    {
      GSG.Plane.PlaneYZ,
      new OG.Plane(
        new OG.Point(0, 0, 0),
        new OG.Vector(1, 0, 0),
        new OG.Vector(0, 1, 0),
        new OG.Vector(0, 0, 1))
    };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}