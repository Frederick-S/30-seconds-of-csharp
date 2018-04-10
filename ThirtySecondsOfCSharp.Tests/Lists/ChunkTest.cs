using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class ChunkTest
    {
        [Fact]
        public void ShouldChunkListIntoThreeGroups()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var expectedList = new List<List<int>>
            {
                new List<int> { 1, 2 },
                new List<int> { 3, 4 },
                new List<int> { 5 },
            };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Chunk(numbers, 2));
        }
    }
}