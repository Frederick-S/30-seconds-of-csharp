using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class CountOccurrencesTest
    {
        [Fact]
        public void ShouldReturnOccurrencesAsThree()
        {
            var numbers = new List<int> { 1, 1, 2, 1, 2, 3 };

            Assert.Equal(3, ThirtySecondsOfCSharp.Lists.Lists.CountOccurrences(numbers, 1));
        }
    }
}
