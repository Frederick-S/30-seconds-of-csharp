using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class DropRightTest
    {
        [Fact]
        public void ShouldRemoveTwoElementsFromRight()
        {
            var numbers = new List<int> { 1, 2, 3 };
            var expectedList = new List<int> { 1 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.DropRight(numbers, 2));
        }

        [Fact]
        public void ShouldReturnEmptyList()
        {
            var numbers = new List<int> { 1, 2, 3 };

            Assert.Equal(Enumerable.Empty<int>(), ThirtySecondsOfCSharp.Lists.Lists.DropRight(numbers, 42));
        }
    }
}
