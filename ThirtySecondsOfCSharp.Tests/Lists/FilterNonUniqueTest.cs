using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class FilterNonUniqueTest
    {
        [Fact]
        public void ShouldReturnThreeElements()
        {
            var numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
            var expectedList = new List<int> { 1, 3, 5 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.FilterNonUnique(numbers));
        }
    }
}