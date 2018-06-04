using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class PartitionTest
    {
        [Fact]
        public void ShouldGroupTheElementsIntoTwoLists()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6 };
            var expectedList = new List<List<int>>
            {
                new List<int> { 2, 4, 6 },
                new List<int> { 1, 3, 5 },
            };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.Partition(list, x => x % 2 == 0));
        }
    }
}
