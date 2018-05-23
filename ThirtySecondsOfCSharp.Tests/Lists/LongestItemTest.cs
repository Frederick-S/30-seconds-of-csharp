using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class LongestItemTest
    {
        [Fact]
        public void ShouldReturnTheLongestItem()
        {
            var lists = new List<int>[]
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 1, 2 },
                new List<int> { 1, 2, 3, 4, 5 },
            };
            var expectedList = new List<int> { 1, 2, 3, 4, 5 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.LongestItem(lists));
        }
    }
}
