using System.Collections;

namespace SpeckleGShark.Tests.TestData;

internal class TestAllData : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator() => Enumerable
                                                 .Empty<object[]>()
                                                 .Append(new TestPointData().First())
                                                 .Append(new TestVectorData().First())
                                                 .Append(new TestPlaneData().First())
                                                 .GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}