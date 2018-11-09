using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class AllEqualTest
    {
        [Fact]
        public void AllNumbersAreEqual()
        {
            var numbers = new List<int> { 2, 2, 2, 2, 2 };

            Assert.True(ThirtySecondsOfCSharp.Lists.Lists.AllEqual(numbers));
        }
    }
}
