using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class ForEachRightTest
    {
        [Fact]
        public void ShouldExecuteProvidedFunctionFromRightToLeft()
        {
            var numbers = new List<int> { 1, 2, 3, 4 };
            var actualList = new List<int>();
            var expectedList = new List<int> { 4, 3, 2, 1 };

            ThirtySecondsOfCSharp.Lists.Lists.ForEachRight(numbers, x => actualList.Add(x));

            Assert.Equal(expectedList, actualList);
        }
    }
}
