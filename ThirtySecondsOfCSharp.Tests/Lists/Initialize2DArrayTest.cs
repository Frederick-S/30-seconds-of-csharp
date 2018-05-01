using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class Initialize2DArrayTest
    {
        [Fact]
        public void ShouldGenerate2DArray()
        {
            var expectedList = new List<List<int>>
            {
                new List<int> { 0, 0 },
                new List<int> { 0, 0 },
            };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.Initialize2DArray(2, 2, 0));
        }
    }
}
