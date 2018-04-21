using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class DropRightWhileTest
    {
        [Fact]
        public void ShouldReturnTwoElements()
        {
            var numbers = new List<int> { 1, 2, 3, 4 };
            var expectedList = new List<int> { 1, 2 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.DropRightWhile(numbers, x => x < 3));
        }
    }
}
