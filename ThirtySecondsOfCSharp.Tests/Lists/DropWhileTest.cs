using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class DropWhileTest
    {
        [Fact]
        public void ShouldReturnTwoElements()
        {
            var numbers = new List<int> { 1, 2, 3, 4 };
            var expectedList = new List<int> { 3, 4 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.DropWhile(numbers, x => x >= 3));
        }
    }
}