using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class MaxNTest
    {
        [Fact]
        public void ShouldReturnThree()
        {
            var list = new List<int> { 1, 2, 3 };
            var expectedList = new List<int> { 3 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.MaxN(list));
        }

        [Fact]
        public void ShouldReturnThreeAndTwo()
        {
            var list = new List<int> { 1, 2, 3 };
            var expectedList = new List<int> { 3, 2 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.MaxN(list, 2));
        }
    }
}
