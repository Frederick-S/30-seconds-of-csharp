using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class IndexOfAllTest
    {
        [Fact]
        public void ShouldReturnAllIndices()
        {
            var numbers = new List<int> { 1, 2, 3, 1, 2, 3 };
            var expectedIndices = new List<int> { 0, 3 };

            Assert.Equal(expectedIndices, ThirtySecondsOfCSharp.Lists.Lists.IndexOfAll(numbers, 1));
        }
    }
}
