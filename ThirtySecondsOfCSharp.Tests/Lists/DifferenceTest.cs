using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class DifferenceTest
    {
        [Fact]
        public void ShouldReturnValuesOnlyInListA()
        {
            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 1, 2, 4 };
            var difference = new List<int> { 3 };

            Assert.Equal(difference, ThirtySecondsOfCSharp.Lists.Lists.Difference(a, b));
        }
    }
}