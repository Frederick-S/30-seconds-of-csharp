using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class AllTest
    {
        [Fact]
        public void AllNumbersAreEven()
        {
            var numbers = new List<int> { 2, 4, 6, 8, 10 };

            Assert.True(ThirtySecondsOfCSharp.Lists.All(numbers, x => x % 2 == 0));
        }
    }
}
