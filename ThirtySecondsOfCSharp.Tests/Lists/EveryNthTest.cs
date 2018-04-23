using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class EveryNthTest
    {
        [Fact]
        public void ShouldReturnThreeElements()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var expectedList = new List<int> { 2, 4, 6 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.EveryNth(numbers, 2));
        }
    }
}