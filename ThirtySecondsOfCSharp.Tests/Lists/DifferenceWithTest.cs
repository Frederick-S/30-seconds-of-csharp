using System;
using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class DifferenceWithTest
    {
        [Fact]
        public void ShouldReturnValuesOnlyInListA()
        {
            var a = new List<double> { 1, 1.2, 1.5, 3, 0 };
            var b = new List<double> { 1.9, 3, 0 };
            var difference = new List<double> { 1, 1.2 };

            Assert.Equal(difference, ThirtySecondsOfCSharp.Lists.Lists.DifferenceWith(a, b, (x, y) => Math.Round(x) == Math.Round(y)));
        }
    }
}