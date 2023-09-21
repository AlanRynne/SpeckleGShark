using System.Collections;

namespace GShark.SpeckleConverter.Tests.TestData;

internal class TestPointData : IEnumerable<object[]>
{
  private readonly Random rnd = new();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return new object[] { new GSG.Point3(0, 0, 0), new OG.Point(0, 0) };
    yield return new object[] { new GSG.Point3(1, 0, 0), new OG.Point(1, 0) };
    yield return new object[] { new GSG.Point3(0, 1, 0), new OG.Point(0, 1) };
    yield return new object[] { new GSG.Point3(0, 0, 1), new OG.Point(0, 0, 1) };

    for (var i = 0; i < 5; i++)
    for (var j = 0; j < 5; j++)
    for (var k = 0; k < 5; k++)
    {
      var x = rnd.NextDouble();
      var y = rnd.NextDouble();
      var z = rnd.NextDouble();
      yield return new object[] { new GSG.Point3(x, y, z), new OG.Point(x, y, z) };
    }
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}