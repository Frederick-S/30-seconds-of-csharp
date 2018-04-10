using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class AnyTest
    {
        [Fact]
        public void ShouldFindANumberGreaterThanTen()
        {
            var numbers = new List<int> { 1, 2, 30 };

            Assert.True(ThirtySecondsOfCSharp.Lists.Any(numbers, x => x > 10));
        }
    }
}