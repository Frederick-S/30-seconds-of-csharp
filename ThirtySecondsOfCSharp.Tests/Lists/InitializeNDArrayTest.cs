using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class InitializeNDArrayTest
    {
        [Fact]
        public void ShouldCreateOneDimensionList()
        {
            var expectedList = new List<int> { 1, 1, 1 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.InitializeNDArray(1, 3));
        }

        [Fact]
        public void ShouldCreateThreeDimensionsList()
        {
            var expectedList = new List<List<List<int>>>
            {
                new List<List<int>>
                {
                    new List<int> { 5, 5 },
                    new List<int> { 5, 5 },
                },
                new List<List<int>>
                {
                    new List<int> { 5, 5 },
                    new List<int> { 5, 5 },
                },
            };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.InitializeNDArray(5, 2, 2, 2));
        }
    }
}
