using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class FindLastTest
    {
        [Fact]
        public void ShouldReturnTheLastElementWhichPassThePredicate()
        {
            var numbers = new List<int> { 1, 2, 3, 4 };

            Assert.Equal(3, ThirtySecondsOfCSharp.Lists.Lists.FindLast(numbers, x => x % 2 == 1));
        }
    }
}
