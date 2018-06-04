using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class OffsetTest
    {
        [Fact]
        public void ShouldMoveFirstTwoElementsToEnd()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var expectedList = new List<int> { 3, 4, 5, 1, 2 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.Offset(list, 2));
        }

        [Fact]
        public void ShouldMoveLastTwoElementsToFront()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var expectedList = new List<int> { 4, 5, 1, 2, 3 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.Offset(list, -2));
        }
    }
}
