using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class IsSortedTest
    {
        [Fact]
        public void ShouldReturnDirectionAsOne()
        {
            var list = new List<int> { 0, 1, 2, 2 };

            Assert.Equal(1, ThirtySecondsOfCSharp.Lists.Lists.IsSorted(list));
        }

        [Fact]
        public void ShouldReturnDirectionAsMinusOne()
        {
            var list = new List<int> { 4, 3, 2 };

            Assert.Equal(-1, ThirtySecondsOfCSharp.Lists.Lists.IsSorted(list));
        }

        [Fact]
        public void ShouldReturnDirectionAsZero()
        {
            var list = new List<int> { 4, 3, 5 };

            Assert.Equal(0, ThirtySecondsOfCSharp.Lists.Lists.IsSorted(list));
        }
    }
}
