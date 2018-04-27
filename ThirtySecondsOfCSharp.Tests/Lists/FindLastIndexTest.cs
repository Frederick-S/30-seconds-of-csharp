using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class FindLastIndexTest
    {
        [Fact]
        public void ShouldReturnIndexAsTwo()
        {
            var numbers = new List<int> { 1, 2, 3, 4 };

            Assert.Equal(2, ThirtySecondsOfCSharp.Lists.Lists.FindLastIndex(numbers, x => x % 2 == 1));
        }
    }
}
