using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class MinNTest
    {
        [Fact]
        public void ShouldReturnOne()
        {
            var list = new List<int> { 1, 2, 3 };
            var expectedList = new List<int> { 1 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.MinN(list));
        }

        [Fact]
        public void ShouldReturnOneAndTwo()
        {
            var list = new List<int> { 1, 2, 3 };
            var expectedList = new List<int> { 1, 2 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.MinN(list, 2));
        }
    }
}
