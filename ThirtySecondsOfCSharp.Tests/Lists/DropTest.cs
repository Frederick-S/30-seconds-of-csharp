using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class DropTest
    {
        [Fact]
        public void ShouldRemoveTwoElements()
        {
            var numbers = new List<int> { 1, 2, 3 };
            var expectedList = new List<int> { 3 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.Drop(numbers, 2));
        }

        [Fact]
        public void ShouldReturnEmptyList()
        {
            var numbers = new List<int> { 1, 2, 3 };

            Assert.Equal(Enumerable.Empty<int>(), ThirtySecondsOfCSharp.Lists.Lists.Drop(numbers, 42));
        }
    }
}