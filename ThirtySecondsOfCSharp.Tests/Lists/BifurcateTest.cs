using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class BifurcateTest
    {
        [Fact]
        public void ShouldDivideNumbersIntoTwoGroups()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var filter = new List<bool> { true, true, true, false, false, false };
            var groups = ThirtySecondsOfCSharp.Lists.Bifurcate(numbers, filter);

            Assert.Equal(new List<int> { 1, 2, 3 }, groups[0]);
            Assert.Equal(new List<int> { 4, 5, 6 }, groups[1]);
        }
    }
}
