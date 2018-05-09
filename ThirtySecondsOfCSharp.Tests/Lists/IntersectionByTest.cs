using System;
using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class IntersectionByTest
    {
        [Fact]
        public void ShouldReturnCommonElements()
        {
            var a = new List<double> { 2.1, 1.2 };
            var b = new List<double> { 2.3, 3.4 };
            var expectedList = new List<double> { 2.1 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.IntersectionBy(a, b, Math.Floor));
        }
    }
}
