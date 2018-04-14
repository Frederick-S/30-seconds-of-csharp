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

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.Chunk(numbers, 2));
        }

        [Fact]
        public void ShouldChunkListIntoTwoGroups()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expectedList = new List<List<int>>
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new List<int> { 6, 7, 8, 9, 10 },
            };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.Chunk(numbers, 5));
        }
    }
}