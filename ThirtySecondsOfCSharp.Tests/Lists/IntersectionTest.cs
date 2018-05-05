using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class IntersectionTest
    {
        [Fact]
        public void ShouldReturnCommonElements()
        {
            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 4, 3, 2 };
            var expectedList = new List<int> { 2, 3 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.Intersection(a, b));
        }
    }
}
