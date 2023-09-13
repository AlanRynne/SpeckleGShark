using System.Collections;

namespace GShark.SpeckleConverter.Tests;

internal class TestVectorData : IEnumerable<object[]>
{
  private Random rnd = new();
  public IEnumerator<object[]> GetEnumerator()
  {
    yield return new object[] { new GSG.Vector3(0, 0, 0), new OG.Vector(0, 0, 0) };
    yield return new object[] { new GSG.Vector3(1, 0, 0), new OG.Vector(1, 0, 0) };
    yield return new object[] { new GSG.Vector3(0, 1, 0), new OG.Vector(0, 1, 0) };
    yield return new object[] { new GSG.Vector3(0, 0, 1), new OG.Vector(0, 0, 1) };
    
    for (var i = 0; i < 5; i++)
    for (var j = 0; j < 5; j++)
    for (var k = 0; k < 5; k++)
    {
      var x = rnd.NextDouble();
      var y = rnd.NextDouble();
      var z = rnd.NextDouble();
      yield return new object[] { new GSG.Vector3(x, y,z), new OG.Vector(x,y,z) };
    }
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}