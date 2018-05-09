using System;
using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class IntersectionWithTest
    {
        [Fact]
        public void ShouldReturnCommonElements()
        {
            var a = new List<double> { 1, 1.2, 1.5, 3, 0 };
            var b = new List<double> { 1.9, 3, 0, 3.9 };
            var expectedList = new List<double> { 1.5, 3, 0 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.IntersectionWith(a, b, (x, y) => Math.Round(x) == Math.Round(y)));
        }
    }
}
